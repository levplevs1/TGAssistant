from os import path
from json import load, dump


# Функция для загрузки данных документа
def load_document_data():
    config_file = path.join(f'document_data.json')
    if path.exists(config_file):
        with open(config_file, 'r', encoding="utf-8") as f:
            return load(f)
    else:
        return None


# Функция для загрузки данных пользователя из файла
def load_user_data(user_id):
    config_file = path.join("../app/bot/users_data", f'{user_id}.json')
    if path.exists(config_file):
        with open(config_file, 'r', encoding="utf-8") as f:
            return load(f)
    else:
        return None

# Функция для сохранения данных пользователя в файл
def save_user_data(user_id, user_data):
    config_file = path.join("../app/bot/users_data", f'{user_id}.json')
    with open(config_file, 'w', encoding="utf-8") as f:
        dump(user_data, f, indent=4)

def save_category_dialog(user_id, category_dialog):
    user_data = load_user_data(user_id)
    user_data["category_dialog"] = category_dialog
    save_user_data(user_id, user_data)

