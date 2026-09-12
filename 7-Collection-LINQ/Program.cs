using System;
class Program
{
    static void Main()
    {

        // task1 average price for each sources
        Console.WriteLine("Average Price for each sources");

        var SortByGroup = DataAdvrb.listings
                                            .Where(x => x.Price != null)
                                            .GroupBy(x => x.Source);

        var SortAverage = SortByGroup.Select(x =>
        {
            return new
            {
                Source = x.Key,
                Average = x
                     .Where(ad => ad.Price != null)
                     .Average(ad => ad.Price!.Value)
            };
        }).ToList();
        foreach (var x in SortAverage)
        {
            Console.WriteLine($"Source:{x.Source}Amount - {x.Average}");

        }


        Console.ReadKey();
        Console.WriteLine("\nTop 3 low with prices");
        // task2 top-3 cheapest

        var SortExpensive = DataAdvrb.listings.Where(x => x.Price != null)
                                              .OrderBy(x => x.Price).ToList();
        int index = 1;

        var List = TakeBro(SortExpensive, 1, 3);

        foreach (var x in List)
        {
            Console.WriteLine($"{index} - {x.Source} - {x.Price}");
            index++;
        }
        /* foreach (var x in SortExpensive)
         {

             Console.WriteLine($"{index} - {x.Source} - {x.Price}");
             index++;
         }*/


        Console.ReadKey();
        // task3 count
        Console.WriteLine("\n All Advertisement");
        int Counts = DataAdvrb.listings.Count(x => x.Area == null);
        Console.WriteLine(Counts);

        // task3 analogy by foreach
        var collection = DataAdvrb.listings;
        int count = 0;
        foreach (var x in collection)
        {

            if (x.Area == null)
            {
                count++;
            }
        }
        Console.WriteLine(count);
        Console.ReadKey();
        Console.WriteLine("\n All unique district");

        // task4 all unique disrtict by alphobet
        var Districts = DataAdvrb.listings
            .Select(ad => ad.Location)
            .OrderBy(x => x)
            .ToHashSet();

        foreach (var x in Districts)
        {
            Console.WriteLine(x);
        }

        Console.ReadKey();
        Console.WriteLine("\n Any that more than 200000");

        var res = DataAdvrb.listings
            .Where(x => x.Price != null)
            .Any(x => x.Price > 200000);

        Console.WriteLine(res);
        // task5 at least one advertisement expensive than 200000
        Console.ReadKey();


    }
    static IEnumerable<Advertisement> TakeBro(List<Advertisement> a, int page, int size)
    {
        var Answer = a.Skip((page - 1) * size).Take(size);
        return Answer;
    }
}
public class Advertisement
{
    public required string Id { get; set; }
    public required string Source { get; init; }
    public decimal? Price { get; set; }
    public decimal? Area { get; set; }
    public int? Rooms { get; set; }
    public string? PropertyType { get; set; }
    public string? Location { get; set; }
    public DateTime PublishedAt { get; set; }
}
public static class DataAdvrb
{
    public static List<Advertisement> listings { get; } = new List<Advertisement>
    {
        new Advertisement
        {
            Id = "1",
        Source = "House.kg",
        Price = 150000,
        Area = 55,
        Rooms = 2,
        PropertyType = "Apartment",
        Location = "Center",
        PublishedAt = DateTime.Now.AddDays(-1)
    },

    new Advertisement
    {
        Id = "2",
        Source = "House.kg",
        Price = 220000,
        Area = 80,
        Rooms = 3,
        PropertyType = "Apartment",
        Location = "South",
        PublishedAt = DateTime.Now.AddDays(-2)
    },

    new Advertisement
    {
        Id = "3",
        Source = "House.kg",
        Price = 95000,
        Area = 40,
        Rooms = 1,
        PropertyType = "Apartment",
        Location = "Center",
        PublishedAt = DateTime.Now.AddDays(-3)
    },

    new Advertisement
    {
        Id = "4",
        Source = "House.kg",
        Price = 310000,
        Area = null,
        Rooms = 4,
        PropertyType = "House",
        Location = "North",
        PublishedAt = DateTime.Now.AddDays(-4)
    },

    new Advertisement
    {
        Id = "5",
        Source = "House.kg",
        Price = null,
        Area = 70,
        Rooms = 3,
        PropertyType = "Apartment",
        Location = "West",
        PublishedAt = DateTime.Now.AddDays(-5)
    },

    new Advertisement
    {
        Id = "6",
        Source = "Lalafo",
        Price = 120000,
        Area = 45,
        Rooms = 2,
        PropertyType = "Apartment",
        Location = "South",
        PublishedAt = DateTime.Now.AddDays(-1)
    },

    new Advertisement
    {
        Id = "7",
        Source = "Lalafo",
        Price = 180000,
        Area = null,
        Rooms = 3,
        PropertyType = "Apartment",
        Location = "Center",
        PublishedAt = DateTime.Now.AddDays(-2)
    },

    new Advertisement
    {
        Id = "8",
        Source = "Lalafo",
        Price = 75000,
        Area = 35,
        Rooms = 1,
        PropertyType = "Apartment",
        Location = "East",
        PublishedAt = DateTime.Now.AddDays(-3)
    },

    new Advertisement
    {
        Id = "9",
        Source = "Lalafo",
        Price = 250000,
        Area = 90,
        Rooms = 4,
        PropertyType = "House",
        Location = "North",
        PublishedAt = DateTime.Now.AddDays(-4)
    },

    new Advertisement
    {
        Id = "10",
        Source = "Lalafo",
        Price = null,
        Area = null,
        Rooms = null,
        PropertyType = "House",
        Location = "West",
        PublishedAt = DateTime.Now.AddDays(-5)
    },

    new Advertisement
    {
        Id = "11",
        Source = "Dom.kg",
        Price = 130000,
        Area = 50,
        Rooms = 2,
        PropertyType = "Apartment",
        Location = "East",
        PublishedAt = DateTime.Now.AddDays(-1)
    },

    new Advertisement
    {
        Id = "12",
        Source = "Dom.kg",
        Price = 275000,
        Area = 85,
        Rooms = 3,
        PropertyType = "Apartment",
        Location = "Center",
        PublishedAt = DateTime.Now.AddDays(-2)
    },

    new Advertisement
    {
        Id = "13",
        Source = "Dom.kg",
        Price = 60000,
        Area = null,
        Rooms = 1,
        PropertyType = "Apartment",
        Location = "South",
        PublishedAt = DateTime.Now.AddDays(-3)
    },

    new Advertisement
    {
        Id = "14",
        Source = "Dom.kg",
        Price = 195000,
        Area = 65,
        Rooms = 3,
        PropertyType = "House",
        Location = "North",
        PublishedAt = DateTime.Now.AddDays(-4)
    },

    new Advertisement
    {
        Id = "15",
        Source = "Dom.kg",
        Price = 350000,
        Area = null,
        Rooms = 5,
        PropertyType = "House",
        Location = "Center",
        PublishedAt = DateTime.Now.AddDays(-5)

        }
    };
}

