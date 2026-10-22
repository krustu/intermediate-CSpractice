using System;
using System.Text.Json;
using System.Text.Json.Serialization;
class Program
{
    static void Main()
    {
        Warrior p1 = new Warrior { Title = "John", Age = 32, Hp = 230 };

        string WarriorJson = JsonSerializer.Serialize(p1, new JsonSerializerOptions { WriteIndented = true });
        Console.WriteLine(WarriorJson);
    }
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