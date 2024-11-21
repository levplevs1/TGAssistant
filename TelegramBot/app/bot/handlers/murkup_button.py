from app.bot.handlers.llm_response_handler import forming_response
from classifier.base_classifier import process_callback_data
from config import bot
from telebot.types import InlineKeyboardMarkup, InlineKeyboardButton
from app.bot.handlers import users_status_service
from utils.save_load import save_category_dialog, get_last_message, search_query_by_response, load_user_data


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
    if call.data == "Оплатить счетчики":
        markup = get_markup_counters()
        bot.edit_message_text(chat_id=call.message.chat.id, message_id=call.message.message_id,
                              text="Какой счетчик вы хотите оплатить?", reply_markup=markup)
    elif call.data == 'выбрать действие':
        markup = get_markup_like_dislike_change()
        bot.edit_message_reply_markup(chat_id=call.message.chat.id, message_id=call.message.message_id, reply_markup=markup)
    elif call.data == 'change':
        last_message = search_query_by_response(user_id=call.from_user.id, response=call.message.text)

        class Message:
            def __init__(self, data):
                # Рекурсивно преобразуем словари в объекты
                for key, value in data.items():
                    if isinstance(value, dict):
                        setattr(self, key, Message(value))
                    else:
                        setattr(self, key, value)

        message_copy = {
                        "is_copy": True,
                        "message_id": int,
                        "from_user": {
                            "id": call.from_user.id,
                        },
                        "chat": {
                            "id": call.message.chat.id,
                        },
                        "text": last_message,
                    }
        message_copy = Message(message_copy)
        forming_response(message_copy, load_user_data(call.from_user.id))
    elif call.data == 'like':
        print('like')
    elif call.data == 'dislike':
        print('dislike')
    elif call.data == "ЖКХ":
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
    elif any(word in call.data for word in ['газ', 'вода', 'отопление', 'электричество']):
        process_callback_data(call.from_user.id, call.message.chat.id, call.data, None)
    elif call.data == 'не отправлять':
        bot.edit_message_reply_markup(chat_id=call.message.chat.id, message_id=call.message.message_id,
                                      reply_markup=None)
    elif call.data == 'отправить':

        user_service = users_status_service.get(call.from_user.id, None)

        if user_service is None:
            bot.send_message(call.message.chat.id, "Произошла ошибка при заполнении услуги")
            return

        stub(call.message.chat.id, user_service, call.from_user.id)
        bot.edit_message_reply_markup(chat_id=call.message.chat.id, message_id=call.message.message_id,
                                      reply_markup=None)
def stub(chat_id, user_service, user_id):
    bot.send_message(chat_id, f"Оплачен счетчик: {user_service.get('category', None)}")
    users_status_service.pop(user_id)

def get_markup_like_dislike_change():
    markup = InlineKeyboardMarkup()

    like = InlineKeyboardButton('👍', callback_data='like')
    dislike = InlineKeyboardButton('👎', callback_data='dislike')
    change = InlineKeyboardButton('🔄Изменить ответ', callback_data='change')


    markup.add(like, dislike)
    markup.add(change)

    return markup

def get_markup_counters():

    markup = InlineKeyboardMarkup()

    markup.add(InlineKeyboardButton("Газ", callback_data="газ")),
    markup.add(InlineKeyboardButton("Вода", callback_data="вода"))
    markup.add(InlineKeyboardButton("Отопление", callback_data="отопление"))
    markup.add(InlineKeyboardButton("Электричество", callback_data="электричество"))
    return markup



