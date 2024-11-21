import json
from datetime import datetime
from app.bot.handlers import users_status_service
from llm.prompt_manager import classify_query_with_llm
from config import bot

def classify_type_llm(query: str, comment_text='', retry_count=0, max_retries=3):
    try:
        # Проверка на превышение количества попыток
        if retry_count > max_retries:
            print("Превышено максимальное количество попыток. Возвращаю None.")
            return None

        # Вызов LLM для уточнения
        response_classify = classify_query_with_llm(query, comment_text)

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
        print(f"Ошибка при классификации: {e}\n Повторная попытка с комментарием для модели...")
        # Увеличение счётчика повторов
        return classify_type_llm(query, comment_text="Внимание: предыдущее описание причины было слишком большое, что вызвало ошибку. Сократи причину.", retry_count=retry_count + 1, max_retries=max_retries)

def process_callback_data(user_id, chat_id, data, classify_type):
    if classify_type is None:
        bot.send_message(chat_id, "LLM не смог получить категорию")
        return

    # Определяем категории и соответствующие проверки
    categories = {
        "газ": {
            "check": lambda d: d.get("газ") is not None,
            "fail_message": "Не удалось распознать показания газа. Напишите показания газа в кубометрах.",
            "success_message": lambda d: f"Газ\nОбъём: {int(d['газ'])} м³"
        },
        "вода": {
            "check": lambda d: d.get("холодная_вода") is not None and d.get("горячая_вода") is not None,
            "fail_message": lambda d: (
                "Не удалось распознать показания холодной воды. Напишите показания холодной воды в кубометрах."
                if not d.get("холодная_вода") else
                "Не удалось распознать показания горячей воды. Напишите показания горячей воды в кубометрах."
            ),
            "success_message": lambda d: (
                f"Вода\nГорячая вода: {int(d['горячая_вода'])} м³\nХолодная вода: {int(d['холодная_вода'])} м³"
            )
        },
        "отопление": {
            "check": lambda d: d.get("отопление") is not None,
            "fail_message": "Не удалось распознать показания отопления. Напишите показания отопления в Гкал.",
            "success_message": lambda d: f"Отопление\nТепло: {int(d['отопление'])} Гкал"
        },
        "электричество": {
            "check": lambda d: d.get("день") is not None or d.get("ночь") is not None,
            "fail_message": "Не удалось распознать показания электричества. Укажите значения для дневного или ночного тарифа в киловатт-часах.",
            "success_message": lambda d: (
                f"Электричество\nДень: {int(d.get('день', 'не указано'))} кВт⋅ч\n"
                f"Ночь: {int(d.get('ночь', 'не указано'))} кВт⋅ч"
            )
        }
    }

    # Проверяем наличие категории в данных
    category = classify_type.get("category", "unknown")
    if category not in categories:
        bot.send_message(chat_id, "Категория не распознана.")
        return

    # Получаем обработчик для категории
    category_handler = categories[category]
    check_result = category_handler["check"](classify_type["data"])
    check_error = classify_type.get("error", False)

    if not check_result or check_error:  # Если данные некорректны или есть ошибка
        fail_message = (
            category_handler["fail_message"](classify_type["data"])
            if callable(category_handler["fail_message"])
            else category_handler["fail_message"]
        )
        bot.send_message(chat_id, fail_message)
    else:  # Если данные корректны
        users_status_service.pop(user_id, None)
        bot.send_message(chat_id, category_handler["success_message"](classify_type["data"]))

def validate_response(json_response):
    """
    Проверяет валидность ответа модели по критериям финальной валидации.

    :param json_response: dict, JSON-ответ от модели для валидации.
    :return: bool, True если критических нарушений нет, иначе False.
    """
    # Проверяем наличие ключей
    required_keys = ['is_valid', 'validation']
    if not all(key in json_response for key in required_keys):
        print("Отсутствуют обязательные ключи в JSON.")
        return [False, ""]

    # Проверка критических критериев
    validation = json_response.get('validation', {})
    critical_criteria = ['language', 'profanity', 'prohibited_topics']

    for criterion in critical_criteria:
        result = validation.get(criterion, {})
        if not result.get('status', False):
            print(f"Критическое нарушение: {criterion} — {result.get('reason', 'Причина не указана')}")
            return [False, f"Критическое нарушение: {criterion} — {result.get('reason', 'Причина не указана')}"]

    # Если нет критических нарушений
    print("Критических нарушений нет. Ответ прошёл проверку.")
    return [True, ""]

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