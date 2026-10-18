using System;
using Microsoft.Extensions.Configuration;
class Program
{
    static void Main()
    {

        Environment.SetEnvironmentVariable("CheckIntervalMinutes", "77");
        Environment.SetEnvironmentVariable("Telegram__BotName", "ServerBot");

        IConfiguration config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false)
            .AddEnvironmentVariables()
            .Build();

        Console.WriteLine(config["CheckIntervalMinutes"]);
        Console.WriteLine(config["telegram:BotName"]);
    }
}