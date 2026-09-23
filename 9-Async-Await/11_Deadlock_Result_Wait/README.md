# CancellationToken – Manual & Timeout Cancellation

A C# async console app demonstrating cancellation using `CancellationTokenSource`.

### Features

* Manual cancellation by pressing any key.
* Automatic cancellation after 5 seconds.
* Linked tokens combine both cancellation sources.
* `OperationCanceledException` handling with cancellation reason detection.
* Async loop with cancellation support.

### Concepts

`CancellationToken`, `CancellationTokenSource`, `CreateLinkedTokenSource`, `Task.Delay`, `async/await`, exception handling.
