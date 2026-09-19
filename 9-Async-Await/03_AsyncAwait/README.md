# README
# Practical: Async/Await and Thread IDs in C#

## Description

This practical demonstrates asynchronous programming in C# using `async`, `await`, `Task`, and `Task<T>`.

## Key Concepts

* `Task` — represents an asynchronous operation without a return value.
* `Task<T>` — represents an asynchronous operation that returns a value.
* `async/await` — allows asynchronous operations without blocking the current thread.
* `Task.Delay()` — asynchronously waits for a specified time.
* `Task.Run()` — executes work on a thread-pool thread.
* `Thread.CurrentThread.ManagedThreadId` — gets the current managed thread ID.
* `.Result` — retrieves the result of a completed task, but may block if it hasn't completed.

## What the Program Does

1. Starts an asynchronous method and prints the thread ID before and after `await Task.Delay()`.
2. Calls `Returnint(5)`, which calculates `5 * 5` inside `Task.Run()`.
3. Prints the returned result (`25`).

## Expected Output

Thread IDs may differ depending on thread scheduling.

```text
Before await, stream 1
After await, stream 5
25
```

## Conclusion

Learned how to use `Task`, `Task<T>`, `async/await`, and `Task.Run()`, and how thread IDs can change after an `await`. Also explored retrieving results from asynchronous operations.
