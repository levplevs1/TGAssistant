from telebot.types import KeyboardButton, ReplyKeyboardMarkup

from config import bot
from telebot import types
from utils.save_load import save_user_data, load_user_data

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
            'category_dialog': "",
            'meter_readings': {},
            'memory': [],
            'memory_chat': []
        }
        save_user_data(user_id, user_data)

    keyboard = ReplyKeyboardMarkup(resize_keyboard=True, one_time_keyboard=True)
    keyboard.add(KeyboardButton("Вот что я умею"))

    bot.send_message(message.chat.id, """
<b>Здравствуйте! 👋</b>

Я — ваш личный цифровой помощник по государственным услугам. Готов помочь вам с любыми вопросами, связанными с:

- 🏠 <b>ЖКХ</b>: Оплата счетчиков, справки, услуги и многое другое.
- 🏥 <b>Здравоохранение</b>: Запись к врачу, получение справок, информация о льготах.
- 🎓 <b>Образование</b>: Поступить в учебное заведение, получить документы и другую информацию.
- 🚗 <b>Транспорт</b>: Регистрация транспорта, получение водительских прав, информация о штрафах.

<b>Команды, которые вы можете использовать:</b>
- <b>/menu</b> — выбрать категорию (ЖКХ, Транспорт, Здравоохранение, Образование).
- <b>/memory</b> — показать информацию, которую я помню о вас.
- <b>/help</b> — узнать больше обо мне и как я могу помочь.

Также в боте доступна <b>функция оплаты услуг</b>! Вы можете оплатить ЖКХ, электричество, газ и многое другое прямо через бота.

Просто выберите команду или напишите ваш вопрос, и я постараюсь помочь!

✨ <b>Всегда рад помочь!</b>
""", parse_mode="HTML", reply_markup=keyboard)

@bot.message_handler(commands=['help'])
def help_command(message):
    bot.send_message(message.chat.id, """
<b>Как пользоваться:</b>
- ❓ Задайте вопрос, например: "Как оплатить воду?" или "Как получить льготы?"
- 📂 Используйте команды: <b>/menu</b> для выбора категории услуг или <b>/memory</b> для просмотра запомненной информации.
- 📝 Пишите свои запросы просто и понятно — я помогу найти нужное решение.

Если хотите сменить категория используйте команду <b>/menu</b>
""", parse_mode="HTML")

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