# Constructor Injection

**Idea:** a class gets its dependencies through the constructor and stores them in `readonly` fields. It does not create them itself.

## What I did
`ReportService(IDataSource source, IMessageSender sender)`. The method `Run()` takes numbers from `_source`, calculates the sum, and sends it with `_sender`.

## Why the constructor, not a public property
- With a property the object can be created without its dependency, and the program crashes later with `NullReferenceException`.
- With a constructor the compiler does not allow `new ReportService()` without arguments.
- `ArgumentNullException.ThrowIfNull(...)` catches `null` at creation time, not later.
- The dependencies are visible in one place, and `readonly` protects them from changes.

## Mistakes I made
- I passed dependencies but did not use them. `Run(int[] numbers)` got the data from `Main`, so the injection did nothing. Test: swap the source.
- If the result does not change, the dependency is unused.
- One class played two roles (data source and sender). Each role needs its own class.
- A big `try/catch` in `Main` hid a programmer error. `ArgumentNullException` should crash loudly.

## Warning sign
If a constructor has many parameters (5-6 or more), the class probably does too much.
and it does need to separate two or more classes.