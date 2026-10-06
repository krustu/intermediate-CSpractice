# HTTP Requests: Concurrency & Retry

A C# example demonstrating concurrent requests, sequential requests with delays, retry logic, and the `Retry-After` header.

## What it demonstrates

- `Task.WhenAll` for concurrent requests
- Sequential requests with `Task.Delay`
- Retry logic for transient HTTP errors
- Exponential backoff: `1s → 2s → 4s`
- Handling `Retry-After` response headers
- Measuring execution time with `Stopwatch`

## Key difference

**Concurrent:**
text
10 requests → sent almost simultaneously
```

**Sequential:**
text
Request → wait 500ms → Request → wait 500ms → ...
```

The program compares both approaches and reads the server's suggested `Retry-After` delay.