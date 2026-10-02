# HttpClient: Reuse vs New Instance

This example compares two approaches to using `HttpClient` for 20 HTTP requests.

## 1. Reusing one HttpClient

```csharp
using var mainClient = new HttpClient();

for (int i = 0; i < 20; i++)
{
    await mainClient.GetAsync("https://httpbin.org/get");
}
```

One `HttpClient` instance is reused for all requests.

**Advantages:**

* Reuses connections.
* Less overhead.
* Recommended approach for multiple requests.

## 2. Creating a new HttpClient each time

```csharp
for (int i = 0; i < 20; i++)
{
    using var client = new HttpClient();
    await client.GetAsync("https://httpbin.org/get");
}
```

A new `HttpClient` is created and disposed after every request.

**Disadvantages:**

* More overhead.
* Connections cannot be reused efficiently.
* Can lead to socket/connection problems in larger applications.

## Stopwatch

`Stopwatch` measures how long each approach takes:

```csharp
var stopwatch = Stopwatch.StartNew();

stopwatch.Stop();
Console.WriteLine($"Time taken: {stopwatch.ElapsedMilliseconds} ms");
```

## Key takeaway

For repeated HTTP requests, **reuse `HttpClient` instead of creating a new instance for every request**.

`using` ensures that `IDisposable.Dispose()` is called when the object leaves its scope.
