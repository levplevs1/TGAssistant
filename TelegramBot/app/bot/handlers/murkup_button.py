from app.bot.handlers.llm_response_handler import forming_response
from classifier.base_classifier import process_callback_data
from config import bot
from telebot.types import InlineKeyboardMarkup, InlineKeyboardButton
from app.bot.handlers import users_status_service, waiting_for_response, last_memory_message_id
from utils.save_load import save_category_dialog, search_query_by_response, load_user_data, save_user_data


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
        bot.edit_message_text(chat_id=call.message.chat.id, message_id=call.message.message_id, text="Напишите:\nОплати (то что вам нужно оплатить): показания с счетчика - (показания со счетчика горячей воды)")
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
        if waiting_for_response[call.from_user.id] == False:
            forming_response(message_copy, load_user_data(call.from_user.id))
        else:
            bot.send_message(call.message.chat.id, "Пожалуйста, подождите, пока я обработаю ваш предыдущий запрос.")
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
        bot.edit_message_reply_markup(chat_id=call.message.chat.id, message_id=call.message.message_id, reply_markup=None)
    elif call.data == 'отправить':
        user_service = users_status_service.get(call.from_user.id, None)

        if user_service is None:
            bot.send_message(call.message.chat.id, "Произошла ошибка при заполнении услуги")
            return

        stub(call.message.chat.id, user_service, call.from_user.id)
        bot.edit_message_reply_markup(chat_id=call.message.chat.id, message_id=call.message.message_id, reply_markup=None)
    else:
        user_data = load_user_data(call.from_user.id)
        memory = user_data.get('memory', [])
        try:
            index_to_delete = int(call.data)
        except Exception as e:
            print(f"Ошибка преобразование в int: {e}")
            return

        user_id = call.from_user.id
        user_data = load_user_data(user_id)

        if user_data is None:
            bot.send_message(call.message.chat.id, "Ошибка: не удалось загрузить конфигурацию.")
            return

        # Проверяем, что сообщение, с которого удаляется память, совпадает с последним сообщением с памятью
        if call.message.message_id != last_memory_message_id.get(user_id):
            bot.send_message(call.message.chat.id,
                             "Вы можете удалять память только из последнего вызванного сообщения.")
            return

        if 0 <= index_to_delete < len(memory):
            memory.pop(index_to_delete)  # Удаляем элемент по индексу
            user_data['memory'] = memory  # Обновляем память в данных пользователя
            save_user_data(user_id, user_data)  # Сохраняем изменения

            # Пересоздаем кнопки после удаления элемента
            memory_markup = InlineKeyboardMarkup()
            count = 0
            for el in memory:
                memory_markup.add(InlineKeyboardButton(el, callback_data=f'{count}'))
                count += 1

            # Обновляем сообщение с новыми кнопками
            bot.edit_message_text("Вот что мы о вас помним:", chat_id=call.message.chat.id,
                                  message_id=call.message.message_id, reply_markup=memory_markup)


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




