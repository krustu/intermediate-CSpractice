# HTTP Retry with Exponential Backoff

A simple C# example of retrying failed HTTP requests using `HttpClient`.

## What it demonstrates

- Sending HTTP GET requests with `HttpClient`
- Retrying transient errors (`5xx`, `408`, `429`)
- Handling `HttpRequestException`
- Limiting the number of attempts
- Exponential backoff between retries
- Measuring total request time with `Stopwatch`

## How it works

The `GetWithRetryAsync` method retries the request up to **4 times** when a temporary error occurs.

The delay increases after each failed attempt:

```text
1s → 2s → 4s
```

The final response is returned when the request succeeds or the maximum number of attempts is reached.

## Example

```text
Final response status code: 200
Total time taken: 3xxx ms
```

The test URL randomly returns `200` or `503`, making it useful for testing the retry logic.