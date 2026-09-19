# Practical: Thread.Sleep vs Task.Delay with ThreadPool

## Description

This practical compares `Thread.Sleep()` and `Task.Delay()` when executing multiple tasks using the C# ThreadPool.

## Key Concepts

* `Thread.Sleep()` — blocks the current thread for a specified time.
* `Task.Delay()` — asynchronously waits without blocking the thread.
* `Task.Run()` — schedules work on a ThreadPool thread.
* `Task.WhenAll()` — asynchronously waits for all tasks to complete.
* `ThreadPool.GetAvailableThreads()` — retrieves the number of available ThreadPool threads.

## What the Program Does

1. Creates 499 tasks using `Task.Run()` with `Thread.Sleep(2000)`.
2. Checks available ThreadPool threads and measures total execution time.
3. Creates 499 tasks using `Task.Run()` with `Task.Delay(2000)`.
4. Compares ThreadPool availability and execution time between both approaches.

## Expected Result

* **Sleep version:** Blocks ThreadPool threads while waiting, potentially increasing execution time.
* **Delay version:** Releases threads during the delay, allowing them to handle other work more efficiently.

## Conclusion

Learned how blocking and non-blocking delays affect ThreadPool thread availability, task execution, and overall performance in C#.
