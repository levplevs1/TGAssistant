from llm.prompt_manager import get_meter_readings_llm


def process_prompt(message):
    if message:
        headers = get_meter_readings_llm(message)
        print(headers)
while True:
    user_request = input()
    process_prompt(user_request)
