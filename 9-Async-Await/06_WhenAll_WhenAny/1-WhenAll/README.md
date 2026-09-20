# Parallel Tasks with Task.WhenAll

## Description

A simple C# console application demonstrating asynchronous programming using `async` and `await`, and executing multiple tasks concurrently with `Task.WhenAll()`.

## What I Learned

* Creating asynchronous methods using `async` and `await`.
* Using `Task.Delay()` to simulate asynchronous operations.
* Running multiple tasks concurrently.
* Using `Task.WhenAll()` to wait for all tasks to complete.
* Understanding that `Task.WhenAll()` returns an array of results when used with `Task<T>`.

## How It Works

1. Five asynchronous tasks are created, each calculating a value.
2. Each task waits for 1 second asynchronously.
3. `Task.WhenAll()` waits for all five tasks to finish.
4. The total execution time is measured using `Stopwatch`.
5. The result of a task is printed to the console.

## Technologies

* C#
* .NET
* Task-based Asynchronous Programming (TAP)

## Key Concept

`Task.WhenAll()` allows multiple asynchronous operations to run concurrently and waits until all of them have completed.

Instead of waiting approximately 5 seconds sequentially, five tasks with a 1-second delay can complete in approximately 1 second.

## Example Output

```text
Time - 1000 milliseconds
10
```

*Execution time may vary depending on the system.*
