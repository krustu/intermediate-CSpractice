# # async Task vs async void

A small C# console project demonstrating how exceptions behave differently in `async Task` and `async void` methods.

### Key Difference

* `async Task` → exception can be caught with `try/catch` when awaited.
* `async void` → exception cannot be caught by the caller's `try/catch`.

### Example

```csharp
try
{
    await GoodMethod(); // Exception is caught
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

try
{
    BadMethod(); // Exception is not caught here
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

static async Task GoodMethod()
{
    await Task.Delay(500);
    throw new Exception("From Task");
}

static async void BadMethod()
{
    await Task.Delay(500);
    throw new Exception("From void");
}
```

### Rule

Prefer:

```csharp
async Task Method()
```

instead of:

```csharp
async void Method()
```

`async void` should generally only be used for event handlers.

### Topics

`async/await` · `Task` · `async void` · Exception Handling
