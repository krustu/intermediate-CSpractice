# Topis - Post 
in this example I showed how exactly use post function in Http

1 - we create our json to send it using by post 
2 - created http client to get response at fisrt
3 - getiing final object and then rewrite the body int ostring and show in display 

## Code

True
OK
Content-Type: application/json
Content-Length: 389

s{
  "args": {},
  "data": "{\"name\":\"Rysbek\"}",
  "files": {},
  "form": {},
  "headers": {
    "Content-Length": "17",
    "Content-Type": "application/json; charset=utf-8",
    "Host": "httpbin.org",
    "X-Amzn-Trace-Id": "Root=1-6ac8ff74-7f96dd9515dd9c4c13aa3e7b"
  },
  "json": {
    "name": "Rysbek"
  },
  "origin": "31.61.238.0",
  "url": "https://httpbin.org/post"
}

## Initial code 
''' 
using System;
class Program
{
    static async Task Main()
    {
        var client = new HttpClient();
        string url = "https://httpbin.org/post";
        StringContent OurJson = new StringContent("{\"name\":\"Rysbek\"}",
        System.Text.Encoding.UTF8, "application/json");

        HttpResponseMessage response = await
            client.PostAsync(url, OurJson);


        string responseBody = await
            response.Content.ReadAsStringAsync();

        Console.WriteLine(response.IsSuccessStatusCode);
        Console.WriteLine(response.StatusCode);
        Console.WriteLine(response.Content.Headers);

        Console.ReadKey();
        Console.WriteLine(responseBody);
    }
}
'''