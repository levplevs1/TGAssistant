# AssisGov
## Описание
Данный проект представляет собой бота, который принимает показания счётчиков, обрабатывает запросы пользователей и предоставляет ответы на вопросы, связанные с показаниями.
## Установка
1. Склонируйте репозиторий:
```bash
git clone https://github.com/levplevs1/TGAssistant.git cd your-repo
```
2. Установите зависимости:
```bash
pip install -r requirements.txt
```
3. Убедитесь, что у вас установлен Python версии 3.12+.
## Настройка
1. Скопируйте файл примера конфигурации `.env.example`
2. Переименуйте файл в `.env`
   
# Инструкция по установке LM Studio, скачиванию модели и запуску сервера

## Шаг 1: Установка LM Studio
1. Перейдите на официальный сайт [LM Studio](https://lmstudio.ai).
2. Скачайте подходящую версию для вашей операционной системы:
   - Для Windows: `lmstudio-windows-x64.zip`
   - Для macOS: `lmstudio-macos-x64.dmg`
   - Для Linux: `lmstudio-linux-x64.AppImage`
3. Установите LM Studio:
   - **Windows**: Разархивируйте скачанный архив и запустите `LMStudio.exe`.
   - **macOS**: Откройте `.dmg` файл и перенесите LM Studio в папку `Программы`.
   - **Linux**: Дайте файлу права на выполнение и запустите:
     ```bash
     chmod +x lmstudio-linux-x64.AppImage
     ./lmstudio-linux-x64.AppImage
     ```

---

## Шаг 2: Скачивание нужной модели
1. Запустите LM Studio.
2. Перейдите на вкладку **Discover** (Обзор моделей).
3. Найдите модель в поиске:
```bash
bartowski/Qwen2.5-14B-Instruct-GGUF
```

## Выбор квантизации для модели

Модель **Qwen2.5 14B Instruct** доступна в различных вариантах квантизации. Для работы вашего проекта выберите подходящий вариант в зависимости от мощности вашей системы.

## Рекомендации
1. **Минимально оптимальный вариант:**
   - **Q4_K_M (8.99 GB)** — подходит для большинства современных систем с ограниченными ресурсами. Обеспечивает стабильную работу и приемлемую точность.
   
2. **Рекомендуемый вариант:**
   - **Q6_K (10.99 GB)** — требует больше ресурсов, но обеспечивает лучшую точность и производительность.

3. **Для систем с высокой производительностью:**
   Если ваша система обладает достаточными ресурсами (например, 16+ GB видеопамяти), вы можете использовать более точные модели:
   - **Q6_K_L (12.50 GB)** — для высокой точности.
   - **Q8_0 (15.75 GB)** — для максимальной точности, если объём видеопамяти позволяет.

4. **Недоступные варианты:**
   Если LM Studio сообщает, что модель "слишком велика для этой машины", попробуйте использовать варианты с меньшей квантизацией.

---

## Таблица квантизации
| Вариант     | Размер модели | Требования к ресурсам               | Описание                              |
|-------------|---------------|-------------------------------------|---------------------------------------|
| **Q4_K_M**  | 8.99 GB       | Подходит для большинства систем     | Минимально оптимальный вариант        |
| **Q6_K**    | 10.99 GB      | Средние требования                  | Рекомендуемый вариант                 |
| **Q6_K_L**  | 12.50 GB      | Высокие требования                  | Для систем с достаточным объёмом RAM  |
| **Q8_0**    | 15.75 GB      | Требует много ресурсов              | Максимальная точность                 |

---

## Как выбрать
1. Убедитесь, что ваша система соответствует требованиям выбранного варианта квантизации.
2. Если вы не уверены в возможностях вашей машины:
   - Начните с **Q4_K_M**.
   - Если система справляется, попробуйте **Q6_K** для повышения точности.

## Примечания
- Выбор квантизации влияет на точность модели и её производительность. Чем выше точность (например, Q8_0), тем больше ресурсов требуется.
- Если модель не запускается, выберите вариант с меньшей квантизацией.

Нажмите **Download** (Скачать), чтобы загрузить модель.

---

## Шаг 3: Запуск сервера
1. В LM Studio перейдите на вкладку **Server**.
2. Выберите скачанную модель из списка сверху.
3. Нажмите кнопку **Start Server**.
4. Убедитесь, что сервер запущен.
В логах появится сообщение:
* [INFO] Server started. [INFO] HTTP server listening on port 1234

Если необходимо сменить порт, в **LM Studio** во вкладке **Server** поменяйте **Server Port**, перезапустите сервер.

В файле конфигурации .env убедитесь, что указан корректный адрес:
```bash
LM_STUDIO_SERVER=http://localhost:1234/v1/chat/completions
```

# Как получить токен от Telegram-бота

Чтобы настроить Telegram-бота для вашего проекта, вам нужно получить токен доступа. Этот процесс выполняется через BotFather, официального бота Telegram для управления ботами.

---

## Шаг 1: Откройте Telegram и найдите BotFather
1. Откройте Telegram (на мобильном устройстве, ПК или через веб-версию).
2. В поиске введите `BotFather` и выберите бота с галочкой (официальный бот Telegram).

---

## Шаг 2: Создайте нового бота
1. Нажмите кнопку **Start** или отправьте команду `/start`, если бот уже был запущен ранее.
2. Отправьте команду `/newbot`, чтобы начать создание нового бота.
3. Следуйте инструкциям:
   - Введите имя вашего бота (например, `Ассистент по госуслугам`).
   - Введите уникальное имя пользователя для бота, оканчивающееся на `bot` (например, `GosAssistantBot`).

---

## Шаг 3: Получите токен для Telegram бота
После создания бота BotFather отправит вам сообщение с токеном доступа, похожим на следующий:

Use this token to access the HTTP API: 123456789:ABCDEFGHIJKLMNOPQRSTUVWXYZ12345

## Сохраните токен
1. Скопируйте токен из сообщения.
2. Сохраните токен в файле `.env`
```bash
TELEGRAMBOT_TOKEN=123456789:ABCDEFGHIJKLMNOPQRSTUVWXYZ12345
```


## Запуск
Запустите приложение:
```bash
python main.py
```














# Автор
Автор: Cognitex
