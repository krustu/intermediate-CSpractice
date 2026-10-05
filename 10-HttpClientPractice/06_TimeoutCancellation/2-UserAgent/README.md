# HttpClient — User-Agent

A simple C# example showing how to change the **User-Agent** header with `HttpClient`.

### What it demonstrates
- Sending GET requests with `HttpClient`
- Checking the default User-Agent behavior
- Adding a custom User-Agent using `DefaultRequestHeaders`
- Comparing server responses before and after the header change
- Reading `HttpResponseMessage` content and status codes
- Using `async/await`

### APIs Used
- `HttpClient`
- `GetStringAsync()`
- `GetAsync()`
- `DefaultRequestHeaders.Add()`
- `ReadAsStringAsync()`
- `StatusCode`