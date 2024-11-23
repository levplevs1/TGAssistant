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

    id_user = get_id_users(user_id)

    # Отправка PUT-запроса с JSON-данными
    try:
        response = requests.get(f"{DATABASE_URL}/api/Service_Type",  params={"id": id_user}, verify=False)  # verify=False отключает SSL для разработки
        if response.status_code == 200:
            print("User updated successfully:", response.json())
            return response.json()['service_Type'][-1]['service_type_name']
        elif response.status_code == 404:
            print("User not found. Update failed:", response.status_code, response.text)
        else:
            print("Failed to update user:", response.status_code, response.text)
    except requests.exceptions.RequestException as e:
        print("Request failed:", e)

def post_service_type_database(user_id, service_type_name, id_housing_and_communal_services=1):
    # Проверка и замена значений None на 'None'

    id_user = get_id_users(user_id)

    # Данные пользователя для обновления
    data = {
        "service_type_name": service_type_name,
        "id_housing_and_communal_services": id_housing_and_communal_services,

    }
    try:
        response = requests.post(f"{DATABASE_URL}/api/Service_Type", params={"id": id_user}, json=data,verify=False)  # verify=False отключает SSL для разработки
        if response.status_code == 200:
            print("User updated successfully:", response.json())
        elif response.status_code == 404:
            print("User not found. Update failed:", response.status_code, response.text)
        else:
            print("Failed to update user:", response.status_code, response.text)
    except requests.exceptions.RequestException as e:
        print("Request failed:", e)

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

