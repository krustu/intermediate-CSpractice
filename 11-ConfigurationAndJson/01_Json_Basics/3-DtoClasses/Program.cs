using System;
using System.Text.Json;
using System.Text.Json.Serialization;
class Program
{
    static async Task Main()
    {
        string Jason = """ 
            {
              "title": null,
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

        var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        ProjectDto? dto = JsonSerializer.Deserialize<ProjectDto>(Jason, option);
        Project project = Convert(dto!);

        Console.WriteLine($"{project.Author} - {project.Title} - {project.Language}");


    }
    public static Project Convert(ProjectDto a)
    {
        return new Project
        {
            Title = a.Title ?? "noname",
            Author = a.Author ?? "N.N",
            Language = a.Language ?? "Any"
        };
    }
}


public class ProjectDto
{
    public string? Title { get; set; }
    public string? Author { get; set; }
    public string? Language { get; set; }
}

public class Project
{
    public required string Title { get; set; }
    public required string Author { get; init; }
    public required string Language { get; init; }
}




