using System;
using System.Diagnostics;
using System.Text;
class Program
{
    static async Task Main()
    {

    }
}
public class DataFetcher // библиотечный класс, предназначен для переиспользования в разных типах приложений
{
    public async Task<string> LoadAsync(string url)
    {
        using var client = new HttpClient();
        var data = await client.GetStringAsync(url)
            .ConfigureAwait(false);
        var processed = await ProcessData(data)
            .ConfigureAwait(false);
        return processed;
    }

    private async Task<string> ProcessData(string raw)
    {
        await Task.Delay(100)
            .ConfigureAwait(false);
        return raw.ToUpper();
    }
}
//all dictinary function should be with .ConfigureAwait(false);