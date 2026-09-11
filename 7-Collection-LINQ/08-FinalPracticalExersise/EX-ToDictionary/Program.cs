using System;
using System.Net.WebSockets;
class Program
{
    static void Main()
    {
        List<Advertisement> ads = new List<Advertisement>
{
    new Advertisement("Gaming Laptop", "Avito", 1500),
    new Advertisement("Gaming Laptop", "Avito", 1500),
    new Advertisement("Mountain Bike", "OLX", 700),
    new Advertisement("iPhone 15", "Avito", 900),
    new Advertisement("Wooden Table", "OLX", 250),
    new Advertisement("PS5", "Avito", 500),
    new Advertisement("Office Chair", "Facebook", 180),
    new Advertisement("Used Car", "OLX", 8500),
    new Advertisement("Monitor", "Avito", 300),
    new Advertisement("Headphones", "Facebook", 120),
    new Advertisement("Apartment", "OLX", 120000)
};

        // var dict = students.ToDictionary(s => s.Name, s => s.Grade);
        // ArgumentException: An item with the same key has already been added.
        // ToDictionary требует уникальности ключей и не умеет сам объединять дубликаты —
        // поэтому при повторяющемся Name он падает на втором добавлении.

        var dict = ads
            .GroupBy(s => s.Source)
            .ToDictionary(g => g.Key, g => g.ToList());

        foreach (var ad in dict)
        {
            Console.WriteLine($"{ad.Key}");
            foreach (var ad2 in ad.Value)
            {
                Console.WriteLine($"{ad2.Title} - {ad2.Price}PLN - {ad2.Source}");
            }

        }
    }
}
public class Advertisement
{
    public string Title { get; set; }
    public string Source { get; set; }
    public decimal Price { get; set; }

    public Advertisement(string title, string source, decimal price)
    {
        Title = title;
        Source = source;
        Price = price;
    }
}
