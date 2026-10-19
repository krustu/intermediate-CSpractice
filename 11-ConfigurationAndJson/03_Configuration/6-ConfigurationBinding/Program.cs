using Microsoft.Extensions.Configuration;
using ConsoleApp2;
{
    IConfiguration config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false)
    .Build();

    ScraperSettings settings = config.GetSection("Scraper").Get<ScraperSettings>()
        ?? throw new InvalidOperationException("Section 'Scraper' is missing");
    TelegramSettings settings2 = config.GetSection("Telegram").Get<TelegramSettings>()
        ?? throw new InvalidOperationException("Telegram 'telegram' is missing");
    if (settings.MaxPagesPerCheckk <= 0)
        throw new InvalidOperationException("MaxPagesPerCheck must be greater than 0");
    Console.WriteLine(settings.CheckIntervalMinutes * 60);   // 300, число, а не строка
    Console.WriteLine(settings.MaxPagesPerCheckk);

    Console.WriteLine(settings2.BotName);
}

