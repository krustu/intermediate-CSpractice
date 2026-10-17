## Configuration Provider Priority

As mentioned earlier, the last configuration provider overrides values from previous providers when they contain the same key.

In this example, `AddInMemoryCollection()` is added first with `CheckIntervalMinutes = 99`, but `AddJsonFile()` is added afterward with `CheckIntervalMinutes = 5`.

Therefore, the JSON file has higher priority, and the final value is `5`, not `99`.

**Output:**
```text
5
5
```

- `MaxPagesPerCheck` → `5` (from the JSON file).
- `CheckIntervalMinutes` → `5` (the JSON value overrides the in-memory value of `99`).