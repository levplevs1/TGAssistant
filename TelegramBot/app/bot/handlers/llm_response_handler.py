import threading
from time import sleep
from app.bot.handlers import users_status_service, waiting_for_response
from app.bot.handlers.murkup_button import get_markup_services, get_keyboard
from classifier.base_classifier import classify_type_llm, process_callback_data, validate_response
from llm.prompt_manager import get_meter_readings_llm, include_headers_llm, process_user_request, validation_answer_llm, \
    memory_validation_llm
from config import bot
from utils.document_utils import extract_headers, search_by_header
from utils.logs import save_log_to_file
from utils.save_load import save_memory_chat, save_user_data
from utils.tokens import validate_count_tokens
from colorama import init, Fore
import warnings

init(autoreset=True)

# Разделяемая переменная для анимации
class SharedText:
    def __init__(self, text):
        self.text = text
        self.lock = threading.Lock()

    def update_text(self, new_text):
        with self.lock:
            self.text = new_text

    def get_text(self):
        with self.lock:
            return self.text

# Создаём флаг для завершения потока
stop_event = threading.Event()

def animate_status_typing(sent_message, shared_text, change_time=1):
    """
    Анимация статуса печати сообщения.

    Аргументы:
        sent_message: Сообщение, которое будет редактироваться.
        shared_text: Разделяемая переменная с текстом для анимации.
        change_time: Время задержки между анимациями.
    """
    while not stop_event.is_set():  # Проверяем флаг на каждой итерации
        try:
            reverse_animate_typing = False
            while sent_message is not None:
                base_text = shared_text.get_text()  # Получаем актуальный текст
                if not reverse_animate_typing:
                    for i in range(1, 4):  # Цикл для добавления точек
                        bot.edit_message_text(
                            chat_id=sent_message.chat.id,
                            message_id=sent_message.message_id,
                            text=base_text + "." * i
                        )
                        sleep(change_time)
                    reverse_animate_typing = True
                else:
                    bot.edit_message_text(
                        chat_id=sent_message.chat.id,
                        message_id=sent_message.message_id,
                        text=base_text
                    )
                    sleep(change_time)
                    reverse_animate_typing = False
        except Exception:
            print("Предупреждение. Текст для изменения анимации не найден")

def send_typing_action(chat_id, user_id):
    while waiting_for_response.get(user_id, False):
        bot.send_chat_action(chat_id, 'typing')
        sleep(2)  # Отправляем статус каждые 2 секунды

def handle_user_message(message, user_data):
    user_id = message.from_user.id
    sent_message = bot.send_message(message.chat.id, "Думаю... Определяю обращение")

    # Создаём разделяемую переменную для текста
    shared_text = SharedText("Думаю... Определяю обращение")

    # Запуск анимации в отдельном потоке
    thread = threading.Thread(target=animate_status_typing, args=(sent_message, shared_text))
    thread.start()
    print(f"Сообщение пользователя: {message.text}")

    if message.text:
        classify_type = classify_type_llm(message.text)

        # Тип запроса - услуга
        if classify_type and user_data["category_dialog"] == "ЖКХ":

            stop_event.set()

            shared_text.update_text("Рассматриваю запрос на услугу")
            if sent_message.text != "Рассматриваю запрос на услугу":  # Проверка перед редактированием
                bot.edit_message_text(chat_id=sent_message.chat.id, message_id=sent_message.message_id, text="Рассматриваю запрос на услугу")
            meter_readings = get_meter_readings_llm(message.text)
            if meter_readings['category'] != 'unknown':
                users_status_service[user_id] = meter_readings['category']
                process_callback_data(user_id, message.chat.id, users_status_service[user_id], meter_readings)
                bot.delete_message(chat_id=sent_message.chat.id, message_id=sent_message.message_id)
            else:
                shared_text.update_text("Выберите услугу:")
                markup = get_markup_services()
                bot.send_message(message.chat.id, "Выберите услугу:", reply_markup=markup)
        else:
            shared_text.update_text("Формирую ответ на вопрос")

            stop_event.set()

            if sent_message.text != "Формирую ответ на вопрос":  # Проверка перед редактированием
                bot.edit_message_text(chat_id=sent_message.chat.id, message_id=sent_message.message_id, text="Формирую ответ на вопрос")

            # Тип запроса - вопрос
            process_query(user_id, user_data, message, shared_text)
            bot.delete_message(chat_id=sent_message.chat.id, message_id=sent_message.message_id)

    stop_event.set()  # Устанавливаем флаг завершения
    thread.join()  # Дожидаемся завершения потока

    save_log_to_file()
    waiting_for_response[user_id] = False

def forming_response(message, user_data):
    waiting_for_response[message.from_user.id] = True
    thread = threading.Thread(target=handle_user_message, args=(message, user_data))
    thread.start()
    typing_thread = threading.Thread(target=send_typing_action, args=(message.chat.id, message.from_user.id))
    typing_thread.start()

def process_query(user_id, user_data, message, shared_text):

        shared_text.update_text("Анализирую базу знаний")

        # Получение всех заголовков из базы знаний
        headers = extract_headers(user_id)

        # Извлечение заголовков LLM из запроса пользователя
        llm_headers = include_headers_llm(message.text, headers)

        # Поиск информации в базе знаний по заголовкам
        doc_text = search_by_header(llm_headers["commands"], user_id)

        # Формирование ответа
        llm_answer = process_user_request(message.text, user_data, doc_text)

        print("Валидация ответа...")
        shared_text.update_text("Валидация ответа")

        # Валидация ответа
        llm_answer_correction = validate_answer(message, llm_answer, doc_text, user_data)
        print(llm_answer_correction)

        # Отправка ответа пользователю
        keyboard = get_keyboard(message.from_user.id)
        bot.send_message(message.chat.id, llm_answer_correction, reply_markup=keyboard)

def validate_answer(message, llm_answer, doc_text, user_data, retry_count=0, max_retries=2):
        # Проверка на превышение количества попыток
        if retry_count > max_retries:
            print("Превышено максимальное количество попыток. Возвращаю None.")
            return llm_answer

        validation_llm = validate_response(validation_answer_llm(message.text, llm_answer))
        print(validation_llm)
        if validation_llm[0] is True:
            save_memory_chat(message, llm_answer)
            return llm_answer
        else:
            bot.send_message(message.chat.id, "Извините, произошла ошибка при формировании моего ответа. Повторяю попытку")
            llm_correction_answer = process_user_request(message.text, user_data, doc_text, comment_text=f"""
            
            {validation_llm[0]}\n\n
            
        Комментарий для исправления:
        Твой предыдущий ответ не прошёл финальную валидацию, поскольку нарушил один или несколько критериев. Вот список выявленных проблем:
        1. Ответ должен быть полностью на русском языке (исключения: ссылки или названия организаций). Проверка не пройдена.
        2. Ответ не должен содержать нецензурной лексики или оскорбительных выражений. В твоём ответе это обнаружено.
        3. Ответ не должен затрагивать запрещённые темы (например, терроризм, экстремизм и т.д.). Ты допустил нарушение этого правила.
        4. Ответ должен соответствовать текущей теме обсуждения и содержать полезную информацию. Обнаружено несоответствие темы или отсутствие полезности.
        Исправь свой ответ так, чтобы он соответствовал всем перечисленным критериям:
        - Переформулируй ответ, сохранив релевантность текущему запросу пользователя.
        - Убери любые упоминания запрещённых тем, если они есть.
        - Обеспечь, чтобы ответ был чётким, логичным и строго по запросу.
        Если ты не уверен в релевантности ответа, дай знать и предложи пользователю уточнить запрос.
        Важно: Переформулированный ответ должен пройти финальную проверку без нарушений.
        """)
            retry_count += 1
            print(retry_count)
            return validate_answer(message, llm_correction_answer, doc_text, user_data, retry_count)

def check_save_user_memory(message, user_data):
    if not validate_count_tokens(message.text, 100):
        memory = user_data.get('memory', [])  # Загружаем память пользователя
        user_id = user_data.get('user_id', None)

        for word in ["запомни", "сохрани", "не забудь"]:
            if word in message.text.lower():
                # Если память полна, выводим сообщение
                if len(memory) >= 10:
                    bot.send_message(message.chat.id, "Память переполнена! Очистите лишнее с помощью команды 'память'")
                    return

                memory_response = memory_validation_llm(message.text)
                print(f"Рез-тат валидации памяти: {memory_response}")
                if memory_response["is_acceptable"]:
                    user_data['memory'].append(memory_response["compressed_text"])  # Обновляем память в данных пользователя
                    save_user_data(user_id, user_data)  # Сохраняем изменения в БД
                    bot.send_message(message.chat.id, "Память обновлена")
                else:
                    bot.send_message(message.chat.id, "Ваш запрос содержит информацию, которая не может быть сохранена, так как она нарушает правила допустимого содержания или произошла ошибка во время операции. Пожалуйста, убедитесь, что информация является корректной, не содержит неподобающих деталей или запрещенных тем.")
                    return
    else:
        bot.send_message(message.chat.id, "Слишком большое сообщение, чтобы его запомнить")