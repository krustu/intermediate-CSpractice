# JSON & Configuration in C#

## Goal
Learn to deserialize JSON into C# objects and understand how .NET applications load configuration settings.

## 01_Json_Basics

Learn how to work with JSON and C# objects.

- JSON syntax: types, arrays, nested objects, and null.
- `System.Text.Json` vs. `Newtonsoft.Json`.
- `Serialize()` and `Deserialize<T>()`.
- DTOs and domain models.
- `[JsonPropertyName]` and property mapping.
- `JsonSerializerOptions` and case sensitivity.

**Goal:** Deserialize API responses into DTOs and serialize objects into JSON.

## 02_Json_Advanced

Learn to handle unpredictable JSON data and errors.

- Nullable properties and missing keys.
- `JsonDocument` and `JsonElement`.
- `JsonException` and error handling.

**Goal:** Safely process incomplete or invalid JSON.

## 03_Configuration

Understand how .NET applications load settings.

- `IConfiguration`.
- Configuration providers.
- Provider priority and overriding values.
- `appsettings.json` and environment-specific files.
- Environment variables and the `__` separator.
- User Secrets.
- `GetSection()`, `Get<T>()`, and configuration binding.

**Goal:** Understand where application settings come from and how to manage them.

## 04_Options_And_Security

Learn to manage configuration through dependency injection and protect sensitive data.

- Options Pattern: `IOptions<T>`, `IOptionsSnapshot<T>`, and `IOptionsMonitor<T>`.
- Binding settings to classes.
- Dependency injection.
- API keys, passwords, and tokens.
- Keeping secrets out of Git and application logs.

**Goal:** Use strongly typed configuration and handle secrets safely.

## Practical Project

Build a console application that:

1. Loads settings from configuration.
2. Uses `HttpClient` to call an API.
3. Deserializes JSON into DTOs.
4. Handles errors and missing data.
5. Supports environment variable overrides.
6. Keeps secrets out of source control.