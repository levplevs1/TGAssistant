from os import path
from json import load, dump
import speech_recognition as sr
from database.load import get_user_database, add_user_database, get_memory_database, get_memory_chat_database


# Функция для загрузки данных документа
def load_document_data():
    config_file = path.join('document_data.json')
    if path.exists(config_file):
        with open(config_file, 'r', encoding="utf-8") as f:
            return load(f)
    else:
        return None

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
    """
    Находит вопрос пользователя, связанный с ответом модели.

    Args:
        user_id (int): ID пользователя.
        response (str): Ответ модели, по которому нужно найти вопрос.

    Returns:
        str: Вопрос пользователя, связанный с ответом модели.
    """
    memory_chat = get_memory_chat_database(user_id)
    memory_chat.reverse()  # Изменяем порядок на обратный

    for i in range(len(memory_chat)):
        # Проверяем совпадение ответа

        if memory_chat[i] == f'Ответ модели: {response}'[:250]:
            # Убеждаемся, что следующий элемент существует
            if i + 1 < len(memory_chat):
                return memory_chat[i + 1].replace("Запрос пользователя:", '', 1)
            else:
                print("Следующего элемента не существует для индекса:", i)
                return ''
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