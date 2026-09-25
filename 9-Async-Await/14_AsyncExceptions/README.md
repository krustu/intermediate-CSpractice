# Task.WaitAll vs Task.WhenAll

A small C# example demonstrating two ways to wait for multiple tasks and handle exceptions.

### `Task.WaitAll`

```csharp
try
{
    Task.WaitAll(a1, a2, a3);
}
catch (AggregateException ex)
{
    foreach (var error in ex.InnerExceptions)
        Console.WriteLine(error.Message);
}
```

`WaitAll` is **synchronous** and blocks the current thread. Multiple exceptions are wrapped in `AggregateException`.

### `Task.WhenAll`

```csharp
try
{
    await Task.WhenAll(a1, a2, a3);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
```

`WhenAll` is **asynchronous** and should generally be preferred in async code. It returns a task that completes when all supplied tasks finish.

### Key Difference

```text
Task.WaitAll
    ↓
Blocks thread
    ↓
AggregateException

Task.WhenAll
    ↓
await
    ↓
Does not block thread
```

### Topics

`Task` · `Task.WaitAll` · `Task.WhenAll` · `async/await` · `AggregateException` · Exception Handling
