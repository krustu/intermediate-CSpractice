using System;
using System.Text.Json;
using System.Text.Json.Serialization;
class Program
{
    static void Main()
    {
        Warrior p1 = new Warrior { Title = "John", Age = 32, Hp = 230 };
        //Serialize means make a own json
        string WarriorJson = JsonSerializer.Serialize(p1, new JsonSerializerOptions { WriteIndented = true });
        Console.WriteLine(WarriorJson);

        //Deserialize means get json
        var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        DtoBrawler? b1 = JsonSerializer.Deserialize<DtoBrawler>(WarriorJson, option);
        Console.WriteLine(b1.Name);
        Console.WriteLine(b1.Agea);

    }
}
class DtoBrawler
{
    [JsonPropertyName("title")]
    public string? Name { get; set; } = "Unknown";

    public int Agea { get; set; } // this parameter doesnt exist in json so we get 0 or null if its string
}
class Warrior
{
    [JsonPropertyName("title")]
    public string? Title { get; set; } = "";

    [JsonPropertyName("hot_Point")]
    public int Hp { get; set; }

    [JsonPropertyName("age")]
    public int Age { get; set; }
}