using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Text.Json;
using ConsoleApp2;
class Program
{
    static void Main()
    {
        List<Students> StudGuys
    = new List<Students>
    {
                new Students { Group = "IT" ,
                           Members = new List<Member>
                           {
                               new Member
                               {
                                   Name = "Alex",
                                   Age = 12,
                                   Status = true

                               },
                               new Member
                               {
                                   Name = "John",
                                   Age = 13,
                                   Status = true

                               },
                               new Member
                               {
                                   Name = "Robert",
                                   Age = 22,
                                   Status = true

                               }
                           }
                             },
                new Students { Group = "Managmeent" ,
                           Members = new List<Member>
                           {
                               new Member
                               {
                                   Name = "Diana",
                                   Age = 12,
                                   Status = true

                               },
                               new Member
                               {
                                   Name = "Emir",
                                   Age = 13,
                                   Status = true

                               },
                               new Member
                               {
                                   Name = "Daniel",
                                   Age = 22,
                                   Status = true

                               }
                           }
                             },
                new Students { Group = "Business" ,
                           Members = new List<Member>
                           {
                               new Member
                               {
                                   Name = "Salidat",
                                   Age = 12,
                                   Status = true

                               },
                               new Member
                               {
                                   Name = "Joni",
                                   Age = 13,
                                   Status = true

                               },
                               new Member
                               {
                                   Name = "Leonaria",
                                   Age = 22,
                                   Status = true

                               }
                           }
                             }
    };


        string StudnetJson = SerializeFunction(StudGuys);

        List<Students>? back = JsonSerializer.Deserialize<List<Students>>(
    StudnetJson, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        if (back == null) return;

        foreach (Students s in back)
        {
            Console.WriteLine(s.Group);
            foreach (Member m in s.Members!)
            {
                Console.WriteLine($"   {m.Name} - {m.Age}");
            }
        }





        IConfiguration config = new ConfigurationBuilder()
            .AddJsonFile("appsettingTwo.json", optional: false)
            .Build();
        ScraperSettings settings1 = config.GetSection("Scraper").Get<ScraperSettings>()
     ?? throw new InvalidOperationException("Section 'Scraper' is missing");
        TelegramSettings settings2 = config.GetSection("Telegram").Get<TelegramSettings>()
            ?? throw new InvalidOperationException("Telegram 'telegram' is missing");
        if (settings1.MaxPagesPerCheck <= 0)
            throw new InvalidOperationException("MaxPagesPerCheck must be greater than 0");


        IOptions<ScraperSettings> options1 = Options.Create(settings1);
        IOptions<TelegramSettings> options2 = Options.Create(settings2);

        Scraper scraper = new Scraper(options1, options2);

        scraper.Run();
    }
    static string SerializeFunction<T>(List<T> objects)
    {
        return JsonSerializer.Serialize(objects, new JsonSerializerOptions { WriteIndented = true });
    }
}
/*
  {
  "CheckIntervalMinutes": 5,
  "MaxPagesPerCheck": 5,
  "DelayBetweenPagesSeconds": 1,
  "RetryCount": 10,
  "Telegram": {
    "BotName": "Krustu"
  }
}
*/
class Students
{
    public string? Group { get; set; }
    public List<Member>? Members { get; set; }
}
class Member
{
    public string? Name { get; set; }
    public bool Status { get; set; }
    public int Age { get; set; }
}
