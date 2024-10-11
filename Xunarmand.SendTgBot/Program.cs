using Telegram.Bot;

// Replace with your bot token
var botClient = new TelegramBotClient("7136222685:AAG9D7cjLFBK2aZBZ_GGFjTt9alBhwEbYXg");

// Replace with the chat ID you want to send the message to
long chatId = 6430462037;

// Message you want to send
string message = "Bu yerda sizga kerakli matn mavjud!";

// Sending the message
await botClient.SendTextMessageAsync(
    chatId: chatId,
    text: message
);