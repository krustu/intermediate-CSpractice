using System;
class Program
{
    static async Task Main()
    {
        using HttpClient client = new();

        client.Timeout = TimeSpan.FromMilliseconds(2);
        string url = "https://www.dictionary.com/browse/landing";
        List<HttpResponseMessage> urls = new();
        try
        {
            for (int a = 0; a < 1000; a++)
            {
                HttpResponseMessage response =
                await client.GetAsync(url);

                urls.Add(response);

            }
            int index = 1;
            foreach (var a in urls)
            {
                Console.WriteLine($"{index} - {a.StatusCode} : {a.IsSuccessStatusCode}");
                index++;
            }
            Console.WriteLine(urls.Count());
        }
        catch (TaskCanceledException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
