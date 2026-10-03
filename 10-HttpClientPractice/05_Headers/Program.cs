using System.Net.Http.Headers;

using HttpClient client = new();

// Представим, что это токен для НАШЕГО внутреннего API
var request = new HttpRequestMessage(
    HttpMethod.Get,
    "https://httpbin.org/get");

request.Headers.Authorization =
    new AuthenticationHeaderValue("Bearer", "SECRET-INTERNAL-TOKEN-12345");


HttpResponseMessage internalResponse = await client.SendAsync(request);
Console.WriteLine("Response \"our API\":");
Console.WriteLine(await internalResponse.Content.ReadAsStringAsync());

// Запрос №2 — представим, что это СТОРОННИЙ сервис, которому наш токен
// вообще не нужен и не должен быть виден. Но мы используем ТОТ ЖЕ client.
HttpResponseMessage thirdPartyResponse = await client.GetAsync("https://httpbin.org/headers");
Console.WriteLine("\nResponse \"third-party service\":");
Console.WriteLine(await thirdPartyResponse.Content.ReadAsStringAsync());