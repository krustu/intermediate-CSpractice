using System;
using System.Diagnostics;
class Program
{
    static async Task Main()
    {
        using HttpClient client = new() { Timeout = TimeSpan.FromSeconds(2) }; // общий таймаут клиента, большой
        var timer = new Stopwatch();

        // Вариант 1: таймаут конкретно для ОДНОГО запроса через CancellationTokenSource
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3)); // отменится само через 4 секунды
        timer.Start();
        try
        {

            // httpbin.org/delay/5 специально ждёт 5 секунд перед ответом — дольше, чем наши 4
            Task<HttpResponseMessage> task1 = client.GetAsync("https://httpbin.org/delay/5", cts.Token);

            Task<HttpResponseMessage> task2 = client.GetAsync("https://httpbin.org/delay/6", cts.Token);


            var task = await Task.WhenAny(task1, task2); // ждём, пока хотя бы один из запросов завершится

            HttpResponseMessage response = await task; // получаем результат завершившегося запроса
            Console.WriteLine($"Response from {response.RequestMessage.RequestUri}: {response.StatusCode}");
        }
        catch (TaskCanceledException)
        {
            Console.WriteLine("response timed out (4 seconds) — server did not respond in time.");
        }
        timer.Stop();
        Console.WriteLine($"Request completed in {timer.ElapsedMilliseconds} ms");
        // без своего CancellationToken — использует общий Timeout клиента (30 сек)
        HttpResponseMessage fastResponse = await client.GetAsync("https://httpbin.org/get");
        Console.WriteLine(fastResponse.StatusCode);
    }
}
