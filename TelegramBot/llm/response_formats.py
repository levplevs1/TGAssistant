DEFAULT_RESPONSE_FORMAT = {
    "type": "json_schema",
    "json_schema": {
        "type": "array",
        "items": {"type": "string"}
    }
}

JSON_OBJECT_SCHEMA = {
    "type": "json_schema",
    "json_schema": {
        "type": "object",
        "properties": {
            "key1": {"type": "string"},
            "key2": {"type": "number"}
        }
    }
}

JSON_DICT_FORMAT = {
    "type": "json_schema",
    "json_schema": {
        "name": "command_response",
        "strict": "true",
        "schema": {
            "type": "object",
            "properties": {
                "commands": {
                    "type": "string",
                    "example": "Технические характеристики, Языки программирования, Дальнейшие шаги"
                }
            },
            "required": ["commands"]
        }
    }
}

MEMORY_VALIDATION_JSON_FORMAT = {
    "type": "json_schema",
    "json_schema": {
        "name": "memory_validation_response",
        "strict": "true",
        "schema": {
            "type": "object",
            "properties": {
                "is_acceptable": {
                    "type": "boolean",
                    "description": "Указывает, можно ли сохранить данные (True - допустимо, False - недопустимо).",
                    "example": True
                },
                "compressed_text": {
                    "type": "string",
                    "description": (
                        "Сжатая версия текста для сохранения. "
                        "Оставить пустым, если 'is_acceptable' равно False."
                    ),
                    "example": "Оплата штрафа за парковку 1500 руб."
                }
            },
            "required": ["is_acceptable", "compressed_text"]
        }
    }
}

