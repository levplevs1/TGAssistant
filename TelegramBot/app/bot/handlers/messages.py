import threading
from time import sleep
from app.bot.handlers import waiting_for_response
from utils.functions import count_tokens
from app.bot import bot


@bot.message_handler(content_types=['voice'])
def handle_voice_message(message):
    print("Голосовое сообщение")

@bot.message_handler(content_types=['photo'])
def handle_photo_and_text(message):
    print("Изображение от пользователя")

@bot.message_handler()
def texts(message):
    print(123)
    global save_message
    user_id = message.from_user.id

    # Проверяем, ожидает ли пользователь ответа
    if waiting_for_response.get(user_id, False):
        bot.send_message(message.chat.id, "Пожалуйста, подождите, пока я обработаю ваш предыдущий запрос.")
        return

    user_data = None #Загрузка данных пользователя из БД!!!

    if user_data is None:
        bot.send_message(message.chat.id, "Ошибка: не удалось загрузить конфигурацию.")
        return

    if count_tokens(message.text) >= 500:
        bot.send_message(message.chat.id, "Ваше сообщение слишком большое")
        return


    if count_tokens(message.text) <= 100:
        memory = user_data.get('memory', [])  # Загружаем память пользователя

        for word in ["запомни", "сохрани", "не забудь","Запомни", "Сохрани", "Не забудь"]:
            if word in message.text:
                # Если память полна, выводим сообщение
                if len(memory) >= 10:
                    bot.send_message(message.chat.id, "Память переполнена! Очистите лишнее с помощью команды 'память'")
                    return
                ai_check = None #analyze_prompt(message.text) Переписать!!!!
                if ai_check == "+":
                    memory.append(message.text.replace(word, '', 1).strip())
                    user_data['memory'] = memory  # Обновляем память в данных пользователя
                    #save_user_data(user_id, user_data)  # Сохраняем изменения в БД
                    bot.send_message(message.chat.id, "Память обновлена")
                else:
                    bot.send_message(message.chat.id, "Ваш запрос содержит информацию, которая не может быть сохранена, так как она нарушает правила допустимого содержания. Пожалуйста, убедитесь, что информация является корректной, не содержит неподобающих деталей или запрещенных тем.")
                    return
    else:
        bot.send_message(message.chat.id, "Слишком большое сообщение что бы его запомнить")

    waiting_for_response[user_id] = True
    sent_message = bot.send_message(message.chat.id, "Ваш запрос отправлен, ожидайте ответа.")
    save_message = [sent_message.message_id, message.chat.id]
    thread = threading.Thread(target=process_user_request, args=(message,))
    thread.start()
    typing_thread = threading.Thread(target=send_typing_action, args=(message.chat.id, user_id))
    typing_thread.start()

def process_user_request():
    print("Переделать функцию обработки запроса")

def send_typing_action(chat_id, user_id):
    while waiting_for_response.get(user_id, False):
        bot.send_chat_action(chat_id, 'typing')
        sleep(2)  # Отправляем статус каждые 2 секунды