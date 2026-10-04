# HttpClient — Timeout & CancellationToken

This example demonstrates two ways to control HTTP request timeouts in C#.

## Key Concepts

- `HttpClient.Timeout` — global timeout for all requests made by the client.
- `CancellationTokenSource` — allows setting a timeout for a **specific request**.
- `Task.WhenAny()` — waits until the first task finishes.
- `Stopwatch` — measures how long the operation takes.
- `TaskCanceledException` — can occur when a request is cancelled because of a timeout.

## Example

```csharp
using System.Diagnostics;

using HttpClient client = new()
{
    Timeout = TimeSpan.FromSeconds(2)
};

var timer = new Stopwatch();

using var cts = new CancellationTokenSource(
    TimeSpan.FromSeconds(3));

timer.Start();

try
{
    Task<HttpResponseMessage> task1 =
        client.GetAsync("https://httpbin.org/delay/5", cts.Token);

    Task<HttpResponseMessage> task2 =
        client.GetAsync("https://httpbin.org/delay/6", cts.Token);

    var task = await Task.WhenAny(task1, task2);

    HttpResponseMessage response = await task;

    Console.WriteLine(
        $"Response: {response.StatusCode}");
}
catch (TaskCanceledException)
{
    Console.WriteLine("Request timed out.");
}

timer.Stop();

Console.WriteLine(
    $"Completed in {timer.ElapsedMilliseconds} ms");

// Uses HttpClient's global Timeout
HttpResponseMessage fastResponse =
    await client.GetAsync("https://httpbin.org/get");

Console.WriteLine(fastResponse.StatusCode);
```

## Important

`CancellationTokenSource(TimeSpan.FromSeconds(3))` cancels the requests after **3 seconds**, not 4.

`HttpClient.Timeout = 2 seconds` is the client's global timeout, so it can cancel requests even earlier.