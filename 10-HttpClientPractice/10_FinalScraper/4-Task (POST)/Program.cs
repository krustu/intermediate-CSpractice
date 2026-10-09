using System;
class Program
{
    static async Task Main()
    {
        var client = new HttpClient();
        string url = "https://httpbin.org/post";
        StringContent OurJson = new StringContent("{\"name\":\"Rysbek\"}",
        System.Text.Encoding.UTF8, "application/json");

        HttpResponseMessage response = await
            client.PostAsync(url, OurJson);


        string responseBody = await
            response.Content.ReadAsStringAsync();

        Console.WriteLine(response.IsSuccessStatusCode);
        Console.WriteLine(response.StatusCode);
        Console.WriteLine(response.Content.Headers);

        Console.ReadKey();
        Console.WriteLine(responseBody);
    }
}