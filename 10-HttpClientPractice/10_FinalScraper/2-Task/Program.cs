using System;
using System.Reflection;
class Program
{
    static async Task Main()
    {
        var Client = new HttpClient();
        string url = "https://NESushefsafateiianfalwfnasdasdas/";
        try
        {
            HttpResponseMessage result = await Client.GetAsync(url);
            Console.WriteLine(result.StatusCode);
            Console.WriteLine(result.IsSuccessStatusCode);
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}