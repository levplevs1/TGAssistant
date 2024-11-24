from app.bot.handlers import waiting_for_response, users_status_service
from app.bot.handlers.llm_response_handler import handle_user_message, forming_response, check_save_user_memory
from app.bot.handlers.murkup_button import send_categories
from classifier.base_classifier import get_keyboard
from utils.tokens import validate_count_tokens
from config import bot
from utils.save_load import get_last_message, recognize_speech
from pydub import AudioSegment
from os import remove
from database.load import get_user_database, get_service_type_database


# Обработка голосового сообщения
@bot.message_handler(content_types=['voice'])
def handle_voice_message(message):
    user_id = message.from_user.id
    file_info = bot.get_file(message.voice.file_id)
    downloaded_file = bot.download_file(file_info.file_path)

    # Сохраняем файл голосового сообщения в формате OGG
    ogg_file_path = f"users_voice_messages/voice_message_{user_id}.ogg"
    with open(ogg_file_path, 'wb') as f:
        f.write(downloaded_file)

    # Конвертируем OGG в WAV
    wav_file_path = f"users_voice_messages/voice_message_{user_id}.wav"
    audio = AudioSegment.from_ogg(ogg_file_path)
    audio.export(wav_file_path, format="wav")

    # Распознаем речь
    text = recognize_speech(wav_file_path)

    if text:
        print(f'Распознанный текст: {text}')
        new_message = message
        new_message.text = text

        texts(new_message)
    else:
        bot.send_message(message.chat.id, "Не удалось распознать голосовое сообщение.")

    # Удаляем файлы после обработки
    remove(ogg_file_path)
    remove(wav_file_path)

# Обработка изображения
@bot.message_handler(content_types=['photo'])
def handle_photo_and_text(message):
    print("Изображение от пользователя")

# Обработка сообщения
@bot.message_handler()
def texts(message):
    print(123)
    user_id = message.from_user.id
    user_data = get_user_database(user_id)

    if message.text == 'Вот что я умею':
        bot.send_message(message.chat.id, """
<b>Вот что я умею:</b>

Я ваш цифровой ассистент, созданный для помощи в решении вопросов, связанных с государственными услугами. Вот основные возможности:

- 🏠 <b>ЖКХ</b>: Оплата коммунальных услуг, проверка баланса, получение справок.
- 🏥 <b>Здравоохранение</b>: Запись на приём к врачу, получение информации о льготах, справках и медицинских учреждениях.
- 🎓 <b>Образование</b>: Помощь с подачей документов в учебные заведения, получение справок об обучении.
- 🚗 <b>Транспорт</b>: Регистрация транспорта, проверка штрафов, получение информации о водительских правах.
- 💳 <b>Оплата услуг</b>: Простая и быстрая оплата коммунальных и других услуг.

🔍 Используйте команду <b>/menu</b>, чтобы выбрать нужную категорию услуг.
🔢 Используйте команду /counters что бы посмотреть показания счетчиков
---

💡 <b>Примеры запросов:</b>
- "Как записаться к врачу через портал госуслуг?"
- "Оплатить электричество: день 1689, ночь 521"
- "Какие документы нужны для поступления в вуз?"
- "Оплати воду: холодная 319, горячая 501"

---

<b>Дополнительные возможности:</b>
- 💾 <b>Контекст:</b> Я помню последние 10 ваших сообщений для более точных ответов.
- 🧮 <b>Автоматическое запоминание:</b> Последние показания счётчиков сохраняются.
- 📌 <b>Запоминание по запросу:</b> Вы можете использовать команду /запомни (фраза), чтобы сохранить важную информацию.


---

Если у вас есть конкретный вопрос, просто напишите его, и я постараюсь помочь! ✨
""", parse_mode="HTML")
        return

    if user_data is None:
        print("Ошибка: не удалось загрузить конфигурацию.")
        return

    if get_service_type_database(user_id) == "":
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

    if check_save_user_memory(message) is not True:
        forming_response(message,user_data)


