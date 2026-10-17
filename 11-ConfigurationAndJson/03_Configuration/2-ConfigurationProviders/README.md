# Configuration Providers

A provider is a source of configuration settings. Each `.AddXxx(...)` call adds a source to the `ConfigurationBuilder`, and `Build()` combines them into a single `IConfiguration`.

## Types of Providers

- `AddJsonFile` — reads settings from a JSON file (`appsettings.json`).
- `AddInMemoryCollection` — reads settings from a dictionary in code, useful for testing and experiments.
- `AddEnvironmentVariables` — reads environment variables.
- **User Secrets** — stores secrets outside the repository for development.
- **Command-line arguments** — passes settings when starting the application.

## Key Rule: Provider Priority

If multiple providers contain the same key, **the last registered provider takes priority**.

See `3-ProviderPriority` for an example.

## What I've Learned

Implemented configuration using a JSON file and an in-memory provider. The remaining providers will be covered in the following folders.