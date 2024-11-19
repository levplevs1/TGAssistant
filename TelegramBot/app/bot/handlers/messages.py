import json
import threading
from time import sleep, time
from app.bot.handlers import waiting_for_response, users_status_service
from app.bot.handlers.murkup_button import get_keyboard, send_categories, get_markup_counters, get_markup_services
from classifier.base_classifier import process_callback_data
from classifier.base_classifier import classify_type_llm
from llm.prompt_manager import process_user_request, include_headers_llm, memory_validation_llm, get_meter_readings_llm, \
    classify_query_with_llm
from utils.document_utils import search_by_header, extract_headers
from utils.tokens import validate_count_tokens
from config import bot
from utils.save_load import load_user_data, save_memory_chat, get_last_message, save_user_data

# Обработка голосового сообщения
@bot.message_handler(content_types=['voice'])
def handle_voice_message(message):
    print("Голосовое сообщение")

# Обработка изображения
@bot.message_handler(content_types=['photo'])
def handle_photo_and_text(message):
    print("Изображение от пользователя")

# Обработка сообщения
@bot.message_handler()
def texts(message):
    print(123)
    global save_message
    user_id = message.from_user.id

    # Проверяем оказывается ли услуга пользователю
    if users_status_service.get(user_id, False):
        bot.send_message(message.chat.id, "Производится оказание услуги")
        handle_user_message(message)
        return

    # Проверяем, ожидает ли пользователь ответа
    if waiting_for_response.get(user_id, False):
        bot.send_message(message.chat.id, "Пожалуйста, подождите, пока я обработаю ваш предыдущий запрос.")
        return

    user_data = load_user_data(user_id) #Загрузка данных пользователя из БД!!!

    if user_data is None:
        print("Ошибка: не удалось загрузить конфигурацию.")
        return

    if user_data["category_dialog"] == "":
        send_categories(message)
        return

    if message.text == "🔄Изменить ответ":
        last_message = get_last_message(user_id)
        message_copy = message
        message_copy.text = last_message
        forming_response(user_id, message_copy)
        return
    elif message.text == "❔Ещё варианты":
        keyboard = get_keyboard(user_id)
        bot.send_message(message.chat.id, "Вот ещё варианты" , reply_markup=keyboard)
        return


    if validate_count_tokens(message.text, 500):
        bot.send_message(message.chat.id, "Ваше сообщение слишком большое")
        return

    if not validate_count_tokens(message.text, 100):
        memory = user_data.get('memory', [])  # Загружаем память пользователя

        for word in ["запомни", "сохрани", "не забудь"]:
            if word in message.text.lower():
                # Если память полна, выводим сообщение
                if len(memory) >= 10:
                    bot.send_message(message.chat.id, "Память переполнена! Очистите лишнее с помощью команды 'память'")
                    return

                memory_response = memory_validation_llm(message.text)
                #memory_validation = json.loads(memory_response)
                print(f"Рез-тат валидации памяти: {memory_response}")
                if memory_response["is_acceptable"]:
                    user_data['memory'].append(memory_response["compressed_text"])  # Обновляем память в данных пользователя
                    save_user_data(user_id, user_data)  # Сохраняем изменения в БД
                    bot.send_message(message.chat.id, "Память обновлена")
                else:
                    bot.send_message(message.chat.id, "Ваш запрос содержит информацию, которая не может быть сохранена, так как она нарушает правила допустимого содержания или произошла ошибка во время операции. Пожалуйста, убедитесь, что информация является корректной, не содержит неподобающих деталей или запрещенных тем.")
                    return
    else:
        bot.send_message(message.chat.id, "Слишком большое сообщение что бы его запомнить")

    forming_response(user_id, message)


def handle_user_message(message):
    start_time = time()
    sent_message = bot.send_message(message.chat.id, "Думаю... Определяю обращение")

    # Создаём разделяемую переменную для текста
    shared_text = SharedText("Думаю... Определяю обращение")

    # Запуск анимации в отдельном потоке
    thread = threading.Thread(target=animate_status_typing, args=(sent_message, shared_text))
    thread.start()

    print(start_time)
    print(f"Сообщение пользователя: {message.text}")
    user_id = message.from_user.id
    if message.text:
        classify_type = classify_type_llm(message.text)

        # Тип запроса - услуга
        if classify_type:
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
            if sent_message.text != "Формирую ответ на вопрос":  # Проверка перед редактированием
                bot.edit_message_text(chat_id=sent_message.chat.id, message_id=sent_message.message_id, text="Формирую ответ на вопрос")

            # Тип запроса - вопрос
            process_query(user_id, message)

            bot.delete_message(chat_id=sent_message.chat.id, message_id=sent_message.message_id)
    end_time = time()
    result_time = end_time - start_time
    print(f"Время обработки: {result_time}")
    waiting_for_response[user_id] = False


def forming_response(user_id, message):
    waiting_for_response[message.from_user.id] = True
    thread = threading.Thread(target=handle_user_message, args=(message,))
    thread.start()
    typing_thread = threading.Thread(target=send_typing_action, args=(message.chat.id, message.from_user.id))
    typing_thread.start()

def process_query(user_id, message):
    headers = extract_headers(user_id)  # Запрос является вопросом
    llm_headers = include_headers_llm(message.text, headers)  # Извлечение заголовков LLM моделью
    doc_text = search_by_header(llm_headers["commands"], user_id)  # Поиск информации в документе по заголовкам
    llm_answer = process_user_request(message.text, doc_text)  # Формирование ответа LLM пользователю
    save_memory_chat(message, llm_answer)
    keyboard = get_keyboard(message.from_user.id)
    bot.send_message(message.chat.id, llm_answer, reply_markup=keyboard)

def send_typing_action(chat_id, user_id):
    while waiting_for_response.get(user_id, False):
        bot.send_chat_action(chat_id, 'typing')
        sleep(2)  # Отправляем статус каждые 2 секунды


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

def animate_status_typing(sent_message, shared_text, change_time=0.5):
    """
    Анимация статуса печати сообщения.

    Аргументы:
        sent_message: Сообщение, которое будет редактироваться.
        shared_text: Разделяемая переменная с текстом для анимации.
        change_time: Время задержки между анимациями.
    """
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
