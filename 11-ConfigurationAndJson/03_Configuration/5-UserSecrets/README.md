# User Secrets

Как хранить секреты (например токен Telegram-бота) так, чтобы они не попали в GitHub.

## Зачем
Если положить токен в `appsettings.json`, он попадёт в репозиторий, и его сможет использовать любой. User secrets хранят секреты в отдельном файле `secrets.json`, который лежит на моём компьютере вне папки проекта, поэтому в коммит он не попадает.

Важно: это не шифрование.Файл обычный текстовый, защита только от случайной утечки через репозиторий. Работает только при разработке. На сервере секреты задают переменными окружения.

## Как сделать
1. Установить NuGet-пакеты `Microsoft.Extensions.Configuration.Json` и `Microsoft.Extensions.Configuration.UserSecrets`.
2. В Solution Explorer: правая кнопка на проекте, затем **Manage User Secrets**. Visual Studio создаст `secrets.json` и добавит в `.csproj` строку `UserSecretsId`.
3. Записать секрет в `secrets.json`:
```json
   {
     "Telegram": {
    "BotToken": "fake-token-123"
     }
   }
```
4.Несекретные настройки оставить в `appsettings.json`:
```json
   {
     "Telegram": {
    "BotName": "Krustu"
     }
   }
```
   В Solution Explorer для этого файла поставить Copy to Output Directory: Copy if newer.

## Код
```csharp
using Microsoft.Extensions.Configuration;

IConfiguration config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false)
    .AddUserSecrets<Program>()
    .Build();

Console.WriteLine(config["Telegram:BotName"]);    // из appsettings.json
Console.WriteLine(config["Telegram:BotToken"]);   // из secrets.json
```

`AddUserSecrets<Program>()` находит `UserSecretsId` в проекте и подключает его `secrets.json` как ещё один источник. Он добавлен последним, поэтому перекрывает одинаковые ключи из `appsettings.json`.

## Где лежит файл
`C:\Users\<имя>\AppData\Roaming\Microsoft\UserSecrets\<UserSecretsId>\secrets.json`

В папке проекта и в репозитории его нет.

## Что я понял
- Секрет не прячется шифрованием, он просто лежит вне проекта и не попадает в коммит.
- Тот, кто склонирует мой репозиторий, получит `UserSecretsId`, но не получит сам файл, поэтому значение будет `null`.
- Секреты нельзя печатать в консоль и в логи.
- Если токен хоть раз попал в коммит, его нужно сразу отозвать (у Telegram через BotFather, команда `/revoke`) и выпустить новый: из истории git он не пропадает.