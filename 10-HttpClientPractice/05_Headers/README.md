
# HTTP Authorization Header

Small C# practice project demonstrating how to use an `Authorization` header with `HttpClient`.

## Authorization Header

A Bearer token can be added to a specific `HttpRequestMessage`:

```csharp
request.Headers.Authorization =
    new AuthenticationHeaderValue("Bearer", "SECRET-INTERNAL-TOKEN-12345");
````

This token is sent only with this particular request.

## Important

Using the same `HttpClient` does **not** mean that headers added to one `HttpRequestMessage` are automatically sent with other requests.

```csharp
request.Headers.Authorization = ...
```

affects only `request`.

Therefore:

* Request #1 → contains the Bearer token.
* Request #2 → does **not** contain the Bearer token.
* `HttpClient` itself remains reusable for both requests.

## Key Idea

`HttpClient` is the reusable HTTP client, while `HttpRequestMessage` represents one specific HTTP request and its individual headers, method, URL, and content.

