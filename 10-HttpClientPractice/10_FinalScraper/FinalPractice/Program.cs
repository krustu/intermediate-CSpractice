using System;
using System.Net;
class Program
{
    static async Task Main()
    {
        int ctsSec = 30;
        using HttpClient Client = new();
        using CancellationTokenSource AutoMod =
            new CancellationTokenSource(TimeSpan.FromSeconds(ctsSec));
        using CancellationTokenSource ManuallyMod =
            new CancellationTokenSource();
        using var cts =
            CancellationTokenSource.CreateLinkedTokenSource(AutoMod.Token, ManuallyMod.Token);
        Client.DefaultRequestHeaders.Add("User-Agent", "KrustuSHN / 1.0");

        List<string> urls = new List<string>()
        {
            "https://api.github.com/repos/krustu/intermediate-CSpractice",
            "https://api.github.com/repos/krustu/CSharp-GitPracrice",
            "https://api.github.com/repos/krustu/RealEstateAggregator",
            "https://api.github.com/repos/krustu/RPG-manager",
            "https://api.github.com/repos/krustu/Zabka-Catalog-LINQ"
        };
        _ = Task.Run(() =>
        {
            Console.WriteLine("press any key to Canel Imediatelly");
            Console.ReadKey(true);
            ManuallyMod.Cancel();
        });

        try
        {
            List<HttpResponseMessage> Allresponse =
                await GetResponse(urls, Client, cts.Token);

            Console.WriteLine($"Count - {Allresponse.Count}");
            // CheckResponse(Allresponse);
        }
        catch (OperationCanceledException)
        {
            if (ManuallyMod.IsCancellationRequested)
                Console.WriteLine("Operation was canceled by Manually");
            else if (AutoMod.IsCancellationRequested)
                Console.WriteLine("Operation was canceled by Timeout");
        }


    }
    public static void CheckResponse(List<HttpResponseMessage> Allresponse)
    {
        Console.WriteLine($"Count - {Allresponse.Count}");
        foreach (var a in Allresponse)
        {
            Console.WriteLine($"Status {a.StatusCode} - {a.IsSuccessStatusCode}");
        }
    }
    public static async Task<List<HttpResponseMessage>> GetResponse(
        List<string> urls,
        HttpClient Client,
        CancellationToken token)
    {
        List<HttpResponseMessage> responses = new();
        int index = 1;
        if (urls == null || urls.Count == 0)
            throw new Exception("Collection is empty!");


        foreach (var url in urls)
        {
            try
            {
                // await Task.Delay(1000, token);
                HttpResponseMessage response =
                    await Client.GetAsync(url, token);


                Console.WriteLine($"{index}. {response.IsSuccessStatusCode} - {response.StatusCode}");
                index++;
                responses.Add(response);
            }
            catch (OperationCanceledException)
            {
                throw;
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
        return responses;
    }
}
public class GitHubClient
{
    private readonly HttpClient _httpClient;
    public GitHubClient(HttpClient a)
    {
        _httpClient = a;
    }
    public async Task<string> GetRepositoryAsync(string owner, string repo, CancellationToken ct)
    {

    }
    private async Task<HttpResponseMessage> GetWithRetryAsync(string url, CancellationToken ct)
    {
        int Maxattempts = 3;
        for (int attempts = 0; ; attempts++)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(url, ct);

                if (IsTransient(response))
                {
                    return response;
                }
                /// Console.WriteLine($"attempts {attempts}")
            }
            catch (HttpRequestException) when (attempts < Maxattempts)
            {
                Console.WriteLine($"attempts {attempts}: }")
            }
        }
    }
    private static bool IsTransient(HttpResponseMessage response)
    {
        var answer = (int)response.StatusCode;
        if (answer <= 500)
            return true;
        if (answer == 408 || answer == 429)
            return true;
        else
        {
            return false;
        }

    }
    private static string DescribeError(HttpStatusCode code, string repoName)
    {
        switch (code)
        {
            case HttpStatusCode.NotFound:
                return $"repository {repoName} not found!";
            case HttpStatusCode.Forbidden:
                return "access denied or Github Api rate limit exceed. ";
            case HttpStatusCode.RequestTimeout:
                return "The Request timed out.";
            case HttpStatusCode.TooManyRequests:
                return "Too many requests. Try again later";

            case HttpStatusCode.InternalServerError:
            case HttpStatusCode.BadGateway:
            case HttpStatusCode.ServiceUnavailable:
            case HttpStatusCode.GatewayTimeout:
                return "GitHub server is temporarily unavailable.";

            default:
                if ((int)code >= 500)
                    return "GitHub server error";

        }

    }
}