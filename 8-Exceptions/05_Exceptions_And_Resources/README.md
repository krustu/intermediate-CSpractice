## Стоимость исключений и почему не стоит использовать их для потока управления
Суть

Исключения в .NET — дорогие. 
Создание объекта исключения, заполнение StackTrace, 
"разматывание стека" (stack unwinding) в поисках подходящего 
catch — всё это требует значительно больше работы, чем обычная проверка if.

Использовать try/catch вместо if для обычной, 
ожидаемой логики — это "исключения как control flow" — антипаттерн.
# Плохо vs хорошо
// ПЛОХО — исключение вместо обычной проверки
# public bool UserExists(string email)
# {
    try
    {
        var user = database.GetUserOrThrow(email);
        return true;
    }
    catch (UserNotFoundException)
    {
        return false;
    }
 # }

// ХОРОШО — обычная проверка / Try-паттерн
public bool UserExists(string email)
{
    return database.TryGetUser(email, out _);
}

# Вывод

Исключения — для исключительных ситуаций, 
не для обычных веток логики. 
Если ловишь себя на мысли "проще throw здесь и catch там, 
чем писать if" — это сигнал остановиться: скорее всего, 
нужен обычный if или Try-паттерн.

# Связанные темы
Try-паттерн: TryParse, TryGetValue
Исключение vs возвращаемое значение — что когда
Почему пустой catch {} — почти всегда ошибка



# `finally` and `using` — Guarantee of Release

## Core idea

`using` is syntactic sugar over `try/finally`.
Both guarantee that a specific block of code runs **no matter what** — whether the `try` block succeeds or throws.

```csharp
using (var resource = new SomeDisposable())
{
    // work
} // Dispose() ALWAYS runs here, even if an exception was thrown above
```

is really:

```csharp
var resource = new SomeDisposable();
try
{
    // work
}
finally
{
    resource.Dispose(); // ALWAYS runs
}
```

## When to use which

- **`using`** — when the object implements `IDisposable` (has a `Dispose()` method). Purpose-built shorthand for resource cleanup.
- **`finally`** directly — when you need guaranteed cleanup for something that is *not* `IDisposable` 
- (e.g. resetting a flag, rolling back a variable, always printing a status message).

```csharp
bool isProcessing = false;
try
{
    isProcessing = true;
    DoWork(); // may throw
}
finally
{
    isProcessing = false; // ALWAYS resets, even on failure
}
```

## Multiple resources

```csharp
using (var connection = new DatabaseConnection())
using (var file = new FileLogger("app.log"))
{
    // both available here
} // Dispose() called for BOTH, in reverse order of creation
```

## Experiment (confirmed on real code)

Built a `DatabaseConnection : IDisposable` with `ExecuteQuery()` throwing `ArgumentException` on empty input,
wrapped in `using` inside an outer `try/catch/finally`.

Console output order:
```
Running..>
Finishing...                                    ← Dispose() ran BEFORE the catch
error : System.ArgumentException: Query cannot be empty
Roll back variable state                        ← outer finally, unrelated to IDisposable
```

Proof: `Dispose()` fired **before** the exception reached the outer `catch` 
— cleanup happened even though the `using` block was interrupted mid-execution by a thrown exception.

## Takeaway

`using`/`IDisposable` is a specialized case of the general `finally` guarantee. 
Understanding one explains how the other works. 
Both exist for the same reason: **cleanup code must run regardless of success or failure** 
— no exception should ever let a resource leak or a flag stay in a broken state.