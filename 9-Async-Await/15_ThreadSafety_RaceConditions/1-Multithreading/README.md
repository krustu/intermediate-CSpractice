# `Interlocked` and Task Completion

A small C# experiment demonstrating two important concepts:

* Atomic operations with `Interlocked`
* Waiting for multiple tasks with `Task.WhenAll`

## Experiment

Two tasks increment the same shared variable:

```csharp
Task task1 = Task.Run(Increase);
Task task2 = Task.Run(Increase);
```

Each task performs **1,000,000 increments**:

```csharp
Interlocked.Increment(ref counter);
```

Since `Interlocked.Increment()` is atomic, no increments are lost.

Expected final result:

```text
counter = 2,000,000
```

## Why Can Intermediate Values Be Different?

If `Console.WriteLine()` is called inside `Increase()`:

```text
The counter is 1604546
The counter is 2000000
```

This is normal.

The first task may finish while the second task is still running. Therefore, the first task prints the **current** value, not necessarily the final value.

## Correct Way to Get the Final Result

Wait for both tasks:

```csharp
Task task1 = Task.Run(Increase);
Task task2 = Task.Run(Increase);

await Task.WhenAll(task1, task2);

Console.WriteLine($"Final counter: {counter}");
```

Output:

```text
Final counter: 2000000
```

## Key Takeaway

```text
Interlocked.Increment()
        ↓
Protects the increment operation

Task.WhenAll()
        ↓
Waits until all tasks finish
```

**Thread safety and task completion are two different problems.**
