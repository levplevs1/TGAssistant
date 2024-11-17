from transformers import AutoTokenizer

# Указываем параметр trust_remote_code=True
tokenizer = AutoTokenizer.from_pretrained("Qwen/Qwen-14B", trust_remote_code=True)