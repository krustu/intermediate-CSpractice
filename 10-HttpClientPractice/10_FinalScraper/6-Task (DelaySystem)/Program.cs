using HttpClient client = new();

string url = "https://httpbin.org/status/500";

int maxRetries = 3;

for (int attempt = 0; attempt <= maxRetries; attempt++)
{
    try
    {
        using HttpResponseMessage response =
            await client.GetAsync(url);

        if ((int)response.StatusCode >= 500)
        {
            throw new HttpRequestException(
                $"Server error: {response.StatusCode}");
        }

        Console.WriteLine($"Success: {response.StatusCode}");
        break;
    }
    catch (HttpRequestException ex)
    {
        Console.WriteLine($"Attempt {attempt + 1} failed: {ex.Message}");

        if (attempt == maxRetries)
        {
            Console.WriteLine("All attempts failed.");
            break;
        }

        int delaySeconds = (int)Math.Pow(2, attempt);

        Console.WriteLine($"Waiting {delaySeconds} seconds...");

        await Task.Delay(TimeSpan.FromSeconds(delaySeconds));
    }
}