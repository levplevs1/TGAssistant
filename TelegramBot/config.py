from dotenv import load_dotenv
import os
import telebot

load_dotenv()

BOT_TOKEN = os.getenv("TELEGRAM_BOT_TOKEN")
LM_STUDIO_SERVER = os.getenv("LM_STUDIO_SERVER")

bot = telebot.TeleBot(BOT_TOKEN)