# Из какого источника пришло значение

Код, который печатает, какой источник конфигурации (файл, переменная окружения) дал значение ключа.

## Зачем
Когда один ключ есть в нескольких источниках, побеждает добавленный последним. Этот код показывает, кто победил. Так ищут причину, когда программа берёт не то значение, которое ты ожидал.

## Пакеты
- `Microsoft.Extensions.Configuration.Json`: `AddJsonFile`
- `Microsoft.Extensions.Configuration.EnvironmentVariables`: `AddEnvironmentVariables`

## Код
```csharp
using Microsoft.Extensions.Configuration;

Environment.SetEnvironmentVariable("Scraper__CheckIntervalMinutes", "77");   // до Build()

IConfigurationRoot config = new ConfigurationBuilder()
    .AddJsonFile("appsettingTwo.json", optional: false)
    .AddEnvironmentVariables()
    .Build();

string key = "Scraper:CheckIntervalMinutes";

foreach (IConfigurationProvider provider in config.Providers.Reverse())
{
    if (provider.TryGet(key, out string? value))
    {
        Console.WriteLine($"{key} = {value} from {provider}");
        break;
    }
}
```

## Как это работает
- `IConfigurationRoot` это то, что возвращает `Build()`. У него есть список источников `Providers` в порядке добавления. У обычного `IConfiguration` такого списка нет.
- `Reverse()` переворачивает список, чтобы идти с последнего источника (нужен `using System.Linq;`, если подчёркнуто).
- `provider.TryGet(key, out value)` спрашивает конкретный источник, есть ли у него ключ.
- Первый найденный с конца и есть победитель, дальше `break`.
- Ключ пишется полностью, с секцией: `Scraper:CheckIntervalMinutes`. В имени переменной окружения вместо `:` ставится `__`.

## Результат
С переменной окружения:
```
Scraper:CheckIntervalMinutes = 77 from EnvironmentVariablesConfigurationProvider
```
Без неё (строку `SetEnvironmentVariable` закомментировать):
```
Scraper:CheckIntervalMinutes = 5 from JsonConfigurationProvider for 'appsettingTwo.json' (Required)
```

## Ошибки, которые у меня были
- `CS1061: IConfiguration does not contain a definition for 'Providers'`: тип переменной нужно поменять на `IConfigurationRoot`.
- Вывод пустой: в `TryGet` ключ был без секции (`CheckIntervalMinutes` вместо `Scraper:CheckIntervalMinutes`).
- Переменная окружения не срабатывала: в цепочке `ConfigurationBuilder` не было `.AddEnvironmentVariables()`. Источник нужно подключать явно, а `SetEnvironmentVariable` должен быть до `Build()`.

## Что я понял
- Источник конфигурации называется провайдером, и каждый `Add...` добавляет один.
- Последний добавленный провайдер побеждает, поэтому переменная окружения перекрыла файл (77 вместо 5).
- Переменные окружения нужны, чтобы менять настройки и задавать секреты на сервере, не трогая код и файл.