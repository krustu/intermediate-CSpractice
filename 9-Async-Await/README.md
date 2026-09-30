Absolutely. I’ll preserve the technical meaning and turn it into a clean GitHub-style `README.md` with sections, code examples, tables, and key takeaways.

# Async/Await, Task, CancellationToken — Summary

A practical summary of asynchronous programming in C# based on theory and experiments.

---

## 1. Thread vs Task

### `Thread`

`Thread` represents an actual OS thread.

Creating thousands of threads is expensive because every thread requires memory and OS resources.

### `Task`

`Task` is **not a thread**.

It represents an operation that may execute using threads from the **ThreadPool**. The runtime decides when and where the work should execute.

Therefore:

* Thousands of `Task` objects are normal.
* Thousands of dedicated `Thread` objects are expensive.
* A `Task` does not necessarily mean "one thread".

> **Key idea:** `Task` represents work; `Thread` represents an execution resource.

---

## 2. `Task` / `Task<T>`

There are two common forms:

```csharp
Task
```

Represents an asynchronous operation without a return value.

```csharp
Task<int>
```

Represents an asynchronous operation that returns an `int`.

### `.Result`

```csharp
int result = task.Result;
```

`.Result` blocks the current thread until the task completes.

It can also wrap exceptions inside `AggregateException`.

### `.IsCompleted`

```csharp
if (task.IsCompleted)
{
    // Task has finished
}
```

`IsCompleted` is simply a status check. It does **not** wait for the task.

---

# 3. `async` / `await`

The compiler transforms an `async` method into a **state machine**.

Conceptually, every `await` is a possible suspension point:

```text
Start
  ↓
Execute code
  ↓
await
  ↓
Operation not finished?
  ↓
Return control to caller
  ↓
Operation completes
  ↓
Continue execution
```

The important part is that `await` does **not** block the current thread while an asynchronous operation is waiting.

### Important nuance

The `async` keyword itself does **not** automatically make code asynchronous.

For example:

```csharp
async Task Test()
{
    Thread.Sleep(5000);
}
```

There is no real asynchronous operation here.

`Thread.Sleep()` blocks the thread, and because there is no real `await`, the method executes synchronously from the caller's perspective.

Compare:

```csharp
async Task Test()
{
    await Task.Delay(5000);
}
```

with:

```csharp
async Task Test()
{
    Thread.Sleep(5000);
}
```

The first one can release the thread while waiting.

The second one blocks the thread.

> **`async` without a meaningful `await` does not magically make blocking code asynchronous.**

---

# 4. I/O-bound vs CPU-bound

Understanding this distinction is one of the most important parts of async programming.

## I/O-bound

Examples:

* HTTP requests
* Database queries
* File operations
* Network communication

The CPU often spends most of the time **waiting** for something external.

Async is very useful here.

```csharp
var response = await httpClient.GetAsync(url);
```

While the network request is waiting, the thread can be used for other work.

---

## CPU-bound

Examples:

* Complex calculations
* Image processing
* Compression
* Large loops
* Mathematical calculations

Here the CPU is actually doing the work.

`async` does not make CPU calculations faster.

An experiment showed:

```text
Sync:  690 ms
Async: 683 ms
```

The difference is statistically insignificant.

### `Task.Run`

CPU-bound work can be moved away from the current thread:

```csharp
await Task.Run(() => HeavyCalculation());
```

This can keep the main thread responsive, but it does **not** make the calculation itself magically faster.

> `Task.Run` is about **where the work executes**, not about making CPU work inherently faster.

---

# 5. `Task.Delay` vs `Thread.Sleep`

These two methods behave very differently.

### `Thread.Sleep`

```csharp
Thread.Sleep(1000);
```

The current thread is blocked for one second.

### `Task.Delay`

```csharp
await Task.Delay(1000);
```

The thread is not occupied during the delay.

An experiment with **500 parallel tasks** demonstrated the difference:

| Method         |      Time |
| -------------- | --------: |
| `Thread.Sleep` | 42,232 ms |
| `Task.Delay`   |  2,039 ms |

That's approximately **21× faster** in this particular experiment.

The reason is thread-pool exhaustion caused by blocking hundreds of threads with `Thread.Sleep`.

> For asynchronous waiting, use `Task.Delay`, not `Thread.Sleep`.

---

# 6. `Task.WhenAll`

`Task.WhenAll` waits until **all tasks** are completed.

Example:

```csharp
var tasks = new[]
{
    GetDataAsync(),
    GetDataAsync(),
    GetDataAsync()
};

var results = await Task.WhenAll(tasks);
```

The operations can execute concurrently.

### Result order

Results are returned in the **same order as the input tasks**, regardless of which task actually finishes first.

```text
Task 1 ────────────────┐
Task 2 ────────┐       │
Task 3 ────┐   │       │
           ↓   ↓       ↓
        Completion

Results:
[Task1, Task2, Task3]
```

### Exceptions

A subtle but important detail:

```csharp
await Task.WhenAll(tasks);
```

When awaited, only the **first observed exception** is thrown to the caller.

Which exception becomes the one observed is not guaranteed to be based on argument order; completion is concurrent.

However, using:

```csharp
Task.WaitAll(tasks);
```

or:

```csharp
task.Wait();
```

or:

```csharp
task.Result;
```

can expose an `AggregateException` containing multiple exceptions through:

```csharp
AggregateException.InnerExceptions
```

---

# 7. `Task.WhenAny`

`Task.WhenAny` completes when **any one** of the supplied tasks finishes.

```csharp
Task completed = await Task.WhenAny(tasks);
```

Typical use cases:

* Racing multiple operations
* Timeouts
* Taking the first available result

Conceptually:

```text
Task A ────────────────
Task B ────────✓
Task C ───────────────────

             ↓
        WhenAny finishes
```

---

# 8. `Task.Run`

`Task.Run` is appropriate mainly for:

### CPU-bound work

```csharp
await Task.Run(() => HeavyCalculation());
```

### Blocking synchronous APIs

If an old library provides only a blocking API:

```csharp
await Task.Run(() => LegacyBlockingMethod());
```

This can prevent the calling thread from being blocked.

### What you should NOT do

Do not wrap an already asynchronous I/O operation in `Task.Run`:

```csharp
await Task.Run(() => Task.Delay(1000));
```

This provides no meaningful benefit.

The asynchronous operation is already asynchronous.

> Don't use `Task.Run` just because a method contains `Task`.

---

# 9. `CancellationToken`

Cancellation in .NET is **cooperative**.

You don't forcibly kill a task.

Instead, the code periodically checks whether cancellation was requested.

### `IsCancellationRequested`

```csharp
while (!token.IsCancellationRequested)
{
    // Work
}
```

### `ThrowIfCancellationRequested`

```csharp
token.ThrowIfCancellationRequested();
```

If cancellation was requested, an `OperationCanceledException` is thrown.

---

## `Task.Delay` + CancellationToken

```csharp
await Task.Delay(5000, token);
```

Without a token, the code may wait the entire 5 seconds.

With a cancellation token, the delay can stop immediately when cancellation is requested.

---

# 10. `CancellationTokenSource`

A `CancellationTokenSource` controls cancellation.

```csharp
using var cts = new CancellationTokenSource();

CancellationToken token = cts.Token;
```

Another part of the application can request cancellation:

```csharp
cts.Cancel();
```

The code using the token must react to it.

```text
CancellationTokenSource
          │
          ↓
      Cancel()
          │
          ↓
  CancellationToken
          │
          ↓
    Running operation
          │
          ↓
     Stops itself
```

---

# 11. Cancellation vs Timeout

`TaskCanceledException` is a subclass of `OperationCanceledException`.

Sometimes we need to distinguish:

* User requested cancellation.
* Timeout occurred.

One useful technique is:

```csharp
using var linkedCts =
    CancellationTokenSource.CreateLinkedTokenSource(
        userToken,
        timeoutToken
    );
```

Now both cancellation sources are connected to one token.

After cancellation, you can inspect the original sources to determine which one actually triggered.

---

# 12. Deadlocks and `.Result` / `.Wait()`

A classic deadlock can happen when synchronous blocking is mixed with asynchronous code:

```csharp
var result = SomeAsyncMethod().Result;
```

This is especially dangerous in environments with a `SynchronizationContext`, such as:

* UI applications
* Older ASP.NET applications

The problem occurs when the continuation is waiting for a context that is itself blocked by `.Result`.

### Console applications

Console applications normally don't have the same `SynchronizationContext`.

An experiment confirmed that mixed code using `.Result` in a console application did not deadlock in the same way.

Nevertheless:

> Prefer `await` all the way instead of synchronously blocking asynchronous code.

---

# 13. `async void`

Avoid `async void` except for event handlers.

### Bad

```csharp
async void DoSomething()
{
    await Task.Delay(1000);
}
```

The caller cannot `await` it.

More importantly, exceptions from `async void` cannot be handled by a surrounding `try/catch` in the same way as exceptions from `Task`-returning methods.

Example:

```csharp
try
{
    DoSomething();
}
catch
{
    // May NOT catch exception from async void
}
```

### Better

```csharp
async Task DoSomething()
{
    await Task.Delay(1000);
}
```

Now the caller can:

```csharp
try
{
    await DoSomething();
}
catch
{
    // Exception can be handled here
}
```

### Rule

Use:

```text
async Task
async Task<T>
```

instead of:

```text
async void
```

except for event handlers.

---

# 14. Thread Safety and Race Conditions

Standard collections are not thread-safe for concurrent writes:

```csharp
List<T>
HashSet<T>
Dictionary<TKey, TValue>
```

For example:

```csharp
List<int> numbers = new();

Parallel.For(0, 1000, i =>
{
    numbers.Add(i);
});
```

The result may contain fewer than 1000 elements.

An experiment produced:

```text
Expected: 1000
Actual:    934
```

This is a **race condition**.

---

## Solution 1 — Concurrent Collections

Use collections from:

```csharp
System.Collections.Concurrent
```

Examples:

```csharp
ConcurrentBag<T>
ConcurrentQueue<T>
ConcurrentDictionary<TKey, TValue>
```

Example:

```csharp
ConcurrentBag<int> numbers = new();

Parallel.For(0, 1000, i =>
{
    numbers.Add(i);
});
```

The collection handles synchronization internally.

---

## Solution 2 — `lock`

Protect a critical section:

```csharp
lock (syncObject)
{
    list.Add(value);
}
```

Only one thread can enter the protected section at a time.

---

## Solution 3 — Architectural Isolation

The best solution can sometimes be to avoid shared mutable state completely.

For example:

```text
Parallel fetch
    ↓
Individual results
    ↓
Sequential processing
    ↓
Shared state
```

This is the approach used in the `MonitoringService` architecture:

* Fetching is parallel.
* `_knownKeys` is modified sequentially.
* Multiple threads don't simultaneously modify the same state.

> Sometimes the easiest race condition to solve is the one you don't create.

---

# 15. `Interlocked`

For simple atomic operations, `Interlocked` can be preferable to `lock`.

Example:

```csharp
Interlocked.Increment(ref counter);
```

Instead of:

```csharp
lock (syncObject)
{
    counter++;
}
```

`Interlocked` is designed for atomic operations on simple values and can avoid the overhead of a full monitor/lock.

Typical operations include:

```csharp
Interlocked.Increment(ref value);
Interlocked.Decrement(ref value);
Interlocked.Exchange(ref value, newValue);
Interlocked.CompareExchange(...);
```

---

# 16. `IAsyncEnumerable<T>` / `await foreach`

`IAsyncEnumerable<T>` represents an asynchronous stream of data.

Example:

```csharp
await foreach (var item in GetItemsAsync())
{
    Process(item);
}
```

Each next element may require asynchronous waiting.

This is useful when you don't want to wait for **all** data before processing anything.

### Important: sequential execution

`IAsyncEnumerable<T>` does **not** automatically make operations parallel.

For example, if there are 5 elements and each takes 300 ms:

```text
300 + 300 + 300 + 300 + 300
≈ 1500 ms
```

With parallel `Task.WhenAll`:

```text
       ┌── 300 ms ──┐
Task 1 ──────────────┤
Task 2 ──────────────┤
Task 3 ──────────────┤
Task 4 ──────────────┤ ≈ 300 ms
Task 5 ──────────────┘
```

So:

| Approach                              | Approx. time |
| ------------------------------------- | -----------: |
| `await foreach` sequential processing |     ~1500 ms |
| Parallel `Task.WhenAll`               |      ~300 ms |

### Main difference

`IAsyncEnumerable<T>`:

> **Process items as they become available.**

`Task.WhenAll`:

> **Start operations concurrently and wait for all of them.**

They solve different problems.

---

# 17. Final Project

The final practice project combined the concepts above into a small **parallel monitoring service**.

The project implements:

* Multiple concurrent requests.
* Independent error handling for each request.
* `CancellationToken`.
* Correct reaction to `Ctrl+C`.
* Cancellation without waiting for long delays to finish.
* Parallel data fetching.
* Sequential modification of shared state.
* Handling multiple errors and cancellations.

One of the hardest parts was understanding that directly awaiting:

```csharp
await Task.WhenAll(tasks);
```

does not automatically give the application all individual exceptions in the way we might initially expect.

Therefore, the final implementation kept the individual tasks/results and processed them separately, allowing the application to preserve information about **multiple failures** instead of exposing only the first observed exception.

---

# 18. Quick Cheat Sheet

| Concept                   | Main idea                                               |
| ------------------------- | ------------------------------------------------------- |
| `Thread`                  | Actual execution thread                                 |
| `Task`                    | Represents asynchronous work                            |
| `Task<T>`                 | Task that produces a result                             |
| `async`                   | Allows asynchronous method/state-machine transformation |
| `await`                   | Asynchronously waits for a task                         |
| `Task.Delay`              | Non-blocking delay                                      |
| `Thread.Sleep`            | Blocks the current thread                               |
| `Task.Run`                | Moves work to ThreadPool                                |
| `Task.WhenAll`            | Wait for all tasks                                      |
| `Task.WhenAny`            | Wait for the first completed task                       |
| `CancellationToken`       | Cooperative cancellation signal                         |
| `CancellationTokenSource` | Controls cancellation                                   |
| `async void`              | Mainly for event handlers                               |
| `ConcurrentBag`           | Thread-safe collection                                  |
| `lock`                    | Protects shared state                                   |
| `Interlocked`             | Atomic operations                                       |
| `IAsyncEnumerable<T>`     | Asynchronous stream                                     |
| `await foreach`           | Consumes an async stream                                |

---

# 19. The Main Mental Model

The most important thing is not to memorize individual methods. Understand **why** they exist.

```text
                    ASYNC PROGRAMMING
                           │
          ┌────────────────┼────────────────┐
          ↓                ↓                ↓
        Task            await           Cancellation
          │                │                │
     represents       suspend without    cooperative
       work             blocking          stopping
          │                │                │
          ↓                ↓                ↓
      WhenAll           I/O-bound       TokenSource
      WhenAny           operations      Token
      Task.Run
```

### Remember these rules

1. **`Task` ≠ `Thread`.**
2. **`async` does not automatically make blocking code asynchronous.**
3. **`await` is especially useful for I/O-bound operations.**
4. **`Task.Delay` doesn't block a thread; `Thread.Sleep` does.**
5. **`Task.Run` is mainly for CPU-bound or blocking synchronous work.**
6. **Cancellation is cooperative — you don't forcibly kill a task.**
7. **Prefer `async Task` over `async void`.**
8. **Don't access ordinary collections concurrently without synchronization.**
9. **`IAsyncEnumerable<T>` streams data; it doesn't automatically make processing parallel.**
10. **Use `await` instead of `.Result` / `.Wait()` whenever possible.**

---

## Final takeaway

The core idea behind asynchronous programming in C# is:

> **Don't occupy a thread while you're simply waiting for something.**

For I/O:

```csharp
await SomeIoOperationAsync();
```

For CPU-heavy work:

```csharp
await Task.Run(() => HeavyCalculation());
```

For cancellation:

```csharp
await SomeOperationAsync(token);
```

For multiple independent operations:

```csharp
await Task.WhenAll(tasks);
```

Once these patterns become intuitive, `async`/`await`, `Task`, `CancellationToken`, `WhenAll`, and `WhenAny` stop looking like a collection of unrelated APIs and become parts of one coherent model.

This version should work well as a GitHub README and as a revision sheet before an interview/exam.
