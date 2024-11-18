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

VARIANTS_FORMAT = {
    "type": "json_schema",
    "json_schema": {
        "name": "question_generator",
        "strict": True,
        "schema": {
            "type": "object",
            "properties": {
                "questions": {
                    "type": "array",
                    "items": {
                        "type": "string"
                    },
                    "minItems": 3,
                    "maxItems": 3,
                    "description": "Список из трёх вопросов, которые логически связаны с исходным вопросом пользователя."
                }
            },
            "required": ["questions"]
        }
    }
}