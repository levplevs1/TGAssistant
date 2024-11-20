import time
import json
from colorama import init, Fore

init(autoreset=True)

# Глобальный лог
log = []

# Декоратор для логирования
def log_step(step_name):
    """Декоратор для логирования шагов выполнения"""
    def decorator(func):
        def wrapper(*args, **kwargs):
            start_time = time.time()
            log_entry = {"step": step_name, "status": "started"}
            log.append(log_entry)

            try:
                result = func(*args, **kwargs)
                elapsed_time = time.time() - start_time
                log_entry.update({"status": "completed", "elapsed_time": elapsed_time, "result": result})
                return result
            except Exception as e:
                elapsed_time = time.time() - start_time
                log_entry.update({"status": "failed", "elapsed_time": elapsed_time, "error": str(e)})
                raise e
        return wrapper
    return decorator


# Функция для сохранения лога в файл
@log_step("save_log")
def save_log_to_file(file_path='log.json'):
    """Сохраняет глобальный лог в файл JSON"""
    try:
        with open(file_path, 'w', encoding='utf-8') as f:
            json.dump(log, f, ensure_ascii=False, indent=4)
        print(Fore.GREEN + f"Лог успешно сохранён в файл {file_path}")
    except Exception as e:
        print(Fore.RED + f"Ошибка при сохранении лога в файл: {e}")