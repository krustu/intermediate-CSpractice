using System;
class Program
{
    static async Task Main()
    {
        using HttpClient client = new();

        List<string> urls = new()
        {
            "https://httpbin.org/status/200",
            "https://httpbin.org/status/404",
            "https://httpbin.org/status/500"
        };
        foreach (var url in urls)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                Console.WriteLine($"URL: {url}, Status Code: {response.StatusCode}");

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Request error for URL {url}: {e.Message}");
            }
        }
        Console.WriteLine("\nHand checking for the status codes:");
        /// Hand checking for the status codes
        foreach (var url in urls)
        {
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"URL: {url}, Content: {content}");
            }
            else
            {
                Console.WriteLine($"URL: {url}, Error: {response.StatusCode}");
            }
        }
    }
}
