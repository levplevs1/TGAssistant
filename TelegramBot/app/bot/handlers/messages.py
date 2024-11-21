from app.bot.handlers import waiting_for_response, users_status_service
from app.bot.handlers.llm_response_handler import handle_user_message, forming_response, check_save_user_memory
from app.bot.handlers.murkup_button import send_categories
from classifier.base_classifier import get_keyboard
from utils.tokens import validate_count_tokens
from config import bot
from utils.save_load import load_user_data, get_last_message

# Обработка голосового сообщения
@bot.message_handler(content_types=['voice'])
def handle_voice_message(message):
    print("Голосовое сообщение")

# Обработка изображения
@bot.message_handler(content_types=['photo'])
def handle_photo_and_text(message):
    print("Изображение от пользователя")

# Обработка сообщения
@bot.message_handler()
def texts(message):
    print(123)
    user_id = message.from_user.id
    user_data = load_user_data(user_id)

    if user_data is None:
        print("Ошибка: не удалось загрузить конфигурацию.")
        return

    if user_data["category_dialog"] == "":
        send_categories(message)
        return

    # Проверяем оказывается ли услуга пользователю
    if users_status_service.get(user_id, False):
        bot.send_message(message.chat.id, "Производится оказание услуги")
        handle_user_message(message, user_data)
        return

    # Проверяем, ожидает ли пользователь ответа
    if waiting_for_response.get(user_id, False):
        bot.send_message(message.chat.id, "Пожалуйста, подождите, пока я обработаю ваш предыдущий запрос.")
        return

    if message.text == "🔄Изменить ответ":
        last_message = get_last_message(user_id)
        message_copy = message
        message_copy.text = last_message
        forming_response(message_copy, user_data)
        return
    elif message.text == "❔Ещё варианты":
        keyboard = get_keyboard(user_id)
        bot.send_message(message.chat.id, "Вот ещё варианты" , reply_markup=keyboard)
        return

    if validate_count_tokens(message.text, 500):
        bot.send_message(message.chat.id, "Ваше сообщение слишком большое")
        return

    check_save_user_memory(message, user_data)

    forming_response(message,user_data)


