# C# Async/Await – CancellationToken

## Overview

This project demonstrates how to cancel an asynchronous operation in C# using `CancellationTokenSource` and `CancellationToken`.

## Concepts Covered

* `CancellationTokenSource` – controls cancellation.
* `CancellationToken` – passes cancellation requests to async methods.
* `ThrowIfCancellationRequested()` – throws an `OperationCanceledException` when cancellation is requested.
* `Task.Delay()` with a cancellation token.
* `try-catch-finally` for handling cancellation and cleanup.

## How It Works

1. Creates a `CancellationTokenSource` with a 2-second timeout.
2. Starts an asynchronous countdown from 0 to 9.
3. Each iteration waits 500 milliseconds and checks for cancellation.
4. When cancellation is requested, the operation stops and the exception is handled.
5. The `finally` block executes regardless of the outcome.

## Key Takeaway

Cancellation in C# is cooperative: asynchronous methods must observe the cancellation token and respond to cancellation requests.

## Technologies

* C#
* .NET
* Task-based Asynchronous Pattern (TAP)
