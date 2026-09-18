# README
# Task<int> and Task.Result

Small C# practice to understand `Task<int>`, `Task.Run()`, and `.Result`.

## What I Practiced

- Creating a method that returns `Task<int>`.
- Running work with `Task.Run()`.
- Simulating long-running work with `Thread.Sleep()`.
- Returning an `int` from a `Task`.
- Checking task state with `IsCompleted`.
- Getting the result with `.Result`.
- Comparing a normal `int` return value with `Task<int>`.

## Key Idea

A normal method returns the result immediately:

`int → 25`

An asynchronous method returns a `Task<int>` that will contain the result when the work is finished:

`Task<int> → .Result → 25`

`.Result` waits for the task to finish if it has not completed yet.