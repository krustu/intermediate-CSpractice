### Environment variables

Experiment: overriding settings from `appsettings.json` with environment variables.

```csharp
Environment.SetEnvironmentVariable("CheckIntervalMinutes", "77");
Environment.SetEnvironmentVariable("Telegram__BotName", "ServerBot");

IConfiguration config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false)
    .AddEnvironmentVariables()
    .Build();
```

### What I learned
- `AddEnvironmentVariables()` reads settings from the environment, not from the code or the file.
- The last provider wins. Here the environment variables come after the JSON file, so they override its values (77 instead of 5, ServerBot instead of Krustu).
- If I add `AddEnvironmentVariables()` before `AddJsonFile`, the JSON file wins instead.
- `__` replaces `:` in names: `Telegram__BotName` is `Telegram:BotName`.
- Why it is useful: on a server I can change a setting or store a secret without editing the code or committing it to the repository.
