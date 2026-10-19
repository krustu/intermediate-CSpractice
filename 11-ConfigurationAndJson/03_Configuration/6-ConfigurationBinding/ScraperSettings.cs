using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    class ScraperSettings
    {
        public int CheckIntervalMinutes { get; set; }
        public int MaxPagesPerCheckk { get; set; }
        public int DelayBetweenPagesSeconds { get; set; }
    }
    class TelegramSettings
    {
        public string? BotName { get; set; }

    }
}
