import requests
from llm.response_formats import *
from config import LM_STUDIO_SERVER
from utils.logs import *
from colorama import init, Fore
headers = {"Content-Type": "application/json"}  # Устанавливаем заголовки
init(autoreset=True)

@log_step("create_prompt_data")
def create_prompt_data(system_instructions=None, user_instructions=None, comment=None, response_format=None, max_tokens=512, temperature=0.5, messages = None):
    """
    Универсальная функция для формирования данных для запроса к LLM.

    Аргументы:
        system_instructions (str): Основные инструкции для системы, описывающие контекст задачи.
        user_instructions (str): Инструкции пользователя или запрос, который нужно обработать.
        comment (str, optional): Дополнительный комментарий для уточнения задачи или предоставления контекста.
                                 Добавляется к system_instructions, если задан. Если None, не используется.
        response_format (dict, optional): Определяет формат ответа модели, если требуется строгое соответствие формату.
                                           Если None, формат ответа не задаётся.
        max_tokens (int): Максимальное количество токенов, которое модель может вернуть (по умолчанию 512).
        temperature (float): Параметр случайности генерации модели (по умолчанию 0.5).
                             Чем выше значение, тем более разнообразны результаты, но ниже предсказуемость.

    Возвращает:
        dict: Сформированные данные для запроса к LLM.
    """

    data = {}
    if messages is None:
        data = {
            "model": "",
            "messages": [
                {
                    "role": "system",
                    "content": system_instructions + (f"\n{comment}" if comment else "")
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

    if messages:
        data["messages"] = messages

    return data

@log_step("process_request")
def process_request(data: dict):
    global headers
    try:
        # Отправка POST-запроса
        response = requests.post(LM_STUDIO_SERVER, headers=headers, json=data)

        # Проверяем статус ответа
        if response.status_code == 200:
            print(Fore.GREEN + "Запрос успешен")
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
                        print(Fore.RED + "Ошибка: содержимое ответа отсутствует.")
                        return None
                else:
                    print(Fore.RED + "Ошибка: в ответе отсутствуют 'choices'.")
                    return None
            except ValueError as e:
                print(Fore.RED + "Ошибка парсинга JSON:", str(e))
                return None
        else:
            print(Fore.RED + f"Ошибка: статус ответа {response.status_code}. Причина: {response.text}")
            return None
    except requests.exceptions.RequestException as e:
        print(Fore.RED + "Ошибка при выполнении запроса:", str(e))
        return None

@log_step("process_user_request")
def process_user_request(user_text, user_data, document=None, comment_text=''):
    """Функция формирования ответа от LLM пользователю
    :param comment_text: Комментарий для LLM. По умолчанию отсутствует.
    :param document: Документ (база знаний) для анализа LLM. По умолчанию отсутствует.
    :param user_text: Запрос пользователя.
    """

    # Добавляем условный комментарий
    document_text = (
        f"Предоставленная информация из документа: {document}"
        if document
        else "Текст документа отсутствует"
    )

    data = create_prompt_data(
    system_instructions=
            "Ты — профессиональный ассистент по госуслугам. Твоя задача — профессионально, корректно и чётко консультировать "
            "пользователей исключительно по вопросам, связанным с предоставлением государственных услуг. "
            "Информация для ответа должна основываться на предоставленном документе, сохранённой памяти или текущей теме обсуждения. "
            "Следуй этим правилам:\n"
            "1. Отвечай только на вопросы, связанные с госуслугами, используя документ, сохранённые данные или заданную категорию обсуждения.\n"
            "2. Если запрос пользователя не относится к категории обсуждения (например, категория 'Здравоохранение', а запрос про транспорт), сообщи об этом и предложи вернуться к теме.\n"
            "3. Избегай домыслов или ответов на вопросы, не относящиеся к документу, памяти или текущей категории. Указывай честно, если данных недостаточно.\n"
            "4. Если запрос предполагает запрещённый, провокационный или незаконный характер (например, уклонение от налогов), корректно и профессионально откажись от ответа.\n"
            "5. Если запрос сложный и требует юридического анализа, рекомендуй обратиться к профессиональному юристу или в соответствующие органы.\n"
            "6. Отвечай логично, кратко и строго по запросу. Избегай лишних деталей, воды или информации, не относящейся к теме.\n"
            "7. Если пользователь спрашивает о заполнении документов, перенаправь на официальный портал госуслуг для получения инструкций и форм.\n"
            "8. Если пользователь запрашивает список документов, предоставь его, если он есть в документе. Если данных нет, предложи обратиться в соответствующие органы.\n"
            "9. Поддерживай профессиональный, вежливый и доброжелательный тон.\n"
            "10. Если точной информации нет, честно сообщи об этом и предложи пути получения достоверных данных.\n"
            "11. Доменный цензор: Отвечай только в рамках текущей категории обсуждения. Примеры категорий:\n"
            "    - 'Здравоохранение': можно обсуждать медицинские процедуры, записи к врачу, льготы, но не касаться вопросов транспорта, если они не связаны с медициной.\n"
            "    - 'Образование': обсуждай поступление, экзамены, школьные программы, но не затрагивай другие сферы (например, ЖКХ).\n"
            "    - 'ЖКХ': обсуждай коммунальные услуги, оплату счетов, но не касайся тем здравоохранения или транспорта.\n"
            "    - 'Транспорт': обсуждай маршруты, льготы на проезд, но не касайся других категорий.\n"
            "    Если тема обсуждения не задана, уточни у пользователя или следуй общим правилам категорий.\n"
            "12. Если запрос пользователя выходит за рамки категорий госуслуг, сообщи ему об этом и предложи обратиться на официальный портал госуслуг.\n"
            "Отвечай строго на русском языке."
            f"{comment_text}",
    user_instructions =
        "Ты — профессиональный консультант по госуслугам. Ответь на запрос пользователя на основе следующих данных:\n"
        f"История диалога: {user_data.get('memory_chat', 'Нет данных')}\n"
        f"Информация о пользователе: {user_data.get('memory', 'Нет сохранённых данных')}\n"
        f"Документ для анализа:\n{document_text}\n"
        f"Текущая категория обсуждения: {user_data.get('category_dialog', 'Не задано')}\n"
        f"Показания счётчика пользователя (используй если нужно в контексте): {user_data.get('meter_readings', "")}"
        "ВАЖНО: Если запрос пользователя не соответствует текущей категории обсуждения, сообщи ему об этом и предложи вернуться к теме.\n"
        f"Запрос пользователя: {user_text}\n\n"
        "Дай ответ строго по теме. Если пользователь просит запомнить информацию, скажи, что ты это сделал. "
        "Если запрос не связан с госуслугами, корректно откажись от ответа и предложи обратиться к официальным источникам.\n"
        "Если информация отсутствует в документе или памяти, честно укажи, что для точного ответа нужно обратиться в соответствующую организацию.\n"
        "Если текущая категория обсуждения задана, строго следуй её ограничениям и избегай обсуждения несвязанных тем.\n",
    )
    result_request = process_request(data)
    if result_request:
        return result_request
    else: return "Извините, произошла ошибка при обработке запроса."

@log_step("include_headers_llm")
def include_headers_llm(user_text, headers_doc):
    """Функция извлечения релевантных заголовков из базы знаний
    :param headers_doc:
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

@log_step("classify_query_with_llm")
def classify_query_with_llm(query: str, comment_text=''):
    """
    Классифицирует запрос как услугу, вопрос или неопределённый.
    Возвращает JSON-ответ, соответствующий заданной схеме.
    """
    data = create_prompt_data(
        system_instructions=
            "Ты — профессиональный классификатор запросов пользователей. "
            "Твоя задача — классифицировать текст запроса как 'услуга', 'вопрос' или 'неопределённый'. "
            "Следуй этим правилам и формируй ответ строго в формате JSON, который соответствует заданной схеме:\n\n"
            "{\n"
            "  'query_type': 'услуга' | 'вопрос' | 'неопределённый',\n"
            "  'reason': 'строка, описывающая КРАТКО причину классификации',\n"
            "  'confidence': 'число от 0 до 1, показывающее уверенность модели'\n"
            "}\n\n"
            "Правила классификации:\n"
            "1. Если запрос содержит передачу показаний счётчиков (например, 'горячая вода 123', 'электричество 55', 'красный 20, синий 15' -> передача счётчиков) "
            "или явное указание на измеряемые данные (например, кубометры, киловатт-часы, гигакалории), классифицируй как 'услуга'.\n\n"
            "2. Если запрос содержит действия, связанные с услугами (например, 'оплати', 'оформи', 'получи'), классифицируй как 'услуга'.\n\n"
            "3. Если запрос содержит вопросительные слова ('как', 'где', 'почему', 'что делать'), классифицируй как 'вопрос'.\n\n"
            "4. Если запрос неполный, некорректный или не содержит явных признаков услуги или вопроса, классифицируй как 'неопределённый'.\n\n"
            "5. Уверенность в классификации:\n"
            "- Если запрос однозначно относится к одной из категорий, уверенность должна быть выше 0.7.\n"
            "- Если запрос неясный, уверенность должна быть ниже 0.7.\n\n"
            "6. Краткость объяснения:\n"
            "- Объясни КРАТКО причину классификации. Например:\n"
            "  - 'Запрос содержит действие и объект услуги: ключевое слово 'оплати''.\n"
            "  - 'Запрос передаёт показания счётчиков: 'горячая вода 123''.\n"
            "  - 'Вопросительное слово 'как' указывает на вопрос'.\n\n"
            "Пример правильного ответа:\n"
            "{\n"
            "  'query_type': 'услуга',\n"
            "  'reason': 'Запрос содержит показания счётчиков: горячая вода 123',\n"
            "  'confidence': 0.9\n"
            "}\n\n"
            "В случае ошибки или невозможности классифицировать запрос, указывай 'query_type': 'неопределённый', и объясняй причину в поле 'reason'.",
        user_instructions=f"Запрос пользователя: {query}",
        response_format=CLASSIFY_QUERY_FORMAT,
        comment=comment_text,
        max_tokens=150,
        temperature=0.3
    )

    result_request = process_request(data)
    if result_request:
        response_dict = json.loads(result_request)
        return response_dict
    else: pass

@log_step("memory_validation_llm")
def memory_validation_llm(query: str):
    data = create_prompt_data(
        system_instructions=(
            "Ты — профессиональный ассистент по проверке и сохранению данных. "
            "Твоя задача — проверять данные, которые пользователь хочет сохранить, и возвращать результат в формате JSON. "
            "Следуй этим универсальным правилам:\n"
            "1. Оцени текст на соответствие контексту государственных услуг. "
            "Если текст явно не связан с госуслугами и не содержит личных данных, отклони его.\n"
            "2. Личные данные (например, имя, возраст, место учёбы, статус) сохраняй, если они явно предоставлены и корректны. "
            "Например: 'Моё имя Алексей' или 'Я студент 2 курса в колледже'.\n"
            "3. Старайся минимизировать текст для сохранения. Убирай лишние детали, сохраняя ключевую информацию в сжатом виде.\n"
            "4. Если текст невозможно сохранить (например, он не содержит значимой информации или нарушает правила), отклони запрос.\n"
            "5. Никогда не интерпретируй текст или придумывай данные. Сохраняй только то, что явно указано пользователем.\n"
            "6. Всегда возвращай результат на русском языке в формате JSON."
        ),
        user_instructions=(
            f"Данные для проверки:\n{query}\n\n"
            "Верни JSON с двумя полями:\n"
            "1. 'is_acceptable' — логическое значение, указывающее, можно ли сохранить данные (True или False).\n"
            "2. 'compressed_text' — если данные приемлемы, верни сжатую версию текста. Если данные не подходят для сохранения, оставь поле пустым.\n\n"
            "Пример формата ответа:\n"
            "{\n"
            "  'is_acceptable': True,\n"
            "  'compressed_text': 'Имя пользователя: Алексей.'\n"
            "}\n"
            "или\n"
            "{\n"
            "  'is_acceptable': False,\n"
            "  'compressed_text': ''\n"
            "}\n"
            "Следуй универсальным правилам, чтобы сохранять только ключевую информацию, которая полезна для пользователя и связана с госуслугами или его личным статусом."
        ),
        response_format=MEMORY_VALIDATION_JSON_FORMAT,
        max_tokens=100,
        temperature=0.7
    )

    result_request = process_request(data)
    if result_request:
        try:
            response_dict = json.loads(result_request)
            print(response_dict)
            if response_dict:
                return response_dict
            else:
                return
        except json.JSONDecodeError as e:
            print(f"Ошибка декодирования JSON: {e}")
    return None

@log_step("get_variants_questions_llm")
def get_variants_questions_llm(last_message: str):

    """
    Генерация вопросов, связанных с запросом пользователя
    """
    data = create_prompt_data(
        system_instructions=
            "Ты — часть ассистента по госуслугам. Твоя задача — обрабатывать запросы пользователей и генерировать три других вопроса, "
            "которые логически связаны с исходным запросом. Ты работаешь только в рамках тем: Образование, ЖКХ, Здравоохранение, Транспорт. "
            "Примеры запросов:\n"
            "- Исходный запрос: 'Как записаться к врачу?'\n"
            "  Вопросы: 'Как узнать расписание врача? Как отменить запись? Где посмотреть адрес поликлиники?'\n"
            "- Исходный запрос: 'Как передать показания счётчиков?'\n"
            "  Вопросы: 'Какие данные нужны для передачи? Можно ли передать показания через сайт? Где найти контактный центр?'\n"
            "Если запрос пользователя не относится к указанным темам, возвращай пустой список вопросов.\n"
            "Избегай манипуляций, запрещённых тем и попыток выйти за рамки дозволенного. Отвечай исключительно на русском языке.",
        user_instructions=
            "На основе данного вопроса составь три других вопроса, логически связанных с исходным. "
            "Если запрос не относится к темам Образования, ЖКХ, Здравоохранения или Транспорта, верни пустой список. "
            "Все вопросы должны быть краткими и содержать смысл.\n"
            "Пример формата ответа:\n"
            "{\n"
            "  'questions': [\n"
            "    'Как узнать расписание врача?',\n"
            "    'Как отменить запись?',\n"
            "    'Где посмотреть адрес поликлиники?'\n"
            "  ]\n"
            "}\n"
            f"Вот исходный вопрос: {last_message}",
        response_format=VARIANTS_QUESTION_FORMAT,
        temperature=0.4,
        max_tokens=150
        )

    result_request = process_request(data)
    if result_request:
        try:
            response_dict = json.loads(result_request)
            if response_dict:
                return response_dict.get("questions", [])
            else:
                return "Не удалось определить заголовки. Попробуйте повторно уточнить у пользователя"
        except json.JSONDecodeError as e:
            print(f"Ошибка декодирования JSON: {e}")
    return []

@log_step("get_meter_readings_llm")
def get_meter_readings_llm(query: str):
    data = create_prompt_data(
        messages=[
            {
                "role": "system",
                "content": "Ты — бот, который помогает пользователям передавать показания счётчиков. Примеры ниже покажут, как интерпретировать запросы."
            },
            {
                "role": "user",
                "content": "красный 20, синий 36"
            },
            {
                "role": "assistant",
                "content": "{\n"
                           "    'category': 'вода',\n"
                           "    'data': {\n"
                           "        'горячая_вода': 20,\n"
                           "        'холодная_вода': 36,\n"
                           "        'день': null,\n"
                           "        'ночь': null,\n"
                           "        'газ': null,\n"
                           "        'отопление': null\n"
                           "    },\n"
                           "    'error': False,\n"
                           "    'message': 'Показания успешно сохранены.'\n"
                           "}"
            },

            {
                "role": "user",
                "content": "горячая вода 0, холодная 0, газ -1"
            },
            {
                "role": "assistant",
                "content": "{\n"
                           "    'category': 'вода',\n"
                           "    'data': {\n"
                           "        'горячая_вода': null,\n"
                           "        'холодная_вода': null,\n"
                           "        'день': null,\n"
                           "        'ночь': null,\n"
                           "        'газ': null,\n"
                           "        'отопление': null\n"
                           "    },\n"
                           "    'error': True,\n"
                           "    'message': 'Показания должны быть положительные.'\n"
                           "}"
            },

            {
                "role": "user",
                "content": "день 120, ночь 80"
            },
            {
                "role": "assistant",
                "content": "{\n"
                           "    'category': 'электричество',\n"
                           "    'data': {\n"
                           "        'горячая_вода': null,\n"
                           "        'холодная_вода': null,\n"
                           "        'день': 120,\n"
                           "        'ночь': 80,\n"
                           "        'газ': null,\n"
                           "        'отопление': null\n"
                           "    },\n"
                           "    'error': False,\n"
                           "    'message': 'Показания успешно сохранены.'\n"
                           "}"
            },
            {
                "role": "user",
                "content": "20 горячая, 36 холодная"
            },
            {
                "role": "assistant",
                "content": "{\n"
                           "    'category': 'вода',\n"
                           "    'data': {\n"
                           "        'горячая_вода': 20,\n"
                           "        'холодная_вода': 36,\n"
                           "        'день': null,\n"
                           "        'ночь': null,\n"
                           "        'газ': null,\n"
                           "        'отопление': null\n"
                           "    },\n"
                           "    'error': False,\n"
                           "    'message': 'Показания успешно сохранены.'\n"
                           "}"
            },
            {
            "role": "assistant",
            "content": "Ты — бот для обработки показаний счётчиков. "
        "Твоя задача — интерпретировать запросы пользователей и извлекать показания даже из неявных формулировок. "
        "Ты должен:\n"
        "1. Определять категории данных по тексту запроса. Используй ключевые слова для определения:\n"
        "   - 'горячая', 'красный' → горячая вода.\n"
        "   - 'холодная', 'синий' → холодная вода.\n"
        "   - 'день', 'ночь', 'электричество' → электричество.\n"
        "   - 'тепло', 'отопление' → отопление.\n"
        "   - 'газ', 'объём' → газ.\n"
        "   - Если ключевые слова пересекаются, например, 'красный' и 'день', то 'красный' имеет приоритет как горячая вода.\n"
        "2. Извлекай числа, которые следуют за ключевыми словами или тесно связаны с ними.\n"
        "3. Проверяй корректность значений:\n"
        "   - Значения должны быть положительными числами.\n"
        "4. ЕСЛИ ТЕБЯ ПОПРОСИЛИ ОПЛАТИТЬ ИЛИ ВЫБРАТЬ ЗНАЧЕНИЯ воды, газа, отопления, газа, ТО БЕРИ ЭТИ ЗНАЧЕНИЯ, "
        "5. Если запрос непонятный или данные некорректные, возвращай ошибку с пояснением.\n"
        "6. Формируй JSON-ответ с категориями, данными и сообщением об ошибке."
        "{\n"
        "   'category': <string>,\n"
        "   'data': {\n"
        "       'горячая_вода': <число> или null,\n"
        "       'холодная_вода': <число> или null,\n"
        "       'день': <число> или null,\n"
        "       'ночь': <число> или null,\n"
        "       'газ': <число> или null\n"
        "       'отопление': <число> или null\n"
        "   },\n"
        "   'error': <True/False>,\n"
        "   'message': <string>\n"
        "}"
    },
            {
                "role": "user",
                "content": f"Запрос пользователя: {query}\n\n\n"
        "1. Внимательно просмотри запрос пользователя. Он может попросить выбрать тебя счётчик. Например, оплати газ. В этом случае находи его значения\n"
        "2. Если это показания, интерпретируй текст и извлеки категории и значения.\n"
        "3. ЗНАЧЕНИЯ должны быть строго больше 0!!!\n"
        "4. Если запрос некорректен или непонятен, верни ошибку с пояснением.\n"
        "5. Сформируй JSON-ответ в соответствии с инструкцией."
            },
        ],
        response_format=METER_READINGS_FORMAT,
        max_tokens=200,
        temperature=0.4
    )

    result_request = process_request(data)
    if result_request:
        response_dict = json.loads(result_request)
        print(response_dict)
        return response_dict
    else: pass

@log_step("validation_answer_llm")
def validation_answer_llm(query, query_llm: str):
    data = create_prompt_data(
        system_instructions="""
            Ты — профессиональный цензор и валидатор текста, отвечающий за проверку **ответа модели** перед отправкой его пользователю.
            Твоя задача — провести тщательную проверку **ответа модели** на соответствие критериям и вернуть результат строго в формате JSON,
            используя заданную схему. Запрос пользователя используется **только для оценки полезности и корректности ответа модели**.

            Ты не анализируешь текст запроса пользователя для определения соответствия тематике. 
            Ответ модели должен быть строго в рамках предоставления государственных услуг. Тема запроса пользователя не влияет на эту проверку.

            Следуй этим правилам:

            1. **Проверяй язык текста ответа модели:**
               - Ответ должен быть на русском языке. Исключения допускаются только для ссылок или названий (например, аббревиатур на латинице).

            2. **Проверяй ненормативную лексику в ответе модели:**
               - Ответ не должен содержать нецензурной или оскорбительной лексики. Используй строгую фильтрацию.

            3. **Проверяй запрещённые темы в ответе модели:**
               - Ответ не должен упоминать темы, связанные с терроризмом, экстремизмом, насилием, наркотиками или другими незаконными темами.

            4. **Проверяй соответствие тематике ответа модели:**
               - Ответ должен быть строго в рамках обсуждения государственных услуг. Не учитывай тему запроса пользователя для проверки этого критерия.
               - Если ответ выходит за рамки темы государственных услуг, укажи это как нарушение.

            5. **Проверяй полезность, релевантность и допустимость отказа в ответе:**
               - Ответ должен быть логически связан с запросом пользователя и содержать полезную информацию.
               - Если модель уважительно отказывает в ответе, это допустимо при выполнении следующих условий:
                 - Отказ логически объяснён и основан на правилах (например, "Запрос выходит за рамки компетенции", "Обратитесь в официальные органы").
                 - Тон ответа остаётся вежливым, профессиональным и корректным.
                 - Ответ всё равно должен быть полезным, направляя пользователя к подходящему источнику информации.

            Запрос пользователя используется только для понимания полезности ответа модели. 
            Валидация ответа модели проводится исключительно по приведённым выше критериям.

            Формируй результат проверки в формате JSON согласно следующей схеме:

            {
              "is_valid": boolean,  # True, если ответ прошёл все проверки; False, если есть критические нарушения.
              "issues": [
                "string"  # Список описаний нарушений, если они есть (например, "Обнаружена нецензурная лексика", "Ответ не на русском языке").
              ],
              "validation": {
                "language": {
                  "status": boolean,  # True, если текст на русском языке; False, если нет.
                  "reason": string  # КРАТКОЕ Обоснование проверки.
                },
                "profanity": {
                  "status": boolean,  # True, если ненормативная лексика отсутствует; False, если найдена.
                  "reason": string  # КРАТКОЕ Обоснование проверки.
                },
                "prohibited_topics": {
                  "status": boolean,  # True, если запрещённые темы отсутствуют; False, если найдены.
                  "reason": string  # КРАТКОЕ Обоснование проверки.
                },
                "category_relevance": {
                  "status": boolean,  # True, если ответ соответствует теме государственных услуг; False, если нет.
                  "reason": string  # КРАТКОЕ обоснование проверки.
                },
                "factual_relevance": {
                  "status": boolean,  # True, если ответ содержит полезную информацию; False, если нет.
                  "reason": string  # КРАТКОЕ Обоснование проверки.
                },
                "polite_refusal": {
                  "status": boolean,  # True, если отказ в ответе корректен и логически обоснован; False, если отказ некорректен.
                  "reason": string  # КРАТКОЕ Обоснование проверки.
                }
              }
            }

            Пример правильного результата:

            {
              "is_valid": True,
              "issues": [],
              "validation": {
                "language": {
                  "status": True,
                  "reason": "Ответ полностью на русском языке."
                },
                "profanity": {
                  "status": True,
                  "reason": "Нецензурная лексика отсутствует."
                },
                "prohibited_topics": {
                  "status": True,
                  "reason": "Запрещённые темы не обнаружены."
                },
                "category_relevance": {
                  "status": True,
                  "reason": "Ответ соответствует теме государственных услуг."
                },
                "factual_relevance": {
                  "status": True,
                  "reason": "Ответ содержит полезную информацию, релевантную запросу."
                },
                "polite_refusal": {
                  "status": True,
                  "reason": "Отказ в ответе вежливый и обоснованный: 'Запрос выходит за рамки компетенции.'"
                }
              }
            }
        """,
        user_instructions=f"""
            Запрос пользователя (только для оценки полезности ответа модели): {query}

            АНАЛИЗИРУЙ ТОЛЬКО ОТВЕТ МОДЕЛИ:
            Ответ модели: {query_llm}

            Используй запрос пользователя исключительно для проверки полезности и корректности ответа модели.
            Всё внимание уделяй тексту ответа модели. Верни результат проверки в формате JSON согласно заданной схеме.
        """,
        response_format=FINAL_VALIDATION_SCHEMA,
        max_tokens=400,
        temperature=0.2
    )

    result_request = process_request(data)
    if result_request:
        response_dict = json.loads(result_request)
        print(response_dict)
        return response_dict
    else: pass


