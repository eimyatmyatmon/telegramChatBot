using ChatUtility;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Telegram.Controller;

[ApiController]
[Route("[controller]")]
public class ChatBotController : ControllerBase
{
    private readonly ILogger<ChatBotController> _logger;
    private readonly HttpClient _httpClient;
    private readonly string token;

    public ChatBotController(ILogger<ChatBotController> logger, IHttpClientFactory httpClientFactory)
    {
        _logger = logger;
        _httpClient = httpClientFactory.CreateClient();
        token = Environment.GetEnvironmentVariable("TOKEN")!;

    }
    [Route("Chat")]
    [HttpPost]
    public async Task<IActionResult?> Chat(string channelName, string text)
    {
        var botClient = new TelegramBotClient(token!);

        var t = await botClient.SendTextMessageAsync(channelName, text);
        return Ok("");
    }
    [HttpGet]
    public async Task<IActionResult> GetUpdates()
    {
        try
        {
            string apiUrl = $"https://api.telegram.org/bot{token}/getUpdates";

            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();

                return Ok(responseBody);
            }
            else
            {

                return StatusCode((int)response.StatusCode, response.ReasonPhrase);
            }
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [Route("webhook")]
    [HttpPost]
    public IActionResult Post([FromBody] ChatResponse update)
    {
        if (update == null)
        {
            return BadRequest();
        }
        return Ok(JsonConvert.SerializeObject(update));
    }
}

// Get Update from telegram channel 
// https://api.telegram.org/bot6894816199:AAERtEtNfjs2flfdEoWY5I8EuFEiq7zkAs8/getUpdates

//use webhook and connect ngrok
// "https://api.telegram.org/bot6894816199:AAERtEtNfjs2flfdEoWY5I8EuFEiq7zkAs8/setWebhook?url=https://3b76-174-138-29-158.ngrok-free.app/webhook"

//delete webhook
// "https://api.telegram.org/bot6894816199:AAERtEtNfjs2flfdEoWY5I8EuFEiq7zkAs8/deleteWebhook"

// send message to telegram channel from url
//  https://api.telegram.org/bot6894816199:AAERtEtNfjs2flfdEoWY5I8EuFEiq7zkAs8/sendMessage?chat_id=@em3test&text={message}
