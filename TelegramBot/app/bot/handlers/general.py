from config import bot
from telebot import types
from utils.save_load import save_user_data, load_user_data
from os import path

@bot.message_handler(commands=['start'])
def starter(message):
    #Добавить запись пользователя в БД!!!!!!!!!!!!!!!!!!!!!!
    #ID пользователя, время, Начальное имя, Конечное имя, Никнейм

    user_id = message.from_user.id
    user_first_name = message.from_user.first_name

    # Загружаем данные пользователя или создаем новый файл
    user_data = load_user_data(user_id)

    if user_data is None:
        # Если файла нет, создаем его с пустой памятью
        user_data = {
            'user_id': user_id,
            'first_name': user_first_name,
            'category_dialog': ""
        }
        save_user_data(user_id, user_data)
        bot.send_message(message.chat.id, f'Здравствуйте {user_first_name}, ваш конфигурационный файл создан!')
    else:
        bot.send_message(message.chat.id, f'Здравствуйте {user_first_name}, ваш конфигурационный файл загружен!')

    bot.send_message(message.chat.id, f'Ваш ID: {user_id}')


@bot.message_handler(commands=['help'])
def help_command(message):
    bot.send_message(message.chat.id, """
Возможности ассистента:

• Консультирует по вопросам оплаты коммунальных услуг, получения медицинских услуг, образовательных программ и транспортной доступности.
• Ассистент помнит контекст диалога и все сообщения в нем.
""")

@bot.message_handler(commands=['memory'])
def memory_command(message):
    user_id = message.from_user.id
    # Получение пользователя из БД
    # Получение памяти пользователя
    memory = ["123", "23"]
    memory_markup = types.InlineKeyboardMarkup()
    count = 0
    for el in memory:
        memory_markup.add(types.InlineKeyboardButton(el, callback_data=f'{count}'))
        count += 1

    # Отправляем сообщение с памятью в виде кнопок и сохраняем его ID
    sent_message = bot.send_message(message.chat.id, "Вот что мы о вас помним:", reply_markup=memory_markup)
    #last_memory_message_id[user_id] = sent_message.message_id - вызывало ошибку, раскомитеть