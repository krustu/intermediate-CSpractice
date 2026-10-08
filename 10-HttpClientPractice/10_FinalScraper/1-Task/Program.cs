using System;
using System.Reflection;
class Program
{
    static async Task Main()
    {
        HttpClient MyClient = new();

        string url = "https://baldursgate3.game/";

        HttpResponseMessage result = await MyClient.GetAsync(url);

        Console.WriteLine(result.StatusCode);
        Console.WriteLine(result.IsSuccessStatusCode);

        string Body = await result.Content.ReadAsStringAsync();
        string first200 = Body.Substring(0, 200);
        Console.WriteLine(first200);
    }
}
