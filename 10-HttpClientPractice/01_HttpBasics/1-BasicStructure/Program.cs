using System.Net.Http;

class Program
{
    static async Task Main()
    {
        HttpClient client = new HttpClient();

        HttpResponseMessage response = await client.GetAsync("https://web.telegram.org/k/#@findwork");

        Console.WriteLine(response.StatusCode);              // например: OK
        Console.WriteLine(response.IsSuccessStatusCode);     // true, потому что StatusCode это 200

        Console.WriteLine(response.Content.Headers.ContentType); // например: application/json; charset=utf-8

        string body = await response.Content.ReadAsStringAsync(); // тело ответа как текст
        Console.WriteLine(body);
    }
}