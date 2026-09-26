# Race Condition: `lock` vs `Interlocked`

A small C# experiment demonstrating how concurrent access to a shared variable can cause a **race condition**, and how `lock` and `Interlocked.Increment()` solve it.

## Experiment

Multiple `Task.Run()` operations increment the same `counter`.

### Without synchronization

```csharp
counter++;
```

`counter++` is **not atomic**, so multiple tasks can read and modify the value simultaneously.

Example results:

```text
100 tasks    → 98–100
10,000 tasks → 9840–9990
```

The exact result depends on thread scheduling.

### Using `lock`

```csharp
lock (Locker)
{
    counter++;
}
```

Only one thread can enter the critical section at a time.

Result:

```text
counter = 1,000,000
```

### Using `Interlocked`

```csharp
Interlocked.Increment(ref counter);
```

Performs the increment atomically without a traditional `lock`.

Result:

```text
counter = 1,000,000
```

The program also uses `Stopwatch` to compare the execution time of `lock` and `Interlocked`.

## Key Takeaway

```text
counter++                → Race condition
lock { counter++; }      → Thread-safe
Interlocked.Increment()  → Thread-safe + atomic
```

`Interlocked` is especially useful when you only need a simple atomic operation on a single variable.
