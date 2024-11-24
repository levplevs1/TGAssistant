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

JSON_DICT_FORMAT_FROM_QUESTION = {
    "type": "json_schema",
    "json_schema": {
        "name": "question_response",
        "strict": "true",
        "schema": {
            "type": "object",
            "properties": {
                "commands": {
                    "type": "string",
                    "description": "Один наиболее подходящий вопрос из списка или пустая строка, если вопрос не найден.",
                    "example": "Какие льготы доступны для инвалидов?"
                }
            },
            "required": ["commands1"]
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

VARIANTS_QUESTION_FORMAT = {
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

METER_READINGS_FORMAT = {
    "type": "json_schema",
    "json_schema": {
        "name": "meter_readings_response",
        "strict": True,
        "schema": {
            "type": "object",
            "properties": {
                "category": {
                    "type": "string",
                    "enum": ["отопление", "газ", "вода", "электричество", "unknown"],
                    "description": "Категория, к которой относятся данные. Если категория не определена, используется 'unknown'.",
                    "example": "вода"
                },
                "data": {
                    "type": "object",
                    "properties": {
                        "горячая_вода": {
                            "type": ["number", "null"],
                            "description": "Текущие показания горячей воды в кубических метрах.",
                            "example": 2038,
                            "minimum": 0
                        },
                        "холодная_вода": {
                            "type": ["number", "null"],
                            "description": "Текущие показания холодной воды в кубических метрах.",
                            "example": 1172,
                            "minimum": 0
                        },
                        "день": {
                            "type": ["number", "null"],
                            "description": "Текущие показания электроэнергии по дневному тарифу в киловатт-часах.",
                            "example": 150.5,
                            "minimum": 0
                        },
                        "ночь": {
                            "type": ["number", "null"],
                            "description": "Текущие показания электроэнергии по ночному тарифу в киловатт-часах.",
                            "example": 90.3,
                            "minimum": 0
                        },
                        "отопление": {
                            "type": ["number", "null"],
                            "description": "Текущие показания отопления в гигакалориях (Гкал).",
                            "example": 7.8,
                            "minimum": 0
                        },
                        "газ": {
                            "type": ["number", "null"],
                            "description": "Текущие показания газа в кубических метрах (м³).",
                            "example": 12.3,
                            "minimum": 0
                        }
                    },
                    "description": "Объект с текущими показаниями по категориям. Все поля должны быть либо числом, либо null, если данные отсутствуют.",
                    "additionalProperties": False
                },
                "error": {
                    "type": "boolean",
                    "description": "Индикатор ошибки. True, если данные невозможно обработать, иначе False.",
                    "example": False
                },
                "message": {
                    "type": ["string", "null"],
                    "description": "Сообщение об ошибке, если 'error' равно True. Null, если ошибок нет.",
                    "example": "Некорректное значение: 'день' - отрицательное число."
                }
            },
            "required": ["category", "data", "error", "message"],
            "additionalProperties": False
        }
    }
}

CLASSIFY_QUERY_FORMAT = {
  "type": "json_schema",
  "json_schema": {
    "name": "query_classification_response",
    "strict": True,
    "schema": {
      "type": "object",
      "properties": {
        "query_type": {
          "type": "string",
          "enum": ["услуга", "вопрос", "неопределённый"],
          "description": "Тип запроса, определённый классификатором."
        },
        "reason": {
          "type": "string",
          "description": "Краткая причина классификации, объясняющая выбор категории.",
          "example": "Запрос содержит действие и объект услуги: ключевое слово 'оплати'."
        },
        "confidence": {
          "type": "number",
          "minimum": 0,
          "maximum": 1,
          "description": "Уверенность модели в классификации запроса по шкале от 0 до 1.",
          "example": 0.85
        }
      },
      "required": ["query_type", "reason", "confidence"]
    }
  }
}

FINAL_VALIDATION_SCHEMA = {
    "type": "json_schema",
    "json_schema": {
        "name": "final_validation_response",
        "strict": True,
        "schema": {
            "type": "object",
            "properties": {
                "is_valid": {
                    "type": "boolean",
                    "description": "Указывает, является ли ответ допустимым (True - ответ прошёл проверку, False - есть критические нарушения).",
                    "example": True
                },
                "issues": {
                    "type": "array",
                    "description": "Список обнаруженных нарушений (если is_valid = False). Может быть пустым, если нарушений нет.",
                    "items": {
                        "type": "string",
                        "description": "Описание конкретного нарушения.",
                        "example": "Ответ не соответствует теме."
                    }
                },
                "validation": {
                    "type": "object",
                    "description": "Детальная информация о проверке каждого критерия.",
                    "properties": {
                        "language": {
                            "type": "object",
                            "properties": {
                                "status": {
                                    "type": "boolean",
                                    "description": "True, если ответ на русском языке, иначе False.",
                                    "example": True
                                },
                                "reason": {
                                    "type": "string",
                                    "description": "Обоснование результата проверки.",
                                    "example": "Ответ на русском языке."
                                }
                            },
                            "required": ["status", "reason"]
                        },
                        "profanity": {
                            "type": "object",
                            "properties": {
                                "status": {
                                    "type": "boolean",
                                    "description": "True, если ненормативная лексика отсутствует, иначе False.",
                                    "example": True
                                },
                                "reason": {
                                    "type": "string",
                                    "description": "Обоснование результата проверки.",
                                    "example": "Нецензурная лексика отсутствует."
                                }
                            },
                            "required": ["status", "reason"]
                        },
                        "prohibited_topics": {
                            "type": "object",
                            "properties": {
                                "status": {
                                    "type": "boolean",
                                    "description": "True, если запрещённые темы отсутствуют, иначе False.",
                                    "example": True
                                },
                                "reason": {
                                    "type": "string",
                                    "description": "Обоснование результата проверки.",
                                    "example": "Запрещённые темы не обнаружены."
                                }
                            },
                            "required": ["status", "reason"]
                        },
                        "category_relevance": {
                            "type": "object",
                            "properties": {
                                "status": {
                                    "type": "boolean",
                                    "description": "True, если ответ соответствует текущей теме, иначе False.",
                                    "example": True
                                },
                                "reason": {
                                    "type": "string",
                                    "description": "Обоснование результата проверки.",
                                    "example": "Ответ соответствует теме здравоохранения."
                                }
                            },
                            "required": ["status", "reason"]
                        },
                        "factual_relevance": {
                            "type": "object",
                            "properties": {
                                "status": {
                                    "type": "boolean",
                                    "description": "True, если ответ содержит полезную и релевантную информацию, иначе False.",
                                    "example": True
                                },
                                "reason": {
                                    "type": "string",
                                    "description": "Обоснование результата проверки.",
                                    "example": "Ответ логически связан с запросом."
                                }
                            },
                            "required": ["status", "reason"]
                        }
                    },
                    "required": ["language", "profanity", "prohibited_topics", "category_relevance", "factual_relevance"]
                }
            },
            "required": ["is_valid", "issues", "validation"]
        }
    }
}





