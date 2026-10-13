using System;
using System.Text.Json;
class Program
{
    static void Main()
    {
        // [] - List 
        // {} - class

        string Jason = """ 
            {
              "title": "RealEstateAggregator",
              "isNew": true,
              "Folders": 9,
              "author": "Krustu",
              "Language": "C#",
              "deployedUrl": null,
              "contacts": {
                "phone": "+996555333333",
                "Tg": "@KRustu12"
              }
            }
            """;

        var Option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        MyProject? back = JsonSerializer.Deserialize<MyProject>(Jason, Option);
        Console.WriteLine(back!.Title);
        Console.WriteLine(back.Contacts!.Tg);

        string again = JsonSerializer.Serialize(back, new JsonSerializerOptions { WriteIndented = true });
        Console.WriteLine(again);

    }
}
public class MyProject
{
    public required string Title { get; set; }
    public bool IsNew { get; set; }
    public int Folders { get; set; }
    public string? Author { get; set; }
    public required string Language { get; set; }
    public string? deployedUrl { get; set; }
    public Contacts? Contacts { get; set; }
}
public class Contacts
{
    public string? phone { get; set; }
    public string? Tg { get; set; }
}
