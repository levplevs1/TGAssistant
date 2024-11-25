import threading
from time import sleep
from app.bot.handlers import users_status_service, waiting_for_response
from classifier.base_classifier import classify_type_llm, process_callback_data, validate_response, get_markup_services, \
    get_keyboard, get_markup_interaction_options
from llm.prompt_manager import get_meter_readings_llm, include_headers_llm, process_user_request, validation_answer_llm, \
    memory_validation_llm, include_question_llm
from config import bot
from utils.document_utils import extract_headers, search_by_header
from utils.logs import save_log_to_file
from colorama import init, Fore
from database.load import get_service_type_database, post_memory_database, \
    get_memory_chat_database, get_memory_request_database, get_meter_readings, save_meter_readings, post_answer_request, \
    get_counters_data, get_question, get_content_by_question, get_heading, get_content_by_heading

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
        if classify_type and get_service_type_database(user_id) == "ЖКХ":
                bot.edit_message_text(chat_id=sent_message.chat.id, message_id=sent_message.message_id, text="Рассматриваю запрос на услугу")

                # Запись и валидация счётчиков LLM
                meter_readings = get_meter_readings_llm(message.text)
                if meter_readings['category'] != 'unknown':
                    users_status_service[user_id] = meter_readings['category']

                    process_callback_data(user_id, message.chat.id, meter_readings['category'], meter_readings)
                    bot.delete_message(chat_id=sent_message.chat.id, message_id=sent_message.message_id)

                    # Проверка существования счётчиков
                    try:
                        # Запись счётчиков пользователя
                        save_meter_readings(user_id, meter_readings['data'])
                    except Exception as e:
                        print(Fore.RED + f"Ошибка записи показателей в пользователя: {e}")

                else:
                    markup = get_markup_services()
                    bot.send_message(message.chat.id, "Выберите услугу:", reply_markup=markup)
                    
        else:
            bot.edit_message_text(chat_id=sent_message.chat.id, message_id=sent_message.message_id, text="Формирую ответ на вопрос")

            # Извлечение заголовков LLM из запроса пользователя
            questions = get_question()
            question = include_question_llm(message.text, questions)

            if question['commands'] != '':
                service_type = get_service_type_database(user_id)
                content_by_question = get_content_by_question(question['commands'])
                if service_type == "ЖКХ" and content_by_question is not None:
                    post_answer_request(message.from_user.id, message.text, question['commands'])
                    keyboard = get_keyboard(message.from_user.id)
                    markup = get_markup_interaction_options()
                    post_answer_request(message.from_user.id, message.text, content_by_question)
                    bot.send_message(message.chat.id, "Запрос обработан", reply_markup=keyboard)
                    bot.send_message(message.chat.id, content_by_question, reply_markup=markup)
                else:
                    # Тип запроса - вопрос
                    process_query(user_id, user_data, message)
                    bot.delete_message(chat_id=sent_message.chat.id, message_id=sent_message.message_id)
            else:
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
        headers = get_heading()

        llm_headers = include_headers_llm(message.text, headers)

        # Поиск информации в базе знаний по заголовкам
        doc_text = get_content_by_heading(llm_headers["commands"])

        memory_chat = get_memory_chat_database(user_id)
        memory_request = get_memory_request_database(user_id)
        category_dialog = get_service_type_database(user_id)
        meter_readings = get_counters_data(user_id)
        # Формирование ответа
        llm_answer = process_user_request(message.text, user_data, memory_chat,memory_request,category_dialog, meter_readings, doc_text)

        print("Валидация ответа...")

        # Валидация ответа
        llm_answer_correction = validate_answer(message, llm_answer, doc_text, user_data)
        print(llm_answer_correction)

        # Отправка ответа пользователю
        keyboard = get_keyboard(message.from_user.id)
        markup = get_markup_interaction_options()
        bot.send_message(message.chat.id, "Запрос обработан", reply_markup=keyboard)
        bot.send_message(message.chat.id, llm_answer_correction, reply_markup=markup)

def validate_answer(message, llm_answer, doc_text, user_data, retry_count=0, max_retries=2):
        # Проверка на превышение количества попыток
        if retry_count > max_retries:
            print("Превышено максимальное количество попыток. Возвращаю None.")
            return llm_answer

        validation_llm = validate_response(validation_answer_llm(message.text, llm_answer))
        print(validation_llm)
        if validation_llm[0] is True:
            post_answer_request(message.from_user.id, message.text,llm_answer)
            return llm_answer
        else:
            bot.send_message(message.chat.id, "Извините, произошла ошибка при формировании моего ответа. Повторяю попытку")

            memory_chat = get_memory_chat_database(message.from_user.id)
            memory_request = get_memory_request_database(message.from_user.id)
            category_dialog = get_service_type_database(message.from_user.id)
            meter_readings = get_counters_data(message.from_user.id)

            llm_correction_answer = process_user_request(message.text, user_data, memory_chat, memory_request, category_dialog, meter_readings, comment_text=f"""
            
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

def check_save_user_memory(message):
    if len(message.text) <= 249:
        user_id = message.from_user.id

        if message.text.startswith('/запомни'):
            # Если память полна, выводим сообщение

            memory_response = memory_validation_llm(message.text)
            print(f"Рез-тат валидации памяти: {memory_response}")
            if memory_response["is_acceptable"]:
                post_memory_database(user_id, memory_response["compressed_text"], '', True)
                bot.send_message(message.chat.id, "Память обновлена")
                return True
            else:
                bot.send_message(message.chat.id, "Ваш запрос содержит информацию, которая не может быть сохранена, так как она нарушает правила допустимого содержания или произошла ошибка во время операции. Пожалуйста, убедитесь, что информация является корректной, не содержит неподобающих деталей или запрещенных тем.")
                return
    else:
        bot.send_message(message.chat.id, "Слишком большое сообщение, чтобы его запомнить")