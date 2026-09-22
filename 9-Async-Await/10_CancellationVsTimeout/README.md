# CancellationToken Practice

A simple C# console application demonstrating asynchronous task cancellation using `CancellationTokenSource` and `CancellationToken`.

### Features
- Automatic cancellation after 4 seconds
- Async processing with `Task.Delay`
- Cancellation checks using `ThrowIfCancellationRequested()`
- Exception handling for task cancellation