# HTTP Status Code Handling

This example demonstrates how to handle HTTP responses in C# using `HttpClient`.

## What it demonstrates

- Sending `GET` requests with `HttpClient`
- Handling different HTTP status codes (`200`, `404`, `500`)
- Using `EnsureSuccessStatusCode()`
- Handling `HttpRequestException`
- Manually checking `IsSuccessStatusCode`
- Reading response content with `ReadAsStringAsync()`

## Key Methods

### `EnsureSuccessStatusCode()`

Throws an `HttpRequestException` when the response status code indicates an error.

```csharp
response.EnsureSuccessStatusCode();
```

### `IsSuccessStatusCode`

Returns `true` for successful status codes (`2xx`).

```csharp
if (response.IsSuccessStatusCode)
{
    // Success
}
else
{
    // Error
}
```

## Example

The program sends requests to:

- `200` → Success
- `404` → Not Found
- `500` → Internal Server Error

It demonstrates two approaches: using exceptions with `EnsureSuccessStatusCode()` and manually checking the status code with `IsSuccessStatusCode`.
