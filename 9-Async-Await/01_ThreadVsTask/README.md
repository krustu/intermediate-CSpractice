# README
# Thread vs Task

Small C# practice to compare `Thread` and `Task.Run()`.

## What I Practiced

- Creating and starting 5 `Thread` instances.
- Creating 5 tasks using `Task.Run()`.
- Getting the current thread ID with `Thread.CurrentThread.ManagedThreadId`.
- Measuring creation and startup time with `Stopwatch`.
- Observing thread ID reuse with `Task.Run()`.

## Result

The `Thread` instances receive different thread IDs, while `Task.Run()` can reuse threads from the ThreadPool.

The order of thread IDs can also change between program runs because thread scheduling is not deterministic.