using System;
class Program
{
    static async Task Main()
    {
        using HttpClient client = new();
        string url = "https://httpbin.org/user-agent";
        string before = await client.GetStringAsync(url);
        Console.WriteLine("Before User-Agent change:");
        Console.WriteLine(before);

        client.DefaultRequestHeaders.Add("User-Agent", "KrustuSHN / 1.0");

        string after = await client.GetStringAsync(url);
        Console.WriteLine("After User-Agent change:");
        Console.WriteLine(after);

        Console.ReadKey();

        await task2();
    }
    static async Task task2()
    {
        using HttpClient client = new();
        string url = "https://api.github.com/repos/dotnet/runtime";
        HttpResponseMessage before = await client.GetAsync(url);
        Console.WriteLine("Before User-Agent change:");
        Console.WriteLine(await before.Content.ReadAsStringAsync());
        Console.WriteLine("Status Code: " + before.StatusCode);

        client.DefaultRequestHeaders.Add("User-Agent", "KrustuSHN / 1.0");

        HttpResponseMessage after = await client.GetAsync(url);
        Console.WriteLine("After User-Agent change:");
        Console.WriteLine(await after.Content.ReadAsStringAsync());
        Console.WriteLine("Status Code: " + after.StatusCode);
    }
}