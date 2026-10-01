using System.Net.Http;

class Program
{
    static async Task Main()
    {
        HttpClient client = new();
        List<string> urls = new()
        {
            "https://github.com/krustu",
            "https://booster.career/?utm_source=youtube-dotnetdad&utm_medium=regular&utm_campaign=full-roadmap-csharp-desc",
            "https://www.house.kg/kupit-kvartiru",
            "https://mail.google.com/mail/u/0/#inbox",

        };

        var tasks = Task.WhenAll(urls.Select(x => client.GetAsync(x)));
        await tasks;

        foreach (var result in tasks.Result)
        {
            int code = (int)result.StatusCode;
            Console.WriteLine($"{code}: {result.StatusCode} - {result.IsSuccessStatusCode}");
        }

    }
}
