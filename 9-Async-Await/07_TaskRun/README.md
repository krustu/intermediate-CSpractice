# C# Async/Await – Task.Run and Legacy Methods

## 📌 Overview

This project demonstrates how to work with asynchronous methods in C# using `Task`, `Task<T>`, `Task.Run()`, `async`, and `await`.

The main goal is to understand how legacy synchronous code can be wrapped in a `Task` and how asynchronous methods behave when using `Task.Run()`.

## 🛠️ Concepts Covered

* `Task<string>` – representing an asynchronous operation that returns a string.
* `Task.Run()` – executing synchronous work on a Thread Pool thread.
* `async` and `await` – working with asynchronous operations.
* `Thread.Sleep()` vs. `Task.Delay()`.
* `Environment.CurrentManagedThreadId` – checking the current managed thread ID.
* Legacy synchronous methods and asynchronous wrappers.

## 💻 Code Examples

### 1. LegacySlowMethod()

```csharp
static Task<string> LegacySlowMethod()
{
    return Task.Run(() =>
    {
        Console.WriteLine(
            $"Worker thread: {Environment.CurrentManagedThreadId}");

        Thread.Sleep(2000);

        return "Ready";
    });
}
```

This method demonstrates how to wrap legacy synchronous code inside `Task.Run()`.

* `Task.Run()` schedules the work on a Thread Pool thread.
* `Thread.Sleep(2000)` blocks the worker thread for 2 seconds.
* The method returns a `Task<string>` representing the operation.

This approach can be useful when dealing with existing synchronous code that cannot easily be rewritten.

### 2. BugBadMethod()

```csharp
static async Task<string> BugBadMethod()
{
    return await Task.Run(async () =>
    {
        await Task.Delay(1000);
        return "Ready";
    });
}
```

This method demonstrates an unnecessary combination of `async`, `await`, and `Task.Run()`.

* `Task.Delay(1000)` asynchronously waits for 1 second without blocking a thread during the delay.
* `Task.Run()` is unnecessary for this naturally asynchronous operation.
* `async` and `await` inside the method are also redundant because the method only forwards the result.

A simpler implementation would be:

```csharp
static async Task<string> BetterMethod()
{
    await Task.Delay(1000);
    return "Ready";
}
```

Or, if no additional asynchronous work is needed:

```csharp
static Task<string> BetterMethod()
{
    return Task.FromResult("Ready");
}
```

The second version returns an already-completed task.

## ▶️ Main Method

The `Main()` method calls both operations sequentially:

```csharp
var result = await LegacySlowMethod();
var Resu2 = await BugBadMethod();
```

Each operation is awaited before the next one starts.

**Important:** Although both methods use asynchronous patterns, the total execution time is approximately 3 seconds (2 seconds + 1 second), excluding minor overhead.

## 🧠 Key Takeaways

1. `Task<T>` represents an operation that will provide a result of type `T`.
2. `Task.Run()` is useful for offloading CPU-bound or blocking synchronous work.
3. `Thread.Sleep()` blocks the current thread, while `Task.Delay()` provides a non-blocking asynchronous delay.
4. `async` and `await` are not automatically beneficial when used together with `Task.Run()`.
5. Naturally asynchronous operations generally do not need `Task.Run()`.
6. `await` allows an asynchronous method to suspend while waiting for a task to complete.

## 🎯 Purpose

This project is part of my C# learning journey, focused on understanding asynchronous programming, task-based operations, and writing cleaner and more efficient async code.

## 🧰 Technologies

* C#
* .NET
* Task Parallel Library (TPL)
* Visual Studio
