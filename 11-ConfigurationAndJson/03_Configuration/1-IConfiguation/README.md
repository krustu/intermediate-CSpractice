# JSON и конфигурация в C#

Практика по System.Text.Json и Microsoft.Extensions.Configuration.

## Что в папке
- 01_Json_Basics: синтаксис JSON, Serialize/Deserialize, DTO, JsonPropertyName, JsonSerializerOptions
- 02_Json_Advanced: nullable-поля, JsonDocument, JsonException
- 03_Configuration: IConfiguration, чтение из appsettings.json

## Что я понял
- Зачем нужен DTO отдельно от доменной модели: "to catch first prototype of information with using DTOclass then pass after refuctoring information our main class that has other proporties"
- Что происходит, когда в JSON битый синтаксис, и где это ловить: need to check when you requesting the result , with try catch or ??(for some cases)
- Почему настройки лежат в файле, а не в коде: "To hide information as Telegram token etc"
- Чем отличается обязательная настройка от необязательной: 

## Как запустить
dotnet run в нужной подпапке. Для 03_Configuration нужен пакет
Microsoft.Extensions.Configuration.Json и Copy to Output Directory: Copy if newer.