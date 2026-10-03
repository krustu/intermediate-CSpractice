using System;
class Program
{
    static async Task Main()
    {
        using var Client = new HttpClient();

        string url = "https://httpbin.org/get";
        string url2 = "https://httpbin.org/post";
        //task 1: GET request using GetStringAsync
        string responseHTML = await Client.GetStringAsync(url);
        Console.WriteLine("\nResponse from GET stringAsync request:");
        Console.WriteLine(responseHTML);
        //task 2: GET request using GetAsync
        HttpResponseMessage getResponse = await Client.GetAsync(url);
        Console.WriteLine("\nResponse from GET  request:");
        Console.WriteLine($"Status Code: {getResponse.StatusCode} - {getResponse.IsSuccessStatusCode}");
        Console.WriteLine(await getResponse.Content.ReadAsStringAsync());
        // here we can see that the response is a JSON object with various properties, including the URL, headers, and origin IP address.
        // despite the previous GetSrtingAsync method,
        // here we also get additional informtation and use Content.ReadASStringAsync to read the response content as a string.

        //task 3: POST request using PostAsync
        //first we need to create a HttpContent object to send in the request body
        StringContent jsonContent = new StringContent("{\"name\":\"Rysbek\"}",
        System.Text.Encoding.UTF8, "application/json");
        //System.Text.Encoding.UTF8 "{\"name\":\"Rysbek\"}" и с помощью этой кодировки
        //   превращает её в байты для отправки по сети
        //and "application/json" is the media type of the content

        HttpResponseMessage postRespinse = await Client.PostAsync(url2, jsonContent);
        Console.WriteLine("\nResponse from POST request:");
        Console.WriteLine($"Status Code: {postRespinse.StatusCode} - {postRespinse.IsSuccessStatusCode}");
        // checking status code and success status of the response

        //task 4: GET request using HttpRequestMessage 
        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
        //create a speacific request with HttpRequestMessage class,
        //which allows us to set additional properties such as headers
        //, content, and method.
        request.Headers.Add("X-Custom-Header", "MyCustomHeaderValue");
        //additional informtaion before sending request.

        HttpResponseMessage sendRespinse = await Client.SendAsync(request);
        Console.WriteLine("\nResponse from GET request using SendAsync:");
        Console.WriteLine($"Status Code: {sendRespinse.StatusCode} - {sendRespinse.IsSuccessStatusCode}");
        Console.WriteLine(await sendRespinse.Content.ReadAsStringAsync());
    }
}