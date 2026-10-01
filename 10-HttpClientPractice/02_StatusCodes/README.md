# Async HTTP Requests in C#

## What this practice demonstrates

* `HttpClient` — sends HTTP requests.
* `Select()` — creates a `Task<HttpResponseMessage>` for each URL.
* `Task.WhenAll()` — waits for all HTTP requests to complete concurrently.
* `HttpResponseMessage` — contains the response from the server.
* `StatusCode` — gets the HTTP status code.
* `IsSuccessStatusCode` — checks whether the response was successful.
* `switch` — categorizes status codes into 2xx, 3xx, 4xx and 5xx.

## Main flow

```text
URLs
 ↓
Select()
 ↓
Task<HttpResponseMessage> for each URL
 ↓
Task.WhenAll()
 ↓
HttpResponseMessage[]
 ↓
Process status codes
```

### Status code categories

* **2xx** → Success
* **3xx** → Redirection
* **4xx** → Client Error
* **5xx** → Server Error

### Key idea

```csharp
var tasks = urls.Select(x => client.GetAsync(x));
HttpResponseMessage[] responses = await Task.WhenAll(tasks);
```

`Select()` starts/creates a request task for every URL, while `Task.WhenAll()` asynchronously waits until all requests are completed.
