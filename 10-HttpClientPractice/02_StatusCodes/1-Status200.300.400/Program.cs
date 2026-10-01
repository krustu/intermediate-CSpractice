using System;
using System.Runtime.InteropServices;
class Program
{
    static async Task Main()
    {
        HttpClient client = new();
        List<string> urls = new()
        {
            "https://httpstat.us/200",
            "https://httpstat.us/201",
            "https://httpstat.us/301",
            "https://httpstat.us/404",
            "https://httpstat.us/500"
        };
        // List<Task<HttpResponseMessage>> tasks = new();
        //foreach(var a in urls)
        // {
        //     tasks.Add(client.GetAsync(a));
        // }

        var tasks = urls.Select(x => client.GetAsync(x));
        HttpResponseMessage[] responses = await Task.WhenAll(tasks);

        foreach (var response in responses)
        {
            int code = (int)response.StatusCode;
            Console.WriteLine($"{code}: {response.StatusCode} - {response.IsSuccessStatusCode}");

            int answer = code / 100;
            switch (answer)
            {
                case 2:
                    Console.WriteLine("Success");
                    break;
                case 3:
                    Console.WriteLine("Redirection");
                    break;
                case 4:
                    Console.WriteLine("Client Error");
                    break;
                case 5:
                    Console.WriteLine("Server Error");
                    break;
                default:
                    Console.WriteLine("Unknown Status Code");
                    break;
            }
        }
    }

}