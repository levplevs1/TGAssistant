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
    "name": "meter_readings_processor",
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
              "example": 15.2,
              "minimum": 0
            },
            "холодная_вода": {
              "type": ["number", "null"],
              "description": "Текущие показания холодной воды в кубических метрах.",
              "example": 10.5,
              "minimum": 0
            },
            "день": {
              "type": ["number", "null"],
              "description": "Текущие показания дневного тарифа электроэнергии в киловатт-часах.",
              "example": 150.5,
              "minimum": 0
            },
            "ночь": {
              "type": ["number", "null"],
              "description": "Текущие показания ночного тарифа электроэнергии в киловатт-часах.",
              "example": 90.3,
              "minimum": 0
            },
            "тепло": {
              "type": ["number", "null"],
              "description": "Текущие показания отопления в гигакалориях (Гкал).",
              "example": 7.8,
              "minimum": 0
            },
            "объём": {
              "type": ["number", "null"],
              "description": "Текущие показания объёма газа в кубических метрах (м³).",
              "example": 12.3,
              "minimum": 0
            }
          },
          "description": "Объект данных с текущими показаниями по категориям. Все данные должны быть числами или null, если недоступны.",
          "additionalProperties": False
        },
        "previous_data": {
          "type": ["object", "null"],
          "properties": {
            "горячая_вода": {
              "type": ["number", "null"],
              "description": "Предыдущие показания горячей воды в кубических метрах.",
              "example": 14.7,
              "minimum": 0
            },
            "холодная_вода": {
              "type": ["number", "null"],
              "description": "Предыдущие показания холодной воды в кубических метрах.",
              "example": 9.8,
              "minimum": 0
            },
            "день": {
              "type": ["number", "null"],
              "description": "Предыдущие показания дневного тарифа электроэнергии в киловатт-часах.",
              "example": 145.3,
              "minimum": 0
            },
            "ночь": {
              "type": ["number", "null"],
              "description": "Предыдущие показания ночного тарифа электроэнергии в киловатт-часах.",
              "example": 87.6,
              "minimum": 0
            },
            "тепло": {
              "type": ["number", "null"],
              "description": "Предыдущие показания отопления в гигакалориях (Гкал).",
              "example": 7.3,
              "minimum": 0
            },
            "объём": {
              "type": ["number", "null"],
              "description": "Предыдущие показания объёма газа в кубических метрах (м³).",
              "example": 11.5,
              "minimum": 0
            }
          },
          "description": "Объект данных с предыдущими показаниями. Используется для расчёта расхода. Null, если данные недоступны.",
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
        },
        "timestamp": {
          "type": ["string", "null"],
          "description": "Метка времени в формате ISO-8601 для текущих показаний.",
          "example": "2024-11-19T15:30:00Z"
        }
      },
      "required": ["category", "data", "error"],
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





