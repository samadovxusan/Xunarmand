using Microsoft.AspNetCore.Mvc;
using Telegram.Bot;
using Xunarmand.Domain.Entities;
using Xunarmand.Persistence.DataContext;

namespace Xunarmand.Api.Controller;
[ApiController]
[Route("api/[controller]")]

public class SendTgBotController(AppDbContext _appDbContext) : ControllerBase
{
    private List<long> users = new List<long>();
    [HttpPost("Message")]
    public async ValueTask<bool> SendMassage(string str)
    {
        var botClient = new TelegramBotClient("7136222685:AAG9D7cjLFBK2aZBZ_GGFjTt9alBhwEbYXg");

    // Replace with the chat ID you want to send the message to
        long chatId = 6430462037;
        long chatid2 = 767585959;
        long chatid3 = 986905197;
        users.Add(chatId);
        users.Add(chatid2);
        users.Add(chatid3);

    // Message you want to send
    // Sending the message
        foreach (var id in users)
        {
        

             await botClient.SendTextMessageAsync(
                chatId: id,
                text: str
            );
        }

        return true;
    }
    [HttpPost("AddChatId")]
    public async ValueTask AddChatId(int id)
    {
        
    }
}