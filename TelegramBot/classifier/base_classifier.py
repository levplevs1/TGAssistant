import json
from datetime import datetime
import spacy
from llm.prompt_manager import classify_query_with_llm

# Загружаем русскую модель
nlp = spacy.load("ru_core_news_md")

def classify_is_type(query: str):
    """
    Классифицирует запрос как информационный или запрос услуги.
    Сохраняет статистику выполнения.
    """
    try:
        # Пример обработки текста
        doc = nlp(query)
        for token in doc:
            print(token.text, token.lemma_, token.pos_, token.dep_)

        # Извлекаем ключевые элементы
        action = [token.text for token in doc if token.dep_ == "ROOT"]
        obj = [token.text for token in doc if token.dep_ == "obj"]
        modifiers = [token.text for token in doc if token.dep_ == "nmod"]
        is_question = any(token.text == "?" for token in doc)
        question_adv = [token.text for token in doc if token.pos_ == "ADV"]

        print("Действие:", action)
        print("Объект:", obj)
        print("Модификаторы:", modifiers)
        print("Это вопрос?", is_question)
        print("Вопросительное слово:", question_adv)

        # Проверка на повелительные глаголы
        imperative_verbs = [
            token.text
            for token in doc
            if token.pos_ == "VERB" and token.morph.get("Mood") == ["Imp"]
        ]

        # Если не распознано как повелительное, дополнительно проверяем ADV и ROOT
        if not imperative_verbs:
            for token in doc:
                if token.pos_ == "ADV" and token.dep_ == "amod" and token.lemma_ in {"оплатить", "заплатить"}:
                    imperative_verbs.append(token.text)

        print("Повелительные глаголы:", imperative_verbs)

        # Классификация
        if is_question or question_adv:
            # Если это повелительное наклонение, то это услуга
            if imperative_verbs:
                result = {
                    "query": query,
                    "classification": "услуга",
                    "method": "малая модель",
                    "details": {
                        "action": action,
                        "object": obj,
                        "modifiers": modifiers,
                        "imperative_verbs": imperative_verbs,
                    },
                }
                save_to_json(result)
                print("\nКлассификатор: услуга (на основе повелительного глагола)")
                return True
            else:
                result = {
                    "query": query,
                    "classification": "вопрос",
                    "method": "малая модель",
                    "details": {
                        "action": action,
                        "object": obj,
                        "modifiers": modifiers,
                        "question_adv": question_adv,
                    },
                }
                save_to_json(result)
                print("\nКлассификатор: вопрос")
                return False

        else:
            print("\nКлассификатор: предположительно услуга. Анализ LLM...")

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
