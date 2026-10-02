using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;

var services = new ServiceCollection();
services.AddHttpClient(); // ready to use HttpClientFactory fully logic from DI container

ServiceProvider provider = services.BuildServiceProvider();
IHttpClientFactory factory = provider.GetRequiredService<IHttpClientFactory>();
var timer = Stopwatch.StartNew();
for (int i = 0; i < 30; i++)
{
    HttpClient client = factory.CreateClient();
    HttpResponseMessage response = await client.GetAsync("https://httpbin.org/get");
    Console.WriteLine(response.StatusCode);
}
timer.Stop();
Console.WriteLine($"Time taken with HttpClientFactory: {timer.ElapsedMilliseconds} ms");
timer.Restart();
for (int i = 0; i < 30; i++)
{
    HttpClient client = new();
    HttpResponseMessage response = await client.GetAsync("https://httpbin.org/get");
    Console.WriteLine(response.StatusCode);
}
timer.Start();
Console.WriteLine($"Time taken with HttpClientFactory: {timer.ElapsedMilliseconds} ms");




/*
ServiceCollection 
— класс-контейнер. Представь коробку, в которую ты складываешь список "вот такие штуки тебе могут понадобиться", а потом просишь у коробки готовый экземпляр, не создавая его руками через new.

services.AddHttpClient()
— метод-расширение (приходит из NuGet-пакета Microsoft.Extensions.Http), который говорит контейнеру: "зарегистрируй у себя IHttpClientFactory и всю его внутреннюю логику с пулом".

services.BuildServiceProvider()
— превращает список регистраций в реально работающий контейнер, у которого уже можно что-то просить.

provider.GetRequiredService<T>()
— просит у контейнера готовый экземпляр типа T. "Required" значит: если такого типа не зарегистрировано — выбросит исключение, а не вернёт null.

IHttpClientFactory
— интерфейс, который ты просишь у контейнера. У него один главный метод:

factory.CreateClient()
— возвращает готовый к использованию HttpClient, настроенный фабрикой (с тем самым умным пулом внутри).*/