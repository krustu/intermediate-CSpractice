# HttpClientFactory

This example compares `IHttpClientFactory` with creating `HttpClient` manually.

## HttpClientFactory

```csharp
services.AddHttpClient();

IHttpClientFactory factory = provider.GetRequiredService<IHttpClientFactory>();

for (int i = 0; i < 30; i++)
{
    HttpClient client = factory.CreateClient();
    HttpResponseMessage response = await client.GetAsync("https://httpbin.org/get");
}
```

`HttpClientFactory` is provided through **Dependency Injection** and manages the underlying handlers and connection lifetime.

**Advantages:**

* Reuses underlying connections.
* Manages `HttpMessageHandler` lifetime.
* Works well with DI.
* Supports configuration, logging, resilience policies, etc.

## Manual HttpClient

```csharp
for (int i = 0; i < 30; i++)
{
    HttpClient client = new();
    HttpResponseMessage response = await client.GetAsync("https://httpbin.org/get");
}
```

Creating a new `HttpClient` for every request adds unnecessary overhead and can cause connection/socket problems in larger applications.

## Key takeaway

**`IHttpClientFactory` is the recommended approach in ASP.NET Core applications when you need managed/configurable `HttpClient` instances.**

`CreateClient()` creates a new `HttpClient`, but the factory manages the underlying handlers so connections can be reused.
