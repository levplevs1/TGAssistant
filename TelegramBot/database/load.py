import requests
from database import DATABASE_URL
import urllib3
urllib3.disable_warnings(urllib3.exceptions.InsecureRequestWarning)
"""https://localhost:7271 6868507062 {DATABASE_URL}"""

def add_user_database(id_user, username, first_name, last_name):
    # Проверка и замена значений None на 1
    id_user, username, first_name, last_name = (
        'None' if value is None else value for value in [id_user, username, first_name, last_name]
    )
    print(f"id_user:{id_user}")
    print(f"username:{username}")
    print(f"first_name:{first_name}")
    print(f"last_name:{last_name}")
    # Данные пользователя для добавления
    data = {
        "id_telegram": id_user,
        "name": first_name,
        "lastname": last_name,
        "username": username
    }

    # Отправка POST-запроса с JSON-данными
    try:
        response = requests.post(f"{DATABASE_URL}/api/Users", json=data, verify=False)  # verify=False отключает SSL для разработки
        if response.status_code == 200:
            print("User added successfully:", response.json())
        else:
            print("Failed to add user:", response.status_code, response.text)
    except requests.exceptions.RequestException as e:
        print("Request failed:", e)

def get_id_users(user_id):
    url_get = f"{DATABASE_URL}/api/Users"
    try:
        response = requests.get(url_get, verify=False)
        if response.status_code == 200:
            user_data = response.json()
            if user_data['users'] == []:
                return None
            for user in user_data['users']:
                # Проверяем, совпадает ли id_telegram
                if user.get("id_telegram") == user_id:
                    # Возвращаем id_users, если совпадение найдено
                    return user.get("id_users")
            return None
        else:
            print("User not found:", response.status_code, response.text)
            return None
    except requests.exceptions.RequestException as e:
        print("Request failed:", e)
        return None

def get_user_database(user_id):

    url_get = f"{DATABASE_URL}/api/Users"

    id_user = get_id_users(user_id)

    try:
        response = requests.get(url_get, params={"id": id_user}, verify=False)
        if response.status_code == 200:
            user_data = response.json()
            print("User data:", user_data)
            if user_data['users'] == []:
                return None
            return user_data
        else:
            print("User not found:", response.status_code, response.text)
            return None
    except requests.exceptions.RequestException as e:
        print("Request failed:", e)
        return None

def get_memory_database(user_id):

    url_get = f"{DATABASE_URL}/api/User_Memory"

    id_user = get_id_users(user_id)

    try:
        response = requests.get(url_get, params={"id": id_user}, verify=False)
        if response.status_code == 200:
            user_memory = response.json()
            print("User data:", user_memory)
            return [entry['content_memory'] for entry in user_memory['user_Memory']]
        else:
            print("User not found:", response.status_code, response.text)
            return []
    except requests.exceptions.RequestException as e:
        print("Request failed:", e)
        return []

def delete_memory_by_index(memory_id):
    """
    Удаляет запись памяти по индексу id_user_memory.
    """
    url_delete = f"{DATABASE_URL}/api/User_Memory/{memory_id}"  # Указываем ID прямо в URL

    try:
        # Отправляем DELETE-запрос
        response = requests.delete(url_delete, verify=False)
        if response.status_code == 200 or response.status_code == 204:
            print(f"Memory record with ID {memory_id} successfully deleted.")
            return True
        else:
            print("Failed to delete memory record:", response.status_code, response.text)
            return False
    except requests.exceptions.RequestException as e:
        print("Request failed:", e)
        return False

def get_memory_chat_database(user_id):
    url_get = f"{DATABASE_URL}/api/User_Memory"
    id_user = get_id_users(user_id)

    try:
        response = requests.get(url_get, params={"id": id_user}, verify=False)
        if response.status_code == 200:
            user_memory = response.json()
            print("User data:", user_memory)
            memory_return = [
                entry['content_memory']
                for entry in user_memory['user_Memory']
                if entry['content_memory'].startswith('Запрос пользователя:') or entry['content_memory'].startswith('Ответ модели:')
            ]

            return memory_return
        else:
            print("User not found:", response.status_code, response.text)
            return []
    except requests.exceptions.RequestException as e:
        print("Request failed:", e)
        return []

def get_memory_request_database(user_id):
    url_get = f"{DATABASE_URL}/api/User_Memory"
    id_user = get_id_users(user_id)

    try:
        response = requests.get(url_get, params={"id": id_user}, verify=False)
        if response.status_code == 200:
            user_memory = response.json()
            print("User data:", user_memory)
            memory_return = [
                entry['content_memory']
                for entry in user_memory['user_Memory']
                if entry['content_memory'].startswith('Пользователь попросил запомнить:')
            ]

            return memory_return
        else:
            print("User not found:", response.status_code, response.text)
            return []
    except requests.exceptions.RequestException as e:
        print("Request failed:", e)
        return []

def get_memory_request_with_ids_filtered(user_id):
    """
    Возвращает словарь, где ключ — content_memory (начинается с 'Пользователь попросил запомнить:'),
    а значение — id_user_memory.
    """
    url_get = f"{DATABASE_URL}/api/User_Memory"
    id_user = get_id_users(user_id)

    try:
        response = requests.get(url_get, params={"id": id_user}, verify=False)
        if response.status_code == 200:
            user_memory = response.json()

            # Фильтруем записи и создаем словарь
            memory_with_ids = {
                entry['content_memory']: entry['id_user_memory']
                for entry in user_memory['user_Memory']
                if entry['content_memory'].startswith("Пользователь попросил запомнить:")
            }

            return memory_with_ids
        else:
            print("User not found:", response.status_code, response.text)
            return {}
    except requests.exceptions.RequestException as e:
        print("Request failed:", e)
        return {}

def get_memory_chat_request_with_ids_filtered(user_id):
    """
    Возвращает словарь, где ключ — content_memory (начинается с 'Пользователь попросил запомнить:'),
    а значение — id_user_memory.
    """
    url_get = f"{DATABASE_URL}/api/User_Memory"
    id_user = get_id_users(user_id)

    try:
        response = requests.get(url_get, params={"id": id_user}, verify=False)
        if response.status_code == 200:
            user_memory = response.json()

            # Фильтруем записи и создаем словарь
            memory_with_ids = {
                entry['content_memory']: entry['id_user_memory']
                for entry in user_memory['user_Memory']
                if entry['content_memory'].startswith("Запрос пользователя:")
            }

            return memory_with_ids
        else:
            print("User not found:", response.status_code, response.text)
            return {}
    except requests.exceptions.RequestException as e:
        print("Request failed:", e)
        return {}

def get_memory_chat_answer_request_with_ids_filtered(user_id):
    """
    Возвращает словарь, где ключ — content_memory (начинается с 'Пользователь попросил запомнить:'),
    а значение — id_user_memory.
    """
    url_get = f"{DATABASE_URL}/api/User_Memory"
    id_user = get_id_users(user_id)

    try:
        response = requests.get(url_get, params={"id": id_user}, verify=False)
        if response.status_code == 200:
            user_memory = response.json()

            # Фильтруем записи и создаем словарь
            memory_with_ids = {
                entry['content_memory']: entry['id_user_memory']
                for entry in user_memory['user_Memory']
                if entry['content_memory'].startswith("Ответ модели:")
            }

            return memory_with_ids
        else:
            print("User not found:", response.status_code, response.text)
            return {}
    except requests.exceptions.RequestException as e:
        print("Request failed:", e)
        return {}

def post_memory_database(user_id, request, answer, is_command=False):
    url_get = f"{DATABASE_URL}/api/User_Memory"

    id_user = get_id_users(user_id)
    if is_command is True:
        data = {
            "content_memory": f"Пользователь попросил запомнить: {request}"[:250],
            "id_users": id_user
        }

        try:
            response = requests.post(url_get, json=data, verify=False)
            if response.status_code == 200:
                user_memory = response.json()
                print("User data:", user_memory)
                return
            else:
                print("User not found:", response.status_code, response.text)
                return
        except requests.exceptions.RequestException as e:
            print("Request failed:", e)
        return


    data = {
        "content_memory": f"Запрос пользователя: {request}"[:250],
        "id_users": id_user
    }

    try:
        response = requests.post(url_get, json=data, verify=False)
        if response.status_code == 200:
            user_memory = response.json()
            print("User data:", user_memory)
        else:
            print("User not found:", response.status_code, response.text)
            return
    except requests.exceptions.RequestException as e:
        print("Request failed:", e)
        return

    data = {
        "content_memory": f"Ответ модели: {answer}"[:250],
        "id_users": id_user
    }

    try:
        response = requests.post(url_get, json=data, verify=False)
        if response.status_code == 200:
            user_memory = response.json()
            print("User data:", user_memory)
        else:
            print("User not found:", response.status_code, response.text)
            return
    except requests.exceptions.RequestException as e:
        print("Request failed:", e)
        return

def get_service_type_database(user_id):
    # Проверка и замена значений None на 'None'

    url_get = f"{DATABASE_URL}/api/Requests"

    id_user = get_id_users(user_id)

    try:
        response = requests.get(url_get, verify=False)
        if response.status_code == 200:
            services_types = response.json()
            service_type = services_types.get("requests", [])

            if not service_type:
                return None

            for request in service_type:
                if request.get("id_users") == id_user:
                    return request.get("request_text")

            # Если совпадений не найдено
            return None
        else:
            print("Ответы не найдены:", response.status_code, response.text)
            return None
    except requests.exceptions.RequestException as e:
        print("Ошибка запроса:", e)
        return None

def post_service_type_database(user_id, service_type_name):
    # Проверка и замена значений None на 'None'

    id_user = get_id_users(user_id)

    data = {
        "request_text": service_type_name,
        "response": 'None',
        "id_type_of_requests": 3,
        "id_users": id_user

    }

    if get_service_type_database(user_id) is None:
        # Данные пользователя для обновления
        try:
            response = requests.post(f"{DATABASE_URL}/api/Requests", json=data,verify=False)  # verify=False отключает SSL для разработки
            if response.status_code == 200:
                print("User updated successfully:", response.json())
            elif response.status_code == 404:
                print("User not found. Update failed:", response.status_code, response.text)
            else:
                print("Failed to update user:", response.status_code, response.text)
        except requests.exceptions.RequestException as e:
            print("Request failed:", e)
    else:
        id_requests = get_id_service_type_database(user_id)
        try:
            response = requests.put(f"{DATABASE_URL}/api/Requests/{id_requests}", json=data,verify=False)  # verify=False отключает SSL для разработки
            if response.status_code == 200:
                print("User updated successfully:", response.json())
            elif response.status_code == 404:
                print("User not found. Update failed:", response.status_code, response.text)
            else:
                print("Failed to update user:", response.status_code, response.text)
        except requests.exceptions.RequestException as e:
            print("Request failed:", e)

def get_id_service_type_database(user_id):
    # Проверка и замена значений None на 'None'

    url_get = f"{DATABASE_URL}/api/Requests"

    id_user = get_id_users(user_id)

    try:
        response = requests.get(url_get, verify=False)
        if response.status_code == 200:
            services_types = response.json()
            service_type = services_types.get("requests", [])

            if not service_type:
                return None

            for request in service_type:
                if request.get("id_users") == id_user:
                    return request.get("id_requests")

            # Если совпадений не найдено
            return None
        else:
            print("Ответы не найдены:", response.status_code, response.text)
            return None
    except requests.exceptions.RequestException as e:
        print("Ошибка запроса:", e)
        return None

def post_housing_and_communal_services_database(name_service):

    data = {
        "text_of_request": name_service,
    }

    try:
        response = requests.post(f"{DATABASE_URL}/api/Housing_And_Communal_Services", json=data, verify=False)  # verify=False отключает SSL для разработки
        if response.status_code == 200:
            print("User updated successfully:", response.json())
        elif response.status_code == 404:
            print("User not found. Update failed:", response.status_code, response.text)
        else:
            print("Failed to update user:", response.status_code, response.text)
    except requests.exceptions.RequestException as e:
        print("Request failed:", e)

def save_meter_readings(user_id, readings_data):
    """
    Сохраняет данные счетчиков для пользователя.

    :param user_id: ID пользователя в системе.
    :param readings_data: Словарь с типами счетчиков и их значениями.
                          Пример: {"газ": 324, "горячая_вода": None, "холодная_вода": 150}
    """
    id_user = get_id_users(user_id)
    for meter_type_name, value in readings_data.items():
        if value is not None:
            # Получаем ID типа счетчика (например, "газ" или "горячая_вода")
            meter_type_id = get_meter_type_by_name(meter_type_name)

            # Проверяем, существует ли счетчик для пользователя
            meter_id = get_or_create_meter(id_user, meter_type_id)

            # Обновляем или сохраняем данные счетчика
            save_reading(meter_id, value)

def get_meter_type_by_name(meter_type_name):
    """
    Получает id_meter_type по имени meter_type_name из базы данных.
    """
    url_get = f"{DATABASE_URL}/api/Meter_Type"

    try:
        # Отправка GET-запроса для получения всех типов счётчиков
        response = requests.get(url_get, verify=False)
        if response.status_code == 200:
            meter_types = response.json().get("meter_Type", [])
            # Поиск нужного типа счётчика
            for meter in meter_types:
                if meter.get("meter_type_name").lower() == meter_type_name.lower():
                    return meter["id_meter_type"]
            # Если тип счётчика не найден
            print(f"Meter type '{meter_type_name}' not found.")
            return None
        else:
            print("Failed to fetch meter types:", response.status_code, response.text)
            return None
    except requests.exceptions.RequestException as e:
        print("Request failed:", e)
        return None

def get_or_create_meter(id_users, meter_type_id):
    """
    Получает или создает счетчик для пользователя.
    """
    print(f'id_u: {id_users}   met_typ: {meter_type_id}')
    data = {"id_users": id_users, "id_meter_type": meter_type_id}
    response = requests.post(f"{DATABASE_URL}/api/Meters", json=data, verify=False)
    if response.status_code == 200:
        return response.json()
    else:
        raise Exception("Failed to create meter:", response.text)

def save_reading(meter_id, reading_value):
    """
    Сохраняет показания счётчика в базу данных.
    """
    url_post = f"{DATABASE_URL}/api/Meter_Readings"

    # Преобразуем значение счётчика в строку, если это необходимо
    data = {
        "id_meters": meter_id,
        "readings_value": str(reading_value),  # Значение показания
        "previos_readings_value": "0",  # Укажите предыдущее значение
        "id_housing_and_communal_services": 1  # Константа
    }

    try:
        response = requests.post(url_post, json=data, verify=False)
        if response.status_code == 200:
            print("Reading saved successfully:", response.json())
        else:
            print("Failed to save reading:", response.status_code, response.text)
            raise Exception("Failed to save reading:", response.text)
    except requests.exceptions.RequestException as e:
        print("Request failed:", e)
        raise

def get_current_readings(meter_id):
    """
    Получает текущие показания для счетчика.
    """
    response = requests.get(f"{DATABASE_URL}/api/Meter_Readings",params={"meter_id": meter_id}, verify=False)
    if response.status_code == 200:
        return response.json().get("readings_value", None)
    return None

def get_meter_readings(user_id):
    """
    Получает данные показаний счётчиков из базы данных и возвращает их в виде словаря.
    """
    url_get_readings = f"{DATABASE_URL}/api/Meter_Readings"
    url_get_meters = f"{DATABASE_URL}/api/Meters"

    # Получение id пользователя
    id_user = get_id_users(user_id)

    try:
        # Запрос данных счётчиков
        response_readings = requests.get(url_get_readings, params={"id_users": id_user}, verify=False)
        if response_readings.status_code == 200:
            meter_readings = response_readings.json().get("meter_Readings", [])
            result = {}

            for reading in meter_readings:
                id_meters = reading["id_meters"]

                # Запрос к таблице Meters для получения id_meter_type
                response_meters = requests.get(f"{url_get_meters}/{id_meters}", verify=False)
                if response_meters.status_code == 200:
                    meter_data = response_meters.json()
                    if meter_data['id_users'] == id_user:
                        id_meter_type = meter_data.get("id_meter_type")
                        if id_meter_type is not None :
                            # Получаем имя типа счётчика
                            meter_type_name = get_meter_type_name(id_meter_type)
                            if meter_type_name:
                                # Обработка значения показаний
                                readings_value = reading["readings_value"]
                                if readings_value is not None and readings_value.lower() != "none":
                                    readings_value = float(readings_value)
                                else:
                                    readings_value = None

                                # Заполняем словарь значением показаний
                                result[meter_type_name] = readings_value
                            else:
                                print(f"Meter type name not found for id_meter_type={id_meter_type}")
                    else:
                        print(f"Счетчик не принадлежит пользователю")
                else:
                    print(f"Failed to get meter data for id_meters={id_meters}: {response_meters.status_code}, {response_meters.text}")

            return result
        else:
            print("Failed to get meter readings:", response_readings.status_code, response_readings.text)
            return {}
    except requests.exceptions.RequestException as e:
        print("Request failed:", e)
        return {}

def get_meter_type_name(meter_type_id):
    """
    Получает имя типа счётчика по его ID.
    """
    url_get = f"{DATABASE_URL}/api/Meter_Type"

    try:
        response = requests.get(url_get, verify=False)
        if response.status_code == 200:
            meter_types = response.json().get("meter_Type", [])
            for meter_type in meter_types:
                if meter_type["id_meter_type"] == meter_type_id:
                    return meter_type["meter_type_name"]
        else:
            print("Failed to get meter types:", response.status_code, response.text)
            return None
    except requests.exceptions.RequestException as e:
        print("Request failed:", e)
        return None

def get_counters_data(user_id):
    """
    Получает данные счетчиков из базы данных и возвращает их в виде словаря для команды /counters.
    """
    # Получение всех показаний счетчиков пользователя
    readings = get_meter_readings(user_id)

    # Стандартный формат словаря с ключами
    counters_data = {
        "горячая_вода": readings.get("горячая_вода"),
        "холодная_вода": readings.get("холодная_вода"),
        "отопление": readings.get("отопление"),
        "газ": readings.get("газ"),
        "день": readings.get("день"),
        "ночь": readings.get("ночь"),
    }

    return counters_data

def post_answer_request(user_id, request, answer):
    requests = get_memory_chat_request_with_ids_filtered(user_id)
    answers = get_memory_chat_answer_request_with_ids_filtered(user_id)

    if len(requests) + len(answers) >= 18:
        first_key, first_value = next(iter(requests.items()))
        delete_memory_by_index(first_value)

        first_key, first_value = next(iter(answers.items()))
        delete_memory_by_index(first_value)

    post_memory_database(user_id, request, answer)

def get_heading():

    url_get = f"{DATABASE_URL}/api/Articles_Housing_Code"

    #service_type = get_service_type_database(user_id)

    try:
        response = requests.get(url_get, verify=False)
        if response.status_code == 200:
            headings_text = response.json()
            headings = headings_text.get("articles_Housing_Code", [])
            if headings == []:
                return None

            headings = [heading["articles_housing_code_name"] for heading in headings]

            return headings
        else:
            print("Headings not found:", response.status_code, response.text)
            return None
    except requests.exceptions.RequestException as e:
        print("Request failed:", e)
        return None

def get_content_by_heading(headings):
    url_get = f"{DATABASE_URL}/api/Articles_Housing_Code"

    try:
        response = requests.get(url_get, verify=False)
        if response.status_code == 200:
            question_answer = response.json()
            questions = question_answer.get("quick_Answers_hcs", [])

            if not questions:
                return None
            result = []
            # Поиск по "quick_answers_hcs_name"
            for el in headings:
                for article in questions:
                    if article.get("quick_answers_hcs_name") == el:
                        result.append(article.get("quick_answers_hcs_content"))
            return result
        else:
            print("Ответы не найдены:", response.status_code, response.text)
            return None
    except requests.exceptions.RequestException as e:
        print("Ошибка запроса:", e)
        return None

def get_question():

    url_get = f"{DATABASE_URL}/api/Quick_Answers_hcs"

    try:
        response = requests.get(url_get, verify=False)
        if response.status_code == 200:
            question_answer = response.json()
            question = question_answer.get("quick_Answers_hcs", [])

            if question == []:
                return None

            question = [article["quick_answers_hcs_name"] for article in question]

            return question
        else:
            print("Headings not found:", response.status_code, response.text)
            return None
    except requests.exceptions.RequestException as e:
        print("Request failed:", e)
        return None

def get_content_by_question(question_name):
    url_get = f"{DATABASE_URL}/api/Quick_Answers_hcs"

    try:
        response = requests.get(url_get, verify=False)
        if response.status_code == 200:
            question_answer = response.json()
            questions = question_answer.get("quick_Answers_hcs", [])

            if not questions:
                return None

            # Поиск по "quick_answers_hcs_name"
            for article in questions:
                if article.get("quick_answers_hcs_name") == question_name:
                    return article.get("quick_answers_hcs_content")

            # Если совпадений не найдено
            return None
        else:
            print("Ответы не найдены:", response.status_code, response.text)
            return None
    except requests.exceptions.RequestException as e:
        print("Ошибка запроса:", e)
        return None

