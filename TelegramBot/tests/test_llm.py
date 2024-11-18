from llm.prompt_manager import process_user_request, include_headers_llm

def process_prompt(message):
    if message:
        headers = include_headers_llm(message)

        llm_answer = process_user_request(message)
        print(llm_answer)
while True:
    user_request = input()
    process_prompt(user_request)
