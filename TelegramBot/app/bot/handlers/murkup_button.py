from config import bot
from telebot.types import InlineKeyboardMarkup, InlineKeyboardButton
from utils.save_load import save_category_dialog

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


