using ConsoleApp2;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
class Program
{
    static void Main()
    {
        IConfiguration config = new ConfigurationBuilder()  // for using json
            .AddJsonFile("appsettings.json", optional: false) //Json name and Must return else throw exception
            .Build();

        ScraperSettings settings1 = config.GetSection("Scraper").Get<ScraperSettings>()
            ?? throw new InvalidOperationException("Section 'Scraper' is missing");
        TelegramSettings settings2 = config.GetSection("Telegram").Get<TelegramSettings>()
            ?? throw new InvalidOperationException("Telegram 'telegram' is missing");
        if (settings1.MaxPagesPerCheck <= 0)
            throw new InvalidOperationException("MaxPagesPerCheck must be greater than 0");
        IOptions<ScraperSettings> options1 = Options.Create(settings1);
        IOptions<TelegramSettings> options2 = Options.Create(settings2);

        var scraper = new Scraper(options1, options2);
        scraper.Run();
    }
}