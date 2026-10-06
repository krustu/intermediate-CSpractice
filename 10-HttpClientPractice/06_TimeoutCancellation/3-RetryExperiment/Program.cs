using System;
using System.Diagnostics;
using System.Net;

class Program
{
    static async Task Main()
    {
        using HttpClient client = new();
        var timer = new Stopwatch();
        timer.Start();
        HttpResponseMessage response = await GetWithRetryAsync(client, "https://httpbin.org/status/200,503");
        Console.WriteLine($"Final response status code: {(int)response.StatusCode}");
        timer.Stop();
        Console.WriteLine($"Total time taken: {timer.ElapsedMilliseconds} ms");
    }
    static async Task<HttpResponseMessage> GetWithRetryAsync(HttpClient client, string url, int maxAttempts = 4)
    {
        for (int attempt = 1; ; attempt++)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                bool transient = (int)response.StatusCode >= 500
                    || response.StatusCode == HttpStatusCode.RequestTimeout
                    || response.StatusCode == HttpStatusCode.TooManyRequests;

                if (!transient || attempt == maxAttempts)
                {
                    return response;
                }
                Console.WriteLine($"attempts {attempt}: {(int)response.StatusCode}, repeat");
            }
            catch (HttpRequestException) when (attempt < maxAttempts)
            {
                Console.WriteLine($"attempts {attempt}: response failed, repeat");
            }

            TimeSpan delay = TimeSpan.FromSeconds(Math.Pow(2, attempt - 1));
            await Task.Delay(delay);
        }
    }
}
