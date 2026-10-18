using Microsoft.Extensions.Configuration;

IConfiguration config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false)
    .AddUserSecrets<Program>()
    .Build();

Console.WriteLine(config["Telegram:BotName"]);    // из appsettings.json
Console.WriteLine(config["Telegram:BotToken"]);   // из secrets.json