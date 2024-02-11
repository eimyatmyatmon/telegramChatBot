using Microsoft.AspNetCore.Mvc;
using Telegram.Bot;

namespace Telegram;

[ApiController]
[Route("[controller]")]
public class ChatBotController : ControllerBase
{
    private readonly ILogger<ChatBotController> _logger;

    public ChatBotController(ILogger<ChatBotController> logger)
    {
        _logger = logger;

    }
    [Route("Chat")]
    [HttpGet]
    public async Task<IActionResult?> Chat()
    {
        var token = Environment.GetEnvironmentVariable("TOKEN");
        var botClient = new TelegramBotClient(token!);

        var me = await botClient.GetMeAsync();
        return Ok("Hello, I am" + me.Username);
    }
}