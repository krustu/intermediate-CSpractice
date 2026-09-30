# HTTP GET Request in C#

This practice demonstrates how to send an HTTP `GET` request using `HttpClient` and read the server's response.

## Code

```csharp
using System.Net.Http;

class Program
{
    static async Task Main()
    {
        HttpClient client = new HttpClient();

        HttpResponseMessage response =
            await client.GetAsync("https://web.telegram.org/k/#@findwork");

        Console.WriteLine(response.StatusCode);
        Console.WriteLine(response.IsSuccessStatusCode);

        Console.WriteLine(response.Content.Headers.ContentType);

        string body =
            await response.Content.ReadAsStringAsync();

        Console.WriteLine(body);
    }
}
```

## What is happening?

### 1. Creating `HttpClient`

```csharp
HttpClient client = new HttpClient();
```

`HttpClient` is a .NET class used to communicate with web servers over HTTP.

It can:

* send `GET`, `POST`, `PUT`, `DELETE` and other requests;
* receive HTTP responses;
* read response headers;
* read response bodies;
* work asynchronously.

---

### 2. Sending a GET request

```csharp
HttpResponseMessage response =
    await client.GetAsync("https://web.telegram.org/k/#@findwork");
```

`GetAsync()` sends an HTTP `GET` request to the specified URL.

The method returns:

```text
HttpResponseMessage
```

This object contains the server's response.

`await` waits for the HTTP operation to complete **without blocking the current thread**.

---

## `HttpResponseMessage`

The response contains several important parts:

```text
HTTP Response
│
├── Status Code
├── Headers
└── Body (Content)
```

### 3. Status code

```csharp
Console.WriteLine(response.StatusCode);
```

Returns the HTTP status code as an enum.

For example:

```text
OK
```

which corresponds to:

```text
200 OK
```

Common status codes:

| Code  | Meaning               |
| ----- | --------------------- |
| `200` | OK                    |
| `201` | Created               |
| `204` | No Content            |
| `400` | Bad Request           |
| `401` | Unauthorized          |
| `403` | Forbidden             |
| `404` | Not Found             |
| `500` | Internal Server Error |

---

### 4. Checking success

```csharp
Console.WriteLine(response.IsSuccessStatusCode);
```

Returns `true` if the status code represents a successful response.

Generally:

```text
200–299 → true
```

For example:

```text
200 OK → true
404 Not Found → false
500 Internal Server Error → false
```

This is useful when you don't want to manually check every status code.

---

### 5. Response headers

```csharp
Console.WriteLine(
    response.Content.Headers.ContentType
);
```

`ContentType` tells us what type of data the server returned.

For example:

```text
application/json; charset=utf-8
```

or:

```text
text/html; charset=utf-8
```

Common content types:

```text
application/json
text/html
text/plain
application/xml
```

---

### 6. Reading the response body

```csharp
string body =
    await response.Content.ReadAsStringAsync();
```

The response body contains the actual data returned by the server.

For example, a server might return:

```json
{
    "name": "John",
    "age": 20
}
```

After `ReadAsStringAsync()`, this JSON is just a `string`.

You can then deserialize it into a C# object.

---

# Request vs Response

It's important to understand the basic HTTP flow:

```text
C# Application
      │
      │ GET /some-resource
      ▼
   Web Server
      │
      │ HTTP Response
      ▼
C# Application
```

The request contains things such as:

```text
Method
URL
Headers
Body
```

The response contains:

```text
Status Code
Headers
Body
```

---

# Important Methods

### `GetAsync()`

Sends a GET request:

```csharp
await client.GetAsync(url);
```

### `ReadAsStringAsync()`

Reads the response body as a string:

```csharp
await response.Content.ReadAsStringAsync();
```

### `IsSuccessStatusCode`

Checks whether the response was successful:

```csharp
response.IsSuccessStatusCode
```

### `StatusCode`

Gets the HTTP status code:

```csharp
response.StatusCode
```

### `Content`

Provides access to the response body and its headers:

```csharp
response.Content
```

---

# Simplified Version

If you only need the response body, you can use:

```csharp
using HttpClient client = new HttpClient();

string body = await client.GetStringAsync(
    "https://example.com"
);

Console.WriteLine(body);
```

`GetStringAsync()` combines the request and reading the body into one operation.

---

# Key Things to Remember

```text
HttpClient
    ↓
sends HTTP requests

GetAsync()
    ↓
sends GET request

HttpResponseMessage
    ↓
contains server response

StatusCode
    ↓
HTTP status (200, 404, 500...)

IsSuccessStatusCode
    ↓
was request successful?

Content
    ↓
response body

ReadAsStringAsync()
    ↓
reads body as string
```

The main idea is:

> **HttpClient sends the request → HttpResponseMessage represents the response → Content contains the response data.**
