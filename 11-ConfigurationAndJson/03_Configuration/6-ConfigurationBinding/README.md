# Configuration in C#

A simple example of loading application settings from `appsettings.json`
using `Microsoft.Extensions.Configuration`.

## Features
- Load JSON configuration using `ConfigurationBuilder`.
- Map JSON sections to `ScraperSettings` and `TelegramSettings` classes.
- Access strongly typed settings using `Get<T>()`.
- Validate `MaxPagesPerCheck` to ensure it is greater than `0`.
- Convert `CheckIntervalMinutes` to seconds.

## Requirements
- `Microsoft.Extensions.Configuration`
- `Microsoft.Extensions.Configuration.Json`
- `Microsoft.Extensions.Configuration.Binder`

## How it works
The application reads the `Scraper` and `Telegram` sections from `appsettings.json`, maps them to C# classes,
validates the settings, and prints their values to the console.