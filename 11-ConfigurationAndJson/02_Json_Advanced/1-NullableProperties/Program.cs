using System.Reflection.Metadata;
using System.Text.Json;
using System.Text.Json.Serialization;

class Program
{
    static async Task Main()
    {
        string Json =
            """
            {
              "full_name": "krustu/RPG-manager",
              "open_issues_count": 2,
              "created_at": "2025-01-10T12:00:00Z",
              "clone_url": "https://github.com/krustu/RPG-manager.git"
            }
            """;
        var options = new JsonSerializerOptions
        {
            // правило превращения имён C# в имена JSON и обратно
            PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
            WriteIndented = true //вывод с отступами, читаемый
        };
        RepoDto? repo = JsonSerializer.Deserialize<RepoDto>(Json, options); // convert first time into readable for class

        Repo p1 = Convert(repo!);

        Console.WriteLine(p1.Name);
        Console.WriteLine(p1.CloneUrl);
        Console.WriteLine(p1.CreatedDate);
        Console.WriteLine(JsonSerializer.Serialize(p1, options)); // convert vice versa 
    }

    static Repo Convert(RepoDto a)
    {
        return new Repo
        {
            Name = a.FullName ?? "NoName",
            OpenIssuesCount = a.OpenIssuesCount,
            CreatedDate = a.CreatedAtx ?? "0000-00-0000",
            CloneUrl = a.CloneUrl ?? "Url not returned"
        };
    }
}
public class Repo
{
    public required string Name { get; set; }
    public int OpenIssuesCount { get; set; }
    public required string CreatedDate { get; set; }
    public required string CloneUrl { get; set; }
}
public class RepoDto
{

    public string? FullName { get; set; }
    public int OpenIssuesCount { get; set; }
    [JsonPropertyName("created_at")]
    public string? CreatedAtx { get; set; }
    public string? CloneUrl { get; set; }
}
