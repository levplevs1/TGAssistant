from os import path
from json import load, dump
import speech_recognition as sr
from database.load import get_user_database, add_user_database, get_memory_database


# Функция для загрузки данных документа
def load_document_data():
    config_file = path.join('document_data.json')
    if path.exists(config_file):
        with open(config_file, 'r', encoding="utf-8") as f:
            return load(f)
    else:
        return None


def save_category_dialog(user_id, category_dialog):
    user_data = get_user_database(user_id)
    user_data["category_dialog"] = category_dialog
    add_user_database(user_id, user_data)

def save_memory_chat(message, answer):
    memory_chat = get_user_database(message.from_user.id)
    if len(memory_chat["memory_chat"]) > 18:
        memory_chat["memory_chat"].pop(0)
        memory_chat["memory_chat"].pop(0)

    memory_chat["memory_chat"].append(message.text)
    memory_chat["memory_chat"].append(answer)
    add_user_database(message.from_user.id, memory_chat)

def get_document():
    config_file = path.join('document_data.json')
    if path.exists(config_file):
        with open(config_file, 'r', encoding="utf-8") as f:
            return load(f)
    else:
        return None

def get_last_message(user_id):
    """
        Загружает текущую память пользователя из конфига и передает её в виде строки для использования в промпте.

        :param user_id: Идентификатор пользователя
        :return: Строка памяти для передачи в промпт
        """

    memory_chat = get_memory_database(user_id)
    memory_chat.reverse()  # Изменяем список

    for i in range(len(memory_chat)):
        if i % 2 != 0:
            if memory_chat[i] != "Ещё варианты" and memory_chat[i] != "Изменить ответ":
                return memory_chat[i]
    return None

def search_query_by_response(user_id, response):

    user_data = get_user_database(user_id)
    memory_chat = user_data["memory_chat"]
    memory_chat.reverse()  # Изменяем список

    for i in range(len(memory_chat)):
        if i % 2 == 0:
            if memory_chat[i] == response:
                return memory_chat[i+1]
    return ''

def recognize_speech(audio_path):
    recognizer = sr.Recognizer()
    try:
        with sr.AudioFile(audio_path) as source:
            audio = recognizer.record(source)
        text = recognizer.recognize_google(audio, language="ru-RU")  # Преобразуем в текст
        print(f"Recognized: {text}")
        return text.lower()
    except sr.UnknownValueError:
        print("Could not understand audio")
        return None
    except sr.RequestError:
        print("Could not request results from Google Speech Recognition service")
        return None