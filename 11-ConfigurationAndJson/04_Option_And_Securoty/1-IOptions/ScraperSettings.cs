using System;
using System.Collections.Generic;
using System.Data;
using System.Net.NetworkInformation;
using System.Text;
using Microsoft.Extensions.Options;
namespace ConsoleApp2
{

    class Scraper
    {
        private readonly ScraperSettings _settings;
        private readonly TelegramSettings telegram;
        public Scraper(IOptions<ScraperSettings> options , IOptions<TelegramSettings> Telegram)
        {
            _settings = options.Value;
            telegram = Telegram.Value;
        }

        public void Run()
        {
            Console.WriteLine($"BotName - {telegram.BotName} - Checking every {_settings.CheckIntervalMinutes} min, {_settings.MaxPagesPerCheck} pages");
        }
    }
    class ScraperSettings
    {
        public int CheckIntervalMinutes { get; set; }
        public int MaxPagesPerCheck { get; set; }
        public int DelayBetweenPagesSeconds { get; set; }
    }
    class TelegramSettings
    {
        public string? BotName { get; set; }

    }

}
