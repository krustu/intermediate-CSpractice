
using System.Net.Http.Headers;
using System.Text;
class Program
{
    static async Task Main()
    {
        HttpClient client = new();
        HttpResponseMessage response1 = await client.GetAsync("https://httpbin.org/basic-auth/krustu/mypassword");
        Console.WriteLine(response1.StatusCode);
        if (response1.Headers.WwwAuthenticate.Any())
        {
            Console.WriteLine("WWW-Authenticate: " + response1.Headers.WwwAuthenticate.First());
        }

        string credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes("krustu:masdsdsa"));
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);

        HttpResponseMessage response2 = await client.GetAsync("https://httpbin.org/basic-auth/krustu/mypassword");
        Console.WriteLine(response2.StatusCode);
    }
}
