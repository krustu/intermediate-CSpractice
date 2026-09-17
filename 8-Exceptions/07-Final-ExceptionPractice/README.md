# Exception Handling Practice - Notification Service

A small C# console application created to practice exception handling, 
custom exceptions, exception propagation, and interface-based design.

## 🎯 Purpose

The main goal of this project is to practice working with:

- `try`
- `catch`
- `finally`
- `throw`
- `throw;`
- specific exception types
- custom exceptions
- exception propagation
- `StackTrace`
- handling exceptions without stopping the entire operation

## 🏗️ Project Structure

The application contains a notification service with several message senders.

### `IMessegeSender`

Common interface implemented by all message senders.

```csharp
public interface IMessegeSender
{
    void SendText(string a);
}

Message Senders
```
# The project contains several implementations:

- ConsoleMessageSender
- FileMessageSender
- FakeSmsMessageSender
- NickMessanger