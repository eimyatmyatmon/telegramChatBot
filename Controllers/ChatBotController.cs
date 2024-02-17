using Microsoft.AspNetCore.Mvc;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Telegram.Controller;

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
    [HttpPost]
    public async Task<IActionResult?> Chat(string channelName, string text)
    {
        var token = Environment.GetEnvironmentVariable("TOKEN");
        var botClient = new TelegramBotClient(token!);

        var t = await botClient.SendTextMessageAsync(channelName, text);
        return Ok("");
    }
}
// https://api.telegram.org/bot6894816199:AAERtEtNfjs2flfdEoWY5I8EuFEiq7zkAs8/sendMessage?chat_id=@em3testpublic&text=Hello
