using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot;
using Xunarmand.Application.Auth.Services;
using Xunarmand.Application.Users.Models;

namespace Xunarmand.Api.Controller;

[Route("api/[controller]/[action]")]
[ApiController]
public class AuthController(IAuthService authService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Register(UserModel register)
    {

        var result = await authService.Register(register);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Login(Login login)
    {
        var result = await authService.Login(login);
        return Ok(result);
    }

    private List<long> users = new List<long>();

    [HttpPost("Message")]
    public async ValueTask<bool> SendMassage(string str)
    {
        var botClient = new TelegramBotClient("7136222685:AAG9D7cjLFBK2aZBZ_GGFjTt9alBhwEbYXg");

        // Replace with the chat ID you want to send the message to
        long chatId = 6430462037;
        users.Add(chatId);

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
}