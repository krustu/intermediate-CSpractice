# curl: What a query to GitHub revealed.

command in PowerShell: `curl.exe -i https://api.github.com/repos/dotnet/runtime`

## what returned
- status: 200 OK (request is success)
- Content-Type: application/json (Body is Json JSON, not a HTML)
- X-RateLimit-Limit: 60 (may 60 requests in one hour)
- X-RateLimit-Remaining: 59, and then 58 (After second request we got on less)
- Body: JSON, field stargazers_count = 18321

## Выводы (своими словами)
1. curl sends the User-Agent header (curl/8.21.0) automatically, 
1. so GitHub allows it. HttpClient does not send a User-Agent by default,
1. and GitHub responds with a 403.
   we got response HTTP/1.1 200 OK

2. Чем лимиты в заголовках API отличаются от HTML-сайта:
   api -  related to server part that took custom requerments token, Ip adress , users ,
   html - also has rate limit but it would be hidden for user 