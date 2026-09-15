# Exceptions & Error Handling in C#

This practice covers exception handling in C# and the `Try` pattern for writing safer code.

## Topics

- Exception hierarchy
- `try / catch / finally`
- Multiple `catch` blocks
- Exception filters: `catch (...) when (...)`
- `throw` vs `throw ex`
- Custom exceptions
- `int.TryParse()` and `Dictionary.TryGetValue()`
- Exceptions vs return values
- Why empty `catch { }` is usually a bad practice
- Cost of exceptions and why they shouldn't be used for normal program flow
- `finally` and `using`
- Exceptions in async code
- Reading `NullReferenceException` stack traces
- Graceful degradation

## Try Pattern

Instead of using exceptions for expected invalid input, use methods such as:

```csharp
if (int.TryParse(input, out int number))
{
    // valid input
}
else
{
    // invalid input
}