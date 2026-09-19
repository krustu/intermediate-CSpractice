# README
# Practical: Synchronous vs Asynchronous CPU-Bound Work

## Description

This practical compares synchronous and asynchronous execution of a CPU-intensive operation in C# using `Stopwatch`, `Task.Run()`, and `async/await`.

## Key Concepts

* `Stopwatch` — measures execution time.
* `Task.Run()` — schedules work on a thread-pool thread.
* `async/await` — allows asynchronous waiting for task completion.
* CPU-bound work — operations that consume processing power rather than waiting for I/O.

## What the Program Does

1. Measures the execution time of `CpuBreakerWork()` synchronously.
2. Runs the same CPU-intensive loop through `Task.Run()`.
3. Measures and compares both execution times.

## Expected Result

Both operations perform the same CPU-intensive work. The asynchronous version is **not necessarily faster** because `Task.Run()` does not reduce the amount of computation. It mainly allows the calling thread to remain unblocked while the work runs.

## Conclusion

Learned the difference between synchronous and asynchronous execution of CPU-bound tasks and how to measure execution time using `Stopwatch`.
