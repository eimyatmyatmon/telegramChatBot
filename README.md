# telegramChatBot

1. To create a new Telegram bot, you need to send a message to a service called “BotFather,” which is another bot within the Telegram application.

2. Create your Bot name (/newbot - create a new bot)
3. Generate your Bot's Token
4. For a description of the Bot API, see this page: https://core.telegram.org/bots/api
5. Create public Channel 
6. Add telegram bot as Admin in this public channel
7. post message with channel usename 
8. send message to telegram channel from url
    https://api.telegram.org/bot{token}/sendMessage?chat_id={chatId}&text={message}