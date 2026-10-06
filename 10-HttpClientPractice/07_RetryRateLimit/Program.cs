using System;
using System.Diagnostics;
using System.Net;
class Program
{
    static async Task Main()
    {
        using HttpClient client = new();

        List<string> urls = Enumerable.Range(1, 10)
            .Select(i => $"https://httpbin.org/get?i={i}")
            .ToList();

        // Вариант А: все сразу (всплеск)
        var sw = Stopwatch.StartNew();
        await Task.WhenAll(urls.Select(u => GetWithRetryAsync(client, u)));
        Console.WriteLine($"all: {sw.ElapsedMilliseconds} ms");

        // Вариант Б: по одному, с паузой
        sw.Restart();
        foreach (string url in urls)
        {
            await GetWithRetryAsync(client, url);
            await Task.Delay(500);
        }
        Console.WriteLine($"one by one with delay: {sw.ElapsedMilliseconds} ms");

        // Читаем Retry-After (httpbin умеет вернуть заголовок, который мы попросим)
        HttpResponseMessage r = await GetWithRetryAsync(client, "https://httpbin.org/response-headers?Retry-After=3");
        TimeSpan? wait = r.Headers.RetryAfter?.Delta;
        Console.WriteLine($"Server requests to wait: {wait}");
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
