using System;
using System.Text.Json;
class Program
{
    static void Main()
    {
        string[] inputs =
{
    """{ "title": "ok", "folders": 9 }""",        // нормальный
    """{ "title": "ok", "folders": 9, }""",       // лишняя запятая
    """{ "title": "ok", "folders": "nine" }""",   // строка вместо числа
    ""                                            // пусто
};
        List<Project> Lists = new();
        for (int a = 0; a < inputs.Length; a++)
        {
            try
            {
                ProjectDto? dto = ParseSafe(inputs[a], $"test-{a + 1}");
                if (dto == null)
                {
                    Console.WriteLine("Skipping");
                    continue;
                }

                var objects = Convert(dto);
                Lists.Add(objects);
            }
            catch
            {
                Console.WriteLine();
            }

        }


    }
    static ProjectDto? ParseSafe(string json, string source)
    {
        try
        {


            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            return JsonSerializer.Deserialize<ProjectDto>(json, options);


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
    static Project Convert(ProjectDto a)
    {
        return new Project
        {
            Title = a.Title ?? "NoName",
            Folders = a.Folders
        };
    }
}
class ProjectDto
{
    public string? Title { get; set; }
    public int Folders { get; set; }
}
class Project
{
    public required string Title { get; set; }
    public required int Folders { get; set; }

}