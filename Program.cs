using Telegram.Bot;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

DotNetEnv.Env.Load();
builder.Services.AddControllers();
builder.Services.AddHttpClient();

string token = Environment.GetEnvironmentVariable("TOKEN")!;

builder.Services.AddSingleton<ITelegramBotClient>(new TelegramBotClient("6894816199:AAERtEtNfjs2flfdEoWY5I8EuFEiq7zkAs8"));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
