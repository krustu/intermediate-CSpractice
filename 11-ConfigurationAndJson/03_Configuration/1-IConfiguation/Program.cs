using System;
using Microsoft.Extensions.Configuration; //downloaded extension
class Program
{
    static void Main()
    {

        IConfiguration config = new ConfigurationBuilder()
            .AddJsonFile("appsettingTwo.json", optional: false)
            .Build();

        int interval = int.Parse(config["CheckIntervalMinutes"]!);
        int Maxpages = int.Parse(config["MaxPagesPerCheck"] ?? "0");
        bool isSuccess = int.TryParse(config["DelayBetweenPagesSeconds"], out int DelayPagSec);
        if (isSuccess)
        {
            Console.WriteLine($"DelayTime {DelayPagSec}");
        }
        Console.WriteLine($"Status of returing Delay information is {isSuccess}");
        Console.WriteLine($"Check every {interval} minutes");
        Console.WriteLine($"Check limit of Pages {Maxpages}");
        Console.WriteLine(config["Telegram:BotName"]);

        int retryCount = int.TryParse(config["RetryCount"], out int r) ? r : 3;
        Console.WriteLine($"Retries: {retryCount}");

    }
}
/*{
  "CheckIntervalMinutes": 5,
  "MaxPagesPerCheck": 5,
  "DelayBetweenPagesSeconds": 1,
  "Telegram": 
  {
    "BotName":  "Krustu"
  }

}*/