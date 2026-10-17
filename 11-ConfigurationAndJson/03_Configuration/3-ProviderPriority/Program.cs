using System;
using Microsoft.Extensions.Configuration;
class Program
{
    static void Main()
    {
        IConfiguration config = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>   // источник 2
            {
                ["CheckIntervalMinutes"] = "99"
            })
    .AddJsonFile("appsettingTwo.json", optional: false)      // источник 1

    .Build();


        Console.WriteLine(config["MaxPagesPerCheck"]);      // from json file 
        Console.WriteLine(config["CheckIntervalMinutes"]);
    }
}