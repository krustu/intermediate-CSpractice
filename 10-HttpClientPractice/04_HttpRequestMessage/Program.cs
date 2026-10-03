Cousing System;
using System.Net.Http.Headers;
class Program
{
    static async Task Main()
    {
        using HttpClient client = new();

        client.DefaultRequestHeaders.Add("User-Krustu", "MyApp/1.0");

        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "https://httpbin.org/post");
        request.Headers.Add("X-Custom-KrustuVIP", "MyCustomHeaderValue");

        HttpRequestMessage request2 = new HttpRequestMessage(HttpMethod.Post, "https://httpbin.org/post");
        request2.Headers.Add("X-Custom-Header", "MyCustomHeaderValue");

        request.Content = new StringContent("{\"name\":\"Rysbek\"}",
            System.Text.Encoding.UTF8, "application/json");
        request2.Content = new StringContent("{\"name\":\"Rysbek\"}",
            System.Text.Encoding.UTF8, "application/json");

        HttpResponseMessage response = await client.SendAsync(request);
        HttpResponseMessage response2 = await client.SendAsync(request2);
        Console.WriteLine("Response from first request:");
        Console.WriteLine(response.StatusCode);
        Console.WriteLine(await response.Content.ReadAsStringAsync());
        Console.WriteLine("\nResponse from second request:");
        Console.WriteLine(response2.StatusCode);
        Console.WriteLine(await response2.Content.ReadAsStringAsync());

    }
}