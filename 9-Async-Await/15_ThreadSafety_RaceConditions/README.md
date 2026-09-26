# Thread Safety: Why `List` and `HashSet` Break Under Concurrent Access

## Overview

`List<T>`, `HashSet<T>`, and `Dictionary<TKey, TValue>` are **not thread-safe**.

They do not synchronize access to their internal state when multiple threads modify the same collection simultaneously. If two threads call `Add()` on the same collection at the same time, a **race condition** can occur.

The important part is that this may happen **without any exception** — the program can simply produce an incorrect result.

---

## Why Does It Break?

`List<T>.Add()` is not a single atomic operation.

Conceptually, it performs something similar to:

1. Read the current `_size`.
2. Write the element to the corresponding position.
3. Increment `_size`.
4. Reallocate the internal array if necessary.

Imagine that `_size == 5` and two threads execute `Add()` simultaneously:

```text
Thread A → reads _size = 5
Thread B → reads _size = 5

Thread A → writes element at index 5
Thread B → writes element at index 5

Thread A → _size = 6
Thread B → _size = 6
```

Both `Add()` calls completed, but both threads attempted to use the same position.

As a result, one element can be lost.

There may be **no exception at all** — the data is simply corrupted or missing.

---

## Experiment

### 1. Regular `List<int>`

1000 parallel `Task.Run()` operations were used:

```csharp
var numbers = new List<int>();

var tasks = Enumerable.Range(0, 1000)
    .Select(i => Task.Run(() => numbers.Add(i)))
    .ToArray();

await Task.WhenAll(tasks);

Console.WriteLine($"Tasks.Count: {tasks.Length}");
Console.WriteLine($"numbers.Count: {numbers.Count}");
```

Result:

```text
Tasks.Count:   1000
numbers.Count: 934
```

**66 elements were lost.**

The exact number may vary between runs because the problem depends on thread scheduling and timing.

---

### 2. `ConcurrentBag<int>`

Replacing `List<int>` with a thread-safe collection:

```csharp
var numbers = new ConcurrentBag<int>();

var tasks = Enumerable.Range(0, 1000)
    .Select(i => Task.Run(() => numbers.Add(i)))
    .ToArray();

await Task.WhenAll(tasks);

Console.WriteLine($"Tasks.Count: {tasks.Length}");
Console.WriteLine($"numbers.Count: {numbers.Count}");
```

Result:

```text
Tasks.Count:   1000
numbers.Count: 1000
```

All elements are present.

---

### 3. `List<int>` + `lock`

The same `List<int>` can also be protected manually:

```csharp
var numbers = new List<int>();
var locker = new object();

var tasks = Enumerable.Range(0, 1000)
    .Select(i => Task.Run(() =>
    {
        lock (locker)
        {
            numbers.Add(i);
        }
    }))
    .ToArray();

await Task.WhenAll(tasks);

Console.WriteLine($"Tasks.Count: {tasks.Length}");
Console.WriteLine($"numbers.Count: {numbers.Count}");
```

Result:

```text
Tasks.Count:   1000
numbers.Count: 1000
```

---

## Solution 1 — `System.Collections.Concurrent`

For concurrent access, .NET provides specialized collections:

```csharp
var numbers = new ConcurrentBag<int>();

Parallel.For(0, 1000, i =>
{
    numbers.Add(i);
});
```

Other examples:

```text
ConcurrentBag<T>
ConcurrentQueue<T>
ConcurrentStack<T>
ConcurrentDictionary<TKey, TValue>
```

These collections are specifically designed for concurrent scenarios and handle synchronization internally.

---

## Solution 2 — `lock`

You can also protect a normal collection yourself:

```csharp
var numbers = new List<int>();
var locker = new object();

Parallel.For(0, 1000, i =>
{
    lock (locker)
    {
        numbers.Add(i);
    }
});
```

`lock` guarantees that only one thread at a time can execute the protected section.

The trade-off is that concurrent operations inside the critical section are effectively serialized:

```text
Thread A ──→ [Add] ──→
Thread B          waits
Thread C          waits
Thread D          waits
```

This can reduce scalability if the critical section is large or heavily contended.

---

## `Concurrent*` vs `lock`

| Situation                                               | Recommended approach                 |
| ------------------------------------------------------- | ------------------------------------ |
| Multiple threads need to add items to a collection      | `Concurrent*`                        |
| Need a queue shared between threads                     | `ConcurrentQueue<T>`                 |
| Need a thread-safe key-value collection                 | `ConcurrentDictionary<TKey, TValue>` |
| Need to protect several operations as one atomic action | `lock`                               |
| Need to protect a normal collection                     | `lock`                               |
| Need atomic operations on a single integer              | `Interlocked`                        |

### Important distinction

`Concurrent` collections protect **their own operations**.

They do not automatically make a sequence of separate operations atomic.

For example:

```csharp
if (!dictionary.ContainsKey(key))
{
    dictionary.TryAdd(key, value);
}
```

Another thread can modify the dictionary between `ContainsKey()` and `TryAdd()`.

If the entire sequence must be treated as one atomic operation, a different synchronization strategy may be required.

---

## Practical Rule

> **Use `Concurrent*` when the collection itself needs to support concurrent access.**

> **Use `lock` when you need to protect a larger piece of logic or make several operations behave as one atomic operation.**

---

## Related Topics

* **Race Conditions** — the general problem of multiple threads accessing shared state without proper synchronization.
* **`Interlocked`** — atomic operations on individual values without using a traditional `lock`.
* **Deadlocks** — a possible problem when locks are used incorrectly.
* **Thread Safety** — the broader concept of making shared state safe for concurrent access.

---

## Key Takeaway

The important lesson is:

```text
Parallel execution
       ↓
Shared mutable state
       ↓
No synchronization
       ↓
Race condition
       ↓
Incorrect result
```

The fact that all tasks completed successfully does **not** mean that the operation was thread-safe.

```text
Tasks.Count   = 1000
List.Count    = 934
```

All tasks can finish without exceptions while the shared data is still incorrect.
