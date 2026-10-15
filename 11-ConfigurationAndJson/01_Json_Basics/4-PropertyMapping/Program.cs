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

        RepoDto? repo = JsonSerializer.Deserialize<RepoDto>(Json);

        Repo p1 = Convert(repo!);

        Console.WriteLine(p1.Name);
        Console.WriteLine(p1.CloneUrl);
        Console.WriteLine(p1.CreatedDate);
        Console.WriteLine(JsonSerializer.Serialize(p1));
    }

    static Repo Convert(RepoDto a)
    {
        return new Repo
        {
            Name = a.Name ?? "NoName",
            OpenIssuesCount = a.OpenIssuesCount,
            CreatedDate = a.CreatedDate ?? "0000-00-0000",
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
    [JsonPropertyName("full_name")]
    public string? Name { get; set; }

    [JsonPropertyName("open_issues_count")]
    public int OpenIssuesCount { get; set; }

    [JsonPropertyName("created_at")]
    public string? CreatedDate { get; set; }

    [JsonPropertyName("clone_url")]
    public string? CloneUrl { get; set; }
}
