using System;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        using var client = new HttpClient();
        client.DefaultRequestHeaders.Add("User-Agent", "KrustuSHN/1.0");

        // 1. API: данные для программы
        string json = await client.GetStringAsync("https://api.github.com/repos/dotnet/runtime");
        Console.WriteLine($"JSON: {json.Length} Symbols");
        Console.WriteLine($"Have a field stargazers_count: {json.Contains("\"stargazers_count\"")}");
        int pos = json.IndexOf("\"stargazers_count\"");
        Console.WriteLine(json.Substring(pos, 30));   // имя поля и число рядом

        // 2. HTML: страница для человека
        string html = await client.GetStringAsync("https://github.com/dotnet/runtime");
        Console.WriteLine($"HTML: {html.Length} Symbols");
        Console.WriteLine($"Have a field stargazers: {html.Contains("stargazers")}");
        Console.WriteLine(html.Substring(0, 300));



        //tests
        string before = """
<div class="listing"><p class="price">50000</p></div>
<div class="listing"><p class="price">60000</p></div>
""";

        string after = """
<div class="card"><span class="cost">50000</span></div>
""";
        Console.ReadKey();
        Console.WriteLine($"Before: {CountListings(before)}");
        Console.ReadKey();
        Console.WriteLine($"After: {CountListings(after)}");

        string changedPage = """
<html>
    <body>
        <div>Some content</div>
    </body>
</html>
""";
        Console.ReadKey();
        Console.WriteLine($"Changed page: {CountListings(changedPage)}");
    }
    public static int CountListings(string html)
    {
        int count = 0;
        int index = 0;
        try
        {
            while ((index = html.IndexOf("class=\"listing\"", index)) != -1)
            {
                count++;
                index += "class=\"listing\"".Length;
            }
            if (count <= 0)
                throw new InvalidOperationException("page structure changed");
            return count;
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine(ex.Message);
            return 0;
        }
    }
}