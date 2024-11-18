from config import bot
from telebot.types import InlineKeyboardMarkup, InlineKeyboardButton, ReplyKeyboardMarkup, KeyboardButton

from llm.prompt_manager import get_variants_questions_llm
from utils.save_load import save_category_dialog, get_last_message


# Команда для отображения кнопок
@bot.message_handler(commands=["menu"])
def send_categories(message):
    # Создаем клавиатуру с кнопками
    markup = InlineKeyboardMarkup()

    markup.add(InlineKeyboardButton("ЖКХ", callback_data="ЖКХ")),
    markup.add(InlineKeyboardButton("Здравоохранение", callback_data="Здравоохранение"))
    markup.add(InlineKeyboardButton("Образование", callback_data="Образование"))
    markup.add(InlineKeyboardButton("Транспорт", callback_data="Транспорт"))

    # Отправляем сообщение с кнопками
    bot.send_message(message.chat.id, "Выберите категорию:", reply_markup=markup)


# Обработка нажатий кнопок
@bot.callback_query_handler(func=lambda call: True)
def handle_callback(call):
    # Обработка категорий
    if call.data == "ЖКХ":
        save_category_dialog(call.from_user.id, call.data)
        bot.send_message(call.message.chat.id, "Вы выбрали категорию: ЖКХ")
    elif call.data == "Здравоохранение":
        save_category_dialog(call.from_user.id, call.data)
        bot.send_message(call.message.chat.id, "Вы выбрали категорию: Здравоохранение")
    elif call.data == "Образование":
        save_category_dialog(call.from_user.id, call.data)
        bot.send_message(call.message.chat.id, "Вы выбрали категорию: Образование")
    elif call.data == "Транспорт":
        save_category_dialog(call.from_user.id, call.data)
        bot.send_message(call.message.chat.id, "Вы выбрали категорию: Транспорт")

def get_keyboard(user_id):
    keyboard = ReplyKeyboardMarkup(resize_keyboard=True, one_time_keyboard=True)

    last_message = get_last_message(user_id)
    variants = get_variants_questions_llm(last_message)

    # Добавляем кнопки
    button1 = KeyboardButton(variants[0])
    button2 = KeyboardButton(variants[1])
    button3 = KeyboardButton(variants[2])
    button4 = KeyboardButton("❔Ещё варианты")
    button5 = KeyboardButton("🔄Изменить ответ")

    # Добавляем кнопки в клавиатуру
    keyboard.add(button4, button5)
    keyboard.add(button1)
    keyboard.add(button2)
    keyboard.add(button3)

    return keyboard


