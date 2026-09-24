# Async Chain Benchmark

A C# console project comparing two asynchronous method chains using `Stopwatch`.

### What it demonstrates

* `ChainedAsync()` uses `.Result` to synchronously block an async chain.
* `GoodChainedAsync()` uses `await` correctly.
* Measures and compares execution time over 5 iterations.

### Key takeaway

Avoid `.Result` in async code. Use `await` to prevent blocking and maintain asynchronous execution.

### Technologies

* C#
* `Task` / `async` / `await`
* `Stopwatch`
