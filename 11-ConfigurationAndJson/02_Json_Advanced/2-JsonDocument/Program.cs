using System;
using System.Text.Json;
class Program
{
    static void Main()
    {

        string json = """
[
  { "name": "a", "stargazers_count": 3, "language": "C#" },
  { "name": "b", "stargazers_count": 0, "language": null },
  { "name": "c", "stargazers_count": 7 }
]
""";

        using JsonDocument document = JsonDocument.Parse(json);
        JsonElement root = document.RootElement;        // это МАССИВ [ ]

        int total = 0;

        foreach (JsonElement repo in root.EnumerateArray())   // repo = один объект { }
        {
            string name = repo.GetProperty("name").GetString()!;
            int stars = repo.GetProperty("stargazers_count").GetInt32();
            total += stars;

            string language = "unknown";
            if (repo.TryGetProperty("language", out JsonElement lang) && lang.ValueKind != JsonValueKind.Null)
                language = lang.GetString()!;

            Console.WriteLine($"{name}: {stars} ({language})");
        }

        Console.WriteLine($"total: {total}");

    }
}
/*Без классов и DTO, только JsonDocument:

Пройди по массиву и для каждого репозитория выведи имя: звёзды (язык).
Если язык null или ключа language нет вообще, пиши unknown.
В конце выведи сумму звёзд.

Ожидаемый вывод:

a: 3 (C#)
b: 0 (unknown)
c: 7 (unknown)
total: 10

Пришли код и вывод.*/