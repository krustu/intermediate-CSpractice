using System;
class Program
{
    static async Task Main()
    {
        using HttpClient client = new();
        string url = "https://httpbin.org/anything";
        using HttpRequestMessage request =
            new(HttpMethod.Get, url);
        request.Headers.Add("X-Custom-Krustu", "KrustuFromSHN");


        using HttpResponseMessage response = await client.SendAsync(request);
        string BodyText = await response.Content.ReadAsStringAsync();
        Console.WriteLine(BodyText);

    }
}