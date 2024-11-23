from telebot.types import KeyboardButton, ReplyKeyboardMarkup

from app.bot.handlers import last_memory_message_id
from config import bot
from telebot import types
from database.load import get_user_database, add_user_database, get_memory_database, \
    get_memory_request_with_ids_filtered, get_counters_data


@bot.message_handler(commands=['start'])
def starter(message):

    user_id = message.from_user.id

    # Загружаем данные пользователя или создаем новый файл
    user_data = get_user_database(user_id)

    if user_data is None:
        first_name = message.from_user.first_name
        last_name = message.from_user.last_name
        username = message.from_user.username

        add_user_database(user_id, username, first_name, last_name)

    keyboard = ReplyKeyboardMarkup(resize_keyboard=True, one_time_keyboard=True)
    keyboard.add(KeyboardButton("Вот что я умею"))

    bot.send_message(message.chat.id, """
<b>Здравствуйте! 👋</b>

Я — ваш личный цифровой помощник по государственным услугам. Готов помочь вам с любыми вопросами, связанными с:

- 🏠 <b>ЖКХ</b>: Оплата счетчиков, справки, услуги и многое другое.
- 🏥 <b>Здравоохранение</b>: Запись к врачу, получение справок, информация о льготах.
- 🎓 <b>Образование</b>: Поступить в учебное заведение, получить документы и другую информацию.
- 🚗 <b>Транспорт</b>: Регистрация транспорта, получение водительских прав, информация о штрафах.

---

💡 <b>Примеры запросов:</b>
- "Как записаться к врачу через портал госуслуг?"
- "Оплати электричество: день 1253, ночь 842."
- "Какие документы нужны для поступления в вуз?"
- "Покажи мои последние показания счётчиков."
- "/запомни я студент 2 курса."

---

<b>Команды, которые вы можете использовать:</b>
- <b>/menu</b> — выбрать категорию (ЖКХ, Транспорт, Здравоохранение, Образование).
- <b>/memory</b> — показать информацию, которую я помню о вас.
- <b>/help</b> — узнать больше обо мне и как я могу помочь.
- <b>/counters</b> — показать показания всех счетчиков
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
- 📌 Используйте /запомни (фраза) что бы я запомнил важную информацию 
- 🔢 Используйте команду /counters что бы посмотреть показания счетчиков

Если хотите сменить категория используйте команду <b>/menu</b>
""", parse_mode="HTML")

@bot.message_handler(commands=['memory'])
def memory_command(message):
    user_id = message.from_user.id
    # Получение пользователя из БД
    # Получение памяти пользователя
    memory = get_memory_request_with_ids_filtered(user_id)#!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    memory_markup = types.InlineKeyboardMarkup()

    for key, id_memory in memory.items():
        memory_markup.add(types.InlineKeyboardButton(key.replace("Пользователь попросил запомнить:","", 1), callback_data=f'{id_memory}'))

    # Отправляем сообщение с памятью в виде кнопок и сохраняем его ID
    sent_message = bot.send_message(message.chat.id, "Вот что мы о вас помним:", reply_markup=memory_markup)
    last_memory_message_id[user_id] = sent_message.message_id

@bot.message_handler(commands=['counters'])
def memory_command(message):
    user_id = message.from_user.id
    data = get_counters_data(user_id)

    text = 'Показатели счетчиков:\n'

    for key, value in data.items():
        if key == 'газ':
            key = 'Газ'
            if value is not None:
                text += f"{key}: {value}\n"
            else:
                text += f"{key}: Неуказанно\n"
        elif key == "ночь":
            key = 'Ночь'
            if value is not None:
                text += f"{key}: {value}\n"
            else:
                text += f"{key}: Неуказанно\n"
        elif key == "день":
            key = 'День'
            if value is not None:
                text += f"{key}: {value}\n"
            else:
                text += f"{key}: Неуказанно\n"
        elif key == "горячая_вода":
            key = 'Горячая вода'
            if value is not None:
                text += f"{key}: {value}\n"
            else:
                text += f"{key}: Неуказанно\n"
        elif key == "холодная_вода":
            key = 'Холодная вода'
            if value is not None:
                text += f"{key}: {value}\n"
            else:
                text += f"{key}: Неуказанно\n"
        elif key == "отопление":
            key = "Отопление"
            if value is not None:
                text += f"{key}: {value}\n"
            else:
                text += f"{key}: Неуказанно\n"

    bot.send_message(message.chat.id, text)