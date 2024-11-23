from utils.save_load import load_document_data
from database.load import get_user_database, get_service_type_database


def search_by_header(header, user_id):
    """
    Поиск информации по заголовку.
    :param header: заголовок для поиска
    :return: строки, связанные с заголовком
    """

    if header is None:
        return "Не удалось получить информацию"

    result = ""
    document = load_document_data()
    user = get_user_database(user_id)
    if user is None:
        print("user none")

    header = header.strip()
    header = header.split(', ')
    print("header: ", header)

    for el in header:
        print(document)
        for item in document[get_service_type_database(user_id)]:
            for key, value in item.items():
                if key == el:
                    result += value +'\n'
                    break
    return result


def extract_headers(user_id):
    """
    Извлечение только заголовков из документа.
    :return: список заголовков
    """

    headers_list = []

    document = load_document_data()
    user = get_user_database(user_id)

    for item in document[get_service_type_database(user_id)]:
        for key, _ in item.items():
            headers_list.append(key)
    return headers_list
