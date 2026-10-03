````markdown
# HttpClient Basics

Small C# practice project for learning the main ways to send HTTP requests using `HttpClient`.

## Topics

### 1. GetStringAsync
Sends a `GET` request and directly returns the response body as a `string`.

```csharp
string response = await Client.GetStringAsync(url);
````

### 2. GetAsync

Sends a `GET` request and returns an `HttpResponseMessage`, allowing access to:

* Status code
* Success status
* Headers
* Response content

```csharp
HttpResponseMessage response = await Client.GetAsync(url);
string content = await response.Content.ReadAsStringAsync();
```

### 3. PostAsync

Sends data to the server using a `POST` request.

```csharp
StringContent jsonContent = new StringContent(
    "{\"name\":\"Rysbek\"}",
    Encoding.UTF8,
    "application/json"
);

HttpResponseMessage response = await Client.PostAsync(url, jsonContent);
```

`StringContent` stores the request body. `Encoding.UTF8` converts the string into bytes, and `"application/json"` specifies the content type.

### 4. HttpRequestMessage + SendAsync

`HttpRequestMessage` allows creating a custom request where you can configure the method, headers, content, and other properties.

```csharp
HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
request.Headers.Add("X-Custom-Header", "MyCustomHeaderValue");

HttpResponseMessage response = await Client.SendAsync(request);
```

### Key Difference

* `GetStringAsync()` → response content as `string`
* `GetAsync()` → full `HttpResponseMessage`
* `PostAsync()` → sends content with a `POST`
* `SendAsync()` → most flexible way to send a custom HTTP request

```
```
