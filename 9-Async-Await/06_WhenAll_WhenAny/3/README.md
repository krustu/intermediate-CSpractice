# Asynchronous Tasks Without Task.WhenAll

## Description

A simple C# console application demonstrating how asynchronous tasks behave when they are started without using `Task.WhenAll()` to wait for their completion.

The project explores how tasks with different execution times progress independently and how the program behaves without explicitly awaiting all tasks.

## What I Learned

* Creating asynchronous methods using `async` and `await`.
* Starting multiple asynchronous operations.
* Understanding how tasks with different delays complete independently.
* Observing the difference between starting a task and waiting for its completion.
* Understanding why explicitly awaiting tasks is important when their results are needed.

## How It Works

1. Five asynchronous tasks are started.
2. Each task simulates an operation with a 1-second delay.
3. The program does not use `Task.WhenAll()` to wait for all tasks.
4. The execution flow continues without explicitly waiting for every task to complete.

## Technologies

* C#
* .NET
* Async/Await
* Task-based Asynchronous Programming (TAP)

## Key Concept

Calling an asynchronous method starts its operation, but it does not mean the operation has completed.

Without `await` or `Task.WhenAll()`, the program does not guarantee that all tasks will finish before execution continues.

For console applications, if `Main()` finishes while asynchronous operations are still running, the process may exit before those operations complete.

## Purpose

This project demonstrates the importance of awaiting asynchronous operations and understanding the difference between starting tasks and waiting for their completion.
