# GitHub API client

Console client that fetches repository info from the GitHub API.
Features: one shared HttpClient, 10 s timeout, retry (3 times, 1/2/4 s delays),
error messages for 4xx/5xx, cancellation by key press or after 60 s,
1 s pause between requests.

## Why one HttpClient and how it is configured
I create one HttpClient and reuse it for all requests. If I create a new client
for every request, each one opens its own connection, and after closing it the
operating system keeps the port busy for a few minutes. So Dispose does not free
it immediately, and with many requests the ports run out and the program fails.

The client is configured with Timeout = 10 s (a request that hangs longer is
cancelled) and a custom User-Agent header, because GitHub rejects requests
without it. Cancellation by key press or after 60 s is a separate thing: it is
a CancellationToken that stops the whole program.

## A network error I caught
I made a typo in a repository name. The program printed
"repository ... not found!", which is HTTP 404: the server received the request,
but there is no such resource. The client does not retry on 404, because
retrying will not change the result. It retries only temporary errors
(5xx, 408, 429, timeouts), up to 4 attempts with growing delays.

## API vs scraping in RealEstateAggregator
In my RealEstateAggregator project, one source (House.kg) stopped showing
listings, and the reason was unclear: the program ran normally, the server
answered 200 OK, but there were 0 listings. This is a silent failure of HTML
scraping: the page changed, and the parser did not find the data.

With an API this would be different: the problem would show up as a clear error
code (4xx: the contract changed, access was denied or blocked), so it would be
easier to understand what broke and fix it. Lalafo, which uses a JSON API,
works this way.