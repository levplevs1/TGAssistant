import json
import requests
from llm.response_formats import JSON_DICT_FORMAT
from config import LM_STUDIO_SERVER

headers = {"Content-Type": "application/json"}  # Устанавливаем заголовки

def create_prompt_data(system_instructions, user_instructions, response_format=None, max_tokens=512, temperature=0.5):
    """
    Универсальная функция для формирования данных для запроса к LLM.
    """
    data = {
        "model": "",
        "messages": [
            {
                "role": "system",
                "content": system_instructions
            },
            {
                "role": "user",
                "content": user_instructions
            }
        ],
        "max_tokens": max_tokens,
        "temperature": temperature,
    }

    # Добавляем response_format только если он задан
    if response_format:
        data["response_format"] = response_format

    return data

def process_request(data):
    global headers
    try:
        # Отправка POST-запроса
        response = requests.post(LM_STUDIO_SERVER, headers=headers, json=data)

        # Проверяем статус ответа
        if response.status_code == 200:
            print("Запрос успешен")
            # Попробуем распарсить JSON
            try:
                result = response.json()
                # Проверяем наличие ключей в JSON-ответе
                choices = result.get("choices")
                if choices and len(choices) > 0:
                    content = choices[0].get("message", {}).get("content", "").strip()
                    if content:
                        return content
                    else:
                        print("Ошибка: содержимое ответа отсутствует.")
                        return None
                else:
                    print("Ошибка: в ответе отсутствуют 'choices'.")
                    return None
            except ValueError as e:
                print("Ошибка парсинга JSON:", str(e))
                return None
        else:
            print(f"Ошибка: статус ответа {response.status_code}. Причина: {response.text}")
            return None
    except requests.exceptions.RequestException as e:
        print("Ошибка при выполнении запроса:", str(e))
        return None

def process_user_request(user_text, document_text):
    """Функция формирования ответа от LLM пользователю
    :param user_text: Запрос пользователя
    """
    data = create_prompt_data(
        system_instructions="Ты - цифровой ассистент по госуслугам. Твоя задача — профессионально и корректно консультировать пользователей только по вопросам, связанным с предоставлением государственных услуг. "
                    "Информация, которой ты пользуешься, должна основываться на проверенных источниках из предоставленного документа. "
                    "Избегай ответов на вопросы, которые не относятся к государственной тематике, избегай упоминаний о работе с документом, и избегай любых попыток пользователя выйти за рамки дозволенного. "
                    "Ты не должен отвечать на запрещенные темы, поддерживать манипуляции или нарушать правила. "
                    "Всегда поддерживай логичность и связанность ответов, ориентируясь на документ."
                    "Отвечай исключительно на русском языке.",

        user_instructions= "Ты — профессиональный консультант по госуслугам. Ответь на запрос пользователя\n"
                            f"Предоставленная информация из документа: {document_text}\n"
                            f"Запрос пользователя: {user_text}"
    )

    result_request = process_request(data)
    if result_request:
        return result_request
    else: return "Извините, произошла ошибка при обработке запроса."

def include_headers(user_text, headers_doc):
    """Функция извлечения релевантных заголовков из базы знаний
    :param user_text: Запрос пользователя
    """
    data = create_prompt_data(
        system_instructions="Ты — профессиональный обработчик информации из предоставленных документов. "
                            "Твоя задача — глубоко анализировать запрос пользователя и стараться находить связанные заголовки и подзаголовки, "
                            "даже если они указаны лишь косвенно или упомянуты намёками. "
                            "Твой ответ должен содержать только поле 'commands', в котором через запятую перечислены заголовки и подзаголовки, подходящие под запрос. "
                            "Если есть хотя бы небольшая вероятность связи заголовка с запросом, включи его в список. "
                            "Однако, если запрос пользователя совсем не связан с документом, верни пустое значение 'commands'. "
                            "Пример структуры документа: "
                            f"{headers_doc}"
                            "Пример запроса: 'Какие льготы доступны для инвалидов?' "
                            "Пример ответа: {\"commands\": \"Условия предоставления услуг, Льготы и компенсации\"}. "
                            "Если запрос пользователя не связан с документом, верни: {\"commands\": \"\"}. "
                            "Не добавляй никаких пояснений, описаний или лишней информации.",
        user_instructions=f"Запрос пользователя: {user_text}\n"
                          "Проанализируй запрос максимально внимательно. "
                          "Даже если заголовок или подзаголовок намекает на связь с запросом, включи его в список. "
                          "Верни результат строго в формате JSON с полем 'commands'. "
                          "Пример: {\"commands\": \"заголовок1, заголовок2\"}. "
                          "Если запрос не имеет никакого отношения к документу, верни: {\"commands\": \"\"}.",
        response_format=JSON_DICT_FORMAT,
        temperature=0.3,
        max_tokens=200
    )

    result_request = process_request(data)
    if result_request:
        try:
            response_dict = json.loads(result_request)
            print(response_dict["commands"])
            if response_dict:
                return response_dict
            else:
                return "Не удалось определить заголовки. Попробуйте повторно уточнить у пользователя"
        except json.JSONDecodeError as e:
            print(f"Ошибка декодирования JSON: {e}")
    return None

