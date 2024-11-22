import threading
from time import sleep
from app.bot.handlers import users_status_service, waiting_for_response
from classifier.base_classifier import classify_type_llm, process_callback_data, validate_response, get_markup_services, \
    get_keyboard
from llm.prompt_manager import get_meter_readings_llm, include_headers_llm, process_user_request, validation_answer_llm, \
    memory_validation_llm
from config import bot
from utils.document_utils import extract_headers, search_by_header
from utils.logs import save_log_to_file
from utils.save_load import save_memory_chat, save_user_data
from utils.tokens import validate_count_tokens
from colorama import init, Fore

init(autoreset=True)

def send_typing_action(chat_id, user_id):
    while waiting_for_response.get(user_id, False):
        bot.send_chat_action(chat_id, 'typing')
        sleep(2)  # Отправляем статус каждые 2 секунды

def handle_user_message(message, user_data):
    user_id = message.from_user.id
    sent_message = bot.send_message(message.chat.id, "Думаю... Определяю обращение")

    print(f"Сообщение пользователя: {message.text}")

    if message.text:
        classify_type = classify_type_llm(message.text)

        # Тип запроса - услуга
        if classify_type and user_data["category_dialog"] == "ЖКХ":
                bot.edit_message_text(chat_id=sent_message.chat.id, message_id=sent_message.message_id, text="Рассматриваю запрос на услугу")

                # Запись и валидация счётчиков LLM
                meter_readings = get_meter_readings_llm(message.text)
                if meter_readings['category'] != 'unknown':
                    users_status_service[user_id] = meter_readings['category']

                    process_callback_data(user_id, message.chat.id, users_status_service[user_id], meter_readings)
                    bot.delete_message(chat_id=sent_message.chat.id, message_id=sent_message.message_id)

                    # Извлечение ранее переданных показаний счётчиков пользователя
                    meter_readings_user = user_data.get('meter_readings', None)
                    print(f"Показатели счётчиков пользователя: {meter_readings_user}")

                    # Проверка существования счётчиков
                    try:
                        # Запись счётчиков пользователя
                        user_data['meter_readings'] = meter_readings
                        save_user_data(user_id, user_data)
                    except Exception as e:
                        print(Fore.RED + f"Ошибка записи показателей в пользователя: {e}")

                else:
                    markup = get_markup_services()
                    bot.send_message(message.chat.id, "Выберите услугу:", reply_markup=markup)
                    
        else:
            bot.edit_message_text(chat_id=sent_message.chat.id, message_id=sent_message.message_id, text="Формирую ответ на вопрос")

            # Тип запроса - вопрос
            process_query(user_id, user_data, message)
            bot.delete_message(chat_id=sent_message.chat.id, message_id=sent_message.message_id)

    save_log_to_file()
    waiting_for_response[user_id] = False

def forming_response(message, user_data):
    waiting_for_response[message.from_user.id] = True
    thread = threading.Thread(target=handle_user_message, args=(message, user_data))
    thread.start()
    typing_thread = threading.Thread(target=send_typing_action, args=(message.chat.id, message.from_user.id))
    typing_thread.start()

def process_query(user_id, user_data, message):

        # Получение всех заголовков из базы знаний
        headers = extract_headers(user_id)

        # Извлечение заголовков LLM из запроса пользователя
        llm_headers = include_headers_llm(message.text, headers)

        # Поиск информации в базе знаний по заголовкам
        doc_text = search_by_header(llm_headers["commands"], user_id)

        # Формирование ответа
        llm_answer = process_user_request(message.text, user_data, doc_text)

        print("Валидация ответа...")

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
    if not validate_count_tokens(message.text, 785):
        memory = user_data.get('memory', [])  # Загружаем память пользователя
        user_id = user_data.get('user_id', None)

        if message.text.startswith('/запомни'):
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