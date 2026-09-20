# Task.WhenAny – First Completed Task

## 📌 Description

This project demonstrates how to use `Task.WhenAny()` in C# to execute multiple asynchronous methods concurrently and retrieve the result of the task that finishes first.

Three asynchronous methods are started without waiting for each other. The program then uses `Task.WhenAny()` to wait until the first task completes.

## ⚙️ How It Works

1. Starts a `Stopwatch` to measure execution time.
2. Starts three asynchronous tasks: `Func1()`, `Func2()`, and `Func3()`.
3. Uses `Task.WhenAny()` to wait for the first completed task.
4. Awaits the winning task to retrieve its result.
5. Stops the stopwatch and prints the winner and elapsed time.

## 🧠 Key Concepts

* **Task.WhenAny()** – Completes when any one of the provided tasks finishes and returns the completed task.
* **async / await** – Enables asynchronous programming without blocking the calling thread while waiting.
* **Task<string>** – Represents an asynchronous operation that returns a string.
* **Stopwatch** – Measures the elapsed execution time.

## 💻 Example Output

```text
Winner: Third
Time: 2005 ms
```

The exact execution time may vary slightly depending on system performance.

## ⏱️ Task Delays

| Method  |   Delay | Return Value |
| ------- | ------: | ------------ |
| Func1() | 3000 ms | First        |
| Func2() | 2500 ms | Second       |
| Func3() | 2000 ms | Third        |

Since `Func3()` has the shortest delay, it is expected to finish first.

## 🎯 Purpose

The goal of this project is to understand how `Task.WhenAny()` works and how to identify the first completed asynchronous task without waiting for all other tasks to finish.

## 🛠️ Technologies

* C#
* .NET
* Task-based Asynchronous Pattern (TAP)
* `System.Diagnostics`
