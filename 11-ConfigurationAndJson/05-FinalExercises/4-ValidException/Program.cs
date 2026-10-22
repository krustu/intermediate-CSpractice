using System;
using System.Text.Json;
using System.Text.Json.Serialization;
class Program
{
    static async Task Main()
    {
        List<Warrior> Brawlers =
            new List<Warrior> {
            new Warrior { Title = "John", Age = 32, Hp = 230 },
            new Warrior { Title = "Krustu", Age = 21, Hp = 120 },
            new Warrior { Title = "Aby", Age = 22, Hp = 210 },
            new Warrior { Title = "Lon", Age = 52, Hp = 130 },
            new Warrior {},
            new Warrior { Title = "Asilia", Age = 25, Hp = 530}};

        List<string> Jsons = new();

        //Serialize means make a own json
        Console.WriteLine("All Jsons");
        for (int a = 0; a < Brawlers.Count; a++)
        {
            string WarriorJson = JsonSerializer.Serialize(Brawlers[a], new JsonSerializerOptions { WriteIndented = true });

            Console.WriteLine(WarriorJson);
            Jsons.Add(WarriorJson);
        }



        //Deserialize means get json

        List<Brawler> answer = await JsonDeserializeLoop(Jsons);

        Console.ReadKey();

        Console.WriteLine($"Count - {answer.Count}");
        foreach (var a in answer)
        {
            Console.WriteLine(a.Nickanme);
        }



    }
    static DtoBrawler? ParseSafe(string json, string source)
    {
        try
        {
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            return JsonSerializer.Deserialize<DtoBrawler>(json, options);
        }
        catch (JsonException ex)
        {
            string start = json.Length > 20 ? json[..20] : json;
            Console.WriteLine($"[WARN] source = {source} path = {ex.Path} - line : {ex.LineNumber} {start}");
            return null;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }

    }
    static async Task<List<Brawler>> JsonDeserializeLoop(List<string> json)
    {
        List<Brawler> AnswerJsons = new();
        int index = 1;
        for (int a = 0; a < json.Count; a++)
        {
            try
            {
                DtoBrawler? inputs = ParseSafe(json[a], $"test-{a + 1}");
                if (inputs == null)
                {
                    Console.WriteLine("Skipping");
                    continue;
                }
                Brawler EachObjects = Convert(inputs);
                Console.WriteLine($"{index} :{EachObjects.Nickanme} - {EachObjects.CurrentAge} saved!");
                AnswerJsons.Add(EachObjects);
                await Task.Delay(1000);
                index++;
            }
            catch
            {
                // here chould be Exception for concellation but its unecessary complications
            }
        }
        return AnswerJsons;
    }
    static Brawler Convert(DtoBrawler a)
    {
        return new Brawler
        {
            Nickanme = a.Name ?? "NoName",
            CurrentAge = a.Age
        };
    }
}
class Brawler
{
    public required string Nickanme { get; init; }
    public required int CurrentAge { get; init; }
}
class DtoBrawler
{
    [JsonPropertyName("title")]
    public string? Name { get; set; } = "Unknown";

    public int Age { get; set; }
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