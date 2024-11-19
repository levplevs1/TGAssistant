from config import bot
from time import sleep
from app.bot.handlers import general, murkup_button, messages

if __name__ == "__main__":
    while True:
        try:
            print("The bot has been successfully launched")
            bot.polling(non_stop=True)
        except Exception as e:
            print(e)
            sleep(5)  # Ждем 5 секунд перед повторным подключением