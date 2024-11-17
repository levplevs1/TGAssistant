from app.bot import bot
from time import sleep
from app.bot.handlers import general, messages

if __name__ == "__main__":
    while True:
        try:
            bot.polling(non_stop=True)
            print("The bot has been successfully launched")
        except Exception as e:
            print(e)
            sleep(5)  # Ждем 5 секунд перед повторным подключением