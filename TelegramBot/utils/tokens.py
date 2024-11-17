from utils import tokenizer

def count_tokens(text):
    """
    Подсчитывает количество токенов в тексте для модели Qwen.

    :param text: Текст, который нужно отправить в модель.
    :return: Количество токенов.
    """
    tokens = tokenizer.encode(text)
    return len(tokens)*1.045

def validate_count_tokens(text, tokens):
    """
     Проверяет количество токенов в тексте.

     :param text: Текст для подсчёта
     :return: bool.
     """
    if text is not None and tokens is not None:
        if count_tokens(text) >= tokens: return True
        else: return False
    else:
        return None
