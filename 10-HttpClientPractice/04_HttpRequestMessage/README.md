
# HttpClient Headers

Small C# practice project for learning how to work with HTTP headers using `HttpClient` and `HttpRequestMessage`.

## Topics

### DefaultRequestHeaders

Headers added to `HttpClient.DefaultRequestHeaders` are automatically included in every request sent by that client.

```csharp
client.DefaultRequestHeaders.Add("User-Krustu", "MyApp/1.0");
````

### Request-specific Headers

Headers added directly to `HttpRequestMessage` apply only to that specific request.

```csharp
request.Headers.Add("X-Custom-KrustuVIP", "MyCustomHeaderValue");
```

### Request Content

`StringContent` is used to send data in the request body.

```csharp
request.Content = new StringContent(
    "{\"name\":\"Rysbek\"}",
    Encoding.UTF8,
    "application/json"
);
```

* `Encoding.UTF8` — converts the string into UTF-8 bytes.
* `application/json` — specifies that the body contains JSON.

### SendAsync

`SendAsync()` sends the configured `HttpRequestMessage` and returns an `HttpResponseMessage`.

```csharp
HttpResponseMessage response = await client.SendAsync(request);
```

This allows us to inspect the status code, headers, and response content.

## Key Difference

* `DefaultRequestHeaders` → headers for **all requests** from the client.
* `request.Headers` → headers for **one specific request**.
* `request.Content` → data sent in the **request body**.
* `SendAsync()` → sends a fully configured HTTP request.

```
```
