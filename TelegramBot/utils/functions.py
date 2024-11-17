from utils import tokenizer

def count_tokens(text):
    """
    Подсчитывает количество токенов в тексте для модели Qwen.

    :param text: Текст, который нужно отправить в модель.
    :return: Количество токенов.
    """
    tokens = tokenizer.encode(text)
    return len(tokens)*1.045
