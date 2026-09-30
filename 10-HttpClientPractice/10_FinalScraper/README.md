# Parallel Request Practice

A C# async practice project demonstrating:

- Running multiple requests concurrently with `Task.WhenAll`
- Handling successful and failed requests
- Cancellation with `CancellationToken`
- Graceful shutdown with `Ctrl+C`
- Repeating requests in a cancellable loop
- Collecting successful results and errors

The requests simulate different delays and random failures.