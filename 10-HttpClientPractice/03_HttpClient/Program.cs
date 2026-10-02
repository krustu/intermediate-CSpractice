using System.Diagnostics;

var stopwatch = Stopwatch.StartNew();

using var MainClient = new HttpClient();
//Idisposable - using statement will dispose the object after the block is executed
for (int i = 0; i < 20; i++)
{
    await MainClient.GetAsync("https://httpbin.org/get");
}
stopwatch.Stop();
Console.WriteLine($"Time taken: {stopwatch.ElapsedMilliseconds} ms");

stopwatch.Restart();

for (int i = 0; i < 20; i++)
{
    using var client = new HttpClient();
    await client.GetAsync("https://httpbin.org/get");
}
Console.WriteLine($"Time taken: {stopwatch.ElapsedMilliseconds} ms");
