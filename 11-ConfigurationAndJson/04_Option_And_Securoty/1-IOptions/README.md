# Options pattern (IOptions<T>)

Как передавать классу только те настройки, которые ему нужны, а не весь `IConfiguration`.

## Идея
Настройки из секции конфигурации превращаются в объект (`Get<T>()`), этот объект оборачивается в `IOptions<T>` и передаётся классу через конструктор. Сами настройки лежат в `.Value`.

## Код
```csharp
ScraperSettings settings = config.GetSection("Scraper").Get<ScraperSettings>()
    ?? throw new InvalidOperationException("Section 'Scraper' is missing");

IOptions<ScraperSettings> options = Options.Create(settings);
var scraper = new Scraper(options);
```

```csharp
class Scraper
{
    private readonly ScraperSettings _settings;

    public Scraper(IOptions<ScraperSettings> options)
    {
        _settings = options.Value;
    }
}
```

В больших проектах (ASP.NET Core) вместо `Options.Create` используется `builder.Services.Configure<T>(config.GetSection("..."))`.

## Что я понял
- Класс получает только свои настройки и не может случайно прочитать или вывести чужие, например токен.
- По конструктору сразу видно, что нужно классу.
- Такие классы проще тестировать: настройки задаются в тесте через `Options.Create(new ...)`, файл не нужен.
- Биндинг молча даёт 0 для отсутствующего ключа, поэтому нужные настройки лучше проверять при запуске.