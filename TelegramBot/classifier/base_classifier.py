import json
from datetime import datetime
from llm.prompt_manager import classify_query_with_llm

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
