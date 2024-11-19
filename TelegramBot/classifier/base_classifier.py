import json
from datetime import datetime

from app.bot.handlers import users_status_service
from llm.prompt_manager import classify_query_with_llm
from config import bot

def classify_type_llm(query: str):
    try:
        # Вызов LLM для уточнения
        response_classify = classify_query_with_llm(query)

        # Проверка результата LLM
        if response_classify:
            query_type = response_classify.get("query_type", "неизвестно")
            print(query_type)

            result = {
                "query": query,
                "classification": query_type,
                "method": "LLM",
                "details": response_classify,
            }
            save_to_json(result)

            if query_type == "услуга":
                print("\nКлассификатор: услуга")
                return True
            elif query_type == "вопрос":
                print("\nКлассификатор: вопрос")
                return False
            else:
                print("Классификатор: неопределенный")
                return None
        else:
            print("LLM не смог классифицировать запрос.")
            return False

    except Exception as e:
        print(f"Ошибка при классификации: {e}")
    return False

def save_to_json(data):
    """
    Сохраняет результаты в JSON файл.
    """
    filename = "classification_results.json"
    timestamp = datetime.now().isoformat()

    # Добавляем timestamp в данные
    data["timestamp"] = timestamp

    try:
        # Читаем существующий файл
        with open(filename, "r", encoding="utf-8") as file:
            results = json.load(file)
    except (FileNotFoundError, json.JSONDecodeError):
        results = []

    # Добавляем новый результат
    results.append(data)

    # Сохраняем файл
    with open(filename, "w", encoding="utf-8") as file:
        json.dump(results, file, ensure_ascii=False, indent=4)

def process_callback_data(user_id, chat_id, data, classify_type):
    if classify_type is None:
        bot.send_message(chat_id, "LLM не смог получить категорию")
        return

    # Словарь с категориями и обработчиками
    categories = {

        "газ": {
            "check": lambda data: data.get("объём"),
            "fail_message": "Не удалось распознать показания газа. Напишите показания газа в кубометрах",
            "success_message": lambda data: f"Газ\nОбъем: {data['объём']}"
        },

        "вода": {
            "check": lambda data: data.get("холодная_вода") and data.get("горячая_вода"),
            "fail_message": lambda data: (
                "Не удалось распознать показания холодной воды. Напишите показания холодной воды в кубометрах"
                if not data.get("холодная_вода") else
                "Не удалось распознать показания горячей воды. Напишите показания горячей воды в кубометрах"
            ),
            "success_message": lambda data: f"Вода\nГорячая: {data['горячая_вода']}\nХолодная: {data['холодная_вода']}"
        },

        "отопление": {
            "check": lambda data: data.get("тепло"),
            "fail_message": "Не удалось распознать показания отопления. Напишите показания отопления в Гкал",
            "success_message": lambda data: f"Отопление\nТепло: {data['тепло']}"
        },

        "электричество": {
            "check": lambda data: data.get("день"),
            "fail_message": "Не удалось распознать показания электричества. Напишите показания электричества в киловатт-часах",
            "success_message": lambda data: f"Электричество\nДень: {data['день']}"
        }
    }

    # Проверяем, есть ли обработчик для данной категории
    if data in categories:
        category = categories[data]
        check_result = category["check"](classify_type["data"])

        if not check_result:  # Если данные не прошли проверку
            fail_message = (
                category["fail_message"](classify_type["data"])
                if callable(category["fail_message"])
                else category["fail_message"]
            )
            bot.send_message(chat_id, fail_message)
        else:  # Если данные валидны
            users_status_service.pop(user_id, None)
            bot.send_message(chat_id, category["success_message"](classify_type["data"]))
