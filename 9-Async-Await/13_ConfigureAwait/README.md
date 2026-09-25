# ConfigureAwait(false)

A small C# example demonstrating `ConfigureAwait(false)` in a reusable library class.

### What it demonstrates

* `ConfigureAwait(false)` prevents unnecessary synchronization-context capture.
* Useful in **library code** where returning to the original context is not required.
* Applied to multiple `await` calls in the async chain.
* `DataFetcher` can be reused by different types of applications.

### Example

```csharp
public async Task<string> LoadAsync(string url)
{
    using var client = new HttpClient();

    var data = await client.GetStringAsync(url)
        .ConfigureAwait(false);

    var processed = await ProcessData(data)
        .ConfigureAwait(false);

    return processed;
}
```

### Key Concept

```text
await
  ↓
ConfigureAwait(false)
  ↓
Do not require the original SynchronizationContext
```

> `ConfigureAwait(false)` is commonly useful in library code, but it is **not a rule that every `await` must use it**. In application/UI code, the original context may be needed.

### Topics

`async/await` · `ConfigureAwait(false)` · `HttpClient` · Library Design · SynchronizationContext
