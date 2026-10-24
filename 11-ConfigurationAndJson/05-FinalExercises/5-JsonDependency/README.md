# Практика: JSON-массив, биндинг и переменные окружения

Три маленьких программы. У каждой указано, какие пакеты поставить и зачем они нужны.

## Какие NuGet-пакеты что дают

Ставятся так: правая кнопка на проекте, **Manage NuGet Packages**, вкладка **Browse**, найти пакет, **Install**.

| Пакет | Что даёт | Когда нужен |
|---|---|---|
| `Microsoft.Extensions.Configuration.Json` | `AddJsonFile(...)`: чтение настроек из JSON-файла. Базовый `ConfigurationBuilder` приезжает вместе с ним | Пункты 6 и 7 |
| `Microsoft.Extensions.Configuration.Binder` | `Get<T>()`: заполняет класс настройками | Пункт 6 |
| `Microsoft.Extensions.Configuration.EnvironmentVariables` | `AddEnvironmentVariables()`: чтение переменных окружения | Пункт 7 |

Для пункта 5 пакеты не нужны: `System.Text.Json` встроен в .NET.

## Пункт 5. Вложенный массив объектов в `List<T>`

Идея: `{ }` в JSON это класс, `[ ]` это `List<T>`.

```csharp
using System.Text.Json;

string json = """
{
  "Title": "Team",
  "Members": [
    { "Name": "John", "Age": 32 },
    { "Name": "Aby", "Age": 22 }
  ]
}
""";

var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
Team? team = JsonSerializer.Deserialize<Team>(json, options);

foreach (Member m in team!.Members)
{
    Console.WriteLine($"{m.Name} - {m.Age}");
}

class Team
{
    public string? Title { get; set; }
    public List<Member> Members { get; set; } = new();
}

class Member
{
    public string? Name { get; set; }
    public int Age { get; set; }
}
```

Ожидаемый вывод:

```
John - 32
Aby - 22
```

Строка в тройных кавычках `"""..."""` позволяет писать кавычки внутри без экранирования.

## Пункт 6. Секция из файла в класс через `Get<T>`

Пакеты: `Configuration.Json` и `Configuration.Binder`.

`appsettings.json` (в свойствах файла **Copy to Output Directory: Copy if newer**, иначе будет `FileNotFoundException`):

```json
{
  "Scraper": {
    "CheckIntervalMinutes": 5,
    "MaxPagesPerCheck": 5,
    "RetryCount": 10
  }
}
```

Код:

```csharp
using Microsoft.Extensions.Configuration;

IConfiguration config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false)
    .Build();

ScraperSettings settings = config.GetSection("Scraper").Get<ScraperSettings>()
    ?? throw new InvalidOperationException("Section 'Scraper' is missing");

if (settings.MaxPagesPerCheck <= 0)
    throw new InvalidOperationException("MaxPagesPerCheck must be greater than 0");

Console.WriteLine($"Every {settings.CheckIntervalMinutes} min, {settings.MaxPagesPerCheck} pages, retry {settings.RetryCount}");

class ScraperSettings
{
    public int CheckIntervalMinutes { get; set; }
    public int MaxPagesPerCheck { get; set; }
    public int RetryCount { get; set; }
}
```

Ожидаемый вывод: `Every 5 min, 5 pages, retry 10`

Что что делает:
- `GetSection("Scraper")`: берёт из файла только то, что лежит внутри `Scraper`.
- `Get<ScraperSettings>()`: создаёт объект и заполняет свойства по совпадающим именам, строки сам превращает в числа. Если секции нет, вернёт `null`, поэтому после него стоит `?? throw`.
- Имя свойства должно совпадать с ключом в файле. Атрибут `[JsonPropertyName]` здесь **не работает**: он только для `JsonSerializer`.
- Если в ключе опечатка, свойство молча останется 0. Поэтому нужна проверка `if (... <= 0) throw`.

## Пункт 7. Переменная окружения побеждает файл

Пакеты: `Configuration.Json` и `Configuration.EnvironmentVariables`. Файл `appsettings.json` тот же.

```csharp
using Microsoft.Extensions.Configuration;

// Для эксперимента задаём переменную в коде. В жизни её задают снаружи (сервер, Docker).
Environment.SetEnvironmentVariable("CheckIntervalMinutes", "77");

IConfiguration config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false)   // источник 1
    .AddEnvironmentVariables()                          // источник 2, побеждает
    .Build();

Console.WriteLine(config["CheckIntervalMinutes"]);      // 77
```

Правила:
- Источников может быть несколько. Если ключ есть в нескольких, побеждает **добавленный последним**.
- Поменяй порядок (`AddEnvironmentVariables()` перед `AddJsonFile`), и победит файл. Проверь.
- Ключ внутри секции в переменной окружения пишется через двойное подчёркивание: `Scraper__RetryCount` означает `Scraper:RetryCount`.
- Зачем это нужно: на сервере можно поменять настройку или задать секрет, не трогая код и файл.

## Частые ошибки

| Ошибка | Причина | Что сделать |
|---|---|---|
| `CS1061: IConfigurationSection does not contain a definition for 'Get'` | Нет пакета Binder | Установить `Microsoft.Extensions.Configuration.Binder` |
| `FileNotFoundException: appsettings.json` | Файл не копируется в папку запуска | В свойствах файла Copy to Output Directory: Copy if newer |
| `AddJsonFile` или `AddEnvironmentVariables` подчёркнуты красным | Нет соответствующего пакета | Установить пакет из таблицы выше |
| Число в настройке всегда 0 | Опечатка в ключе или свойство названо иначе, чем ключ | Сверить имена, добавить проверку при запуске |