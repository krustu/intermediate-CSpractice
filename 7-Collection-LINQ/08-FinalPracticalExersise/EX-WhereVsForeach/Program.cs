using System;
using System.Diagnostics;
class Program
{
    static void Main()
    {
        List<Advertisement> lists = new List<Advertisement>
        {
            new Advertisement("Used Car for Sale", "A well-maintained 2015 Toyota Camry.", 12000.00m, "jane.smith@example.com"),
            new Advertisement("Bicycle for Sale", "A barely used mountain bike.", 150.00m, "john.doe@example.com"),
            new Advertisement("Apartment for Rent", "A spacious 2-bedroom apartment in downtown.", 2000.00m, "alice.johnson@example.com"),
            new Advertisement("Laptop for Sale", "A high-performance gaming laptop.", 800.00m, "bob.wilson@example.com"),
            new Advertisement("Furniture for Sale", "A set of modern living room furniture.", 500.00m, "Krustu.d@gmail.como"),
            new Advertisement("Used Car Sale", "A well-maintained 2015 Toyota Camry.", 1200.00m, "jansde.smith@example.com"),
            new Advertisement("Bicycle ", "A barely used mountain bike.", 1503.00m, "john.dssoe@example.com"),
            new Advertisement("Apartment for sale", "A spacious 3-bedroom apartment in downtown.", 2000.00m, "adalisace.johnson@example.com"),
            new Advertisement("Gaming Laptop for Sale", "A high-performance gaming laptop.", 8002.00m, "bob.wailson@example.com"),
            new Advertisement("Furniture for rent", "A set of modern living room furniture.", 1500.00m, "Krusdasstu.d@gmail.como"),

        };
        // with using LINQ method
        var FiltringByPrice = FilterBro(lists, 2000);
        int num = 1;
        int num2 = 1;
        foreach (var list in FiltringByPrice)
        {

            Console.WriteLine($"{num}. -{list.Title} Price - {list.Price}PLN  Contact - {list.ContactInfo}");
            num++;
        }



        Console.ReadKey();
        // the same but with If

        foreach (var list in lists)
        {
            if (list.Price < 2000)
            {
                Console.WriteLine($"{num2}. -{list.Title} Price - {list.Price}PLN  Contact - {list.ContactInfo}");
                num2++;
            }
        }
    }
    static IEnumerable<Advertisement> FilterBro(List<Advertisement> lists, decimal MinPrice)
    {
        var result = lists.Where(x => x.Price < MinPrice);
        return result;
    }
}
public class Advertisement
{
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string ContactInfo { get; set; }
    public Advertisement(string title, string description, decimal price, string contactInfo)
    {
        Title = title;
        Description = description;
        Price = price;
        ContactInfo = contactInfo;
    }
    public void Display()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Description: {Description}");
        Console.WriteLine($"Price: {Price:C}");
        Console.WriteLine($"Contact Info: {ContactInfo}");
    }
}