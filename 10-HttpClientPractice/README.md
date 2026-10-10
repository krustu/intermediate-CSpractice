# Phase 5 – project practice & debugging notes

## Practice in the project

**1. House.kg URL.**
`https://www.house.kg/kupit-kvartiru?sort_by=created_date%20desc&page=N`
- `/kupit-kvartiru` – the "buy an apartment" section.
- `?` starts the query string; `&` separates parameters.
- `sort_by=created_date%20desc` – sort by creation date, newest first (`%20` is an encoded space).
- `page=N` – page number, appended in code; the shared part is a `const`.
- The class gets the `HttpClient` through its constructor so the whole app reuses one shared client.

**2. Lalafo headers.** `device`, `country-id`, `language` are what the Lalafo site itself sends
to its own API (found via DevTools → Network). Without them the server returns `417`.
They are set per request (`HttpRequestMessage`), not on the shared client, so they are not sent to House.kg.

**3. Timeout (30 s).** It stops us from waiting forever on a hung server.
Worst case for one check: 5 pages × 30 s = 150 s (2.5 min), which fits into the 5-minute check interval.
There is no magic about 30 – it is a compromise: long enough for a slow server, short enough not to block a check.

**4. Requests per day.** 5 pages × 2 sources = 10 requests per check; 288 checks per day (every 5 min)
→ at most 2880 requests/day (~1 per minute per site). There is a 1 s pause between pages.

## Debugging exercises

**HTTP error.** Each source is wrapped in its own `try/catch` in `FetchSourceAsync`, so one failing
source (e.g. House.kg with `404`) is turned into an error message and the others (Lalafo) keep working.
*(TODO: run it and paste the real log line.)*

**Missing header (417).** *(TODO: write the diagnosis steps: find the request in DevTools,
compare browser headers with my code, repeat it in `curl.exe` removing headers one by one.)*

**Socket leak.** A new `HttpClient` per request opens a new connection on a new local port.
After closing, the port stays in `TIME_WAIT` for a few minutes, and there are only ~16k such ports,
so many quick requests run out of ports and start failing (socket exhaustion). Fix: one shared client / `IHttpClientFactory`.

**False confidence.** House.kg silently ignored `sort_by`: no error, status 200, just a different order,
so the code wrongly assumed page 1 always had the newest listings. "No error" does not mean "it works".
Check: request with and without the parameter and compare the order of listings; if identical, the parameter does nothing.

curl.exe -s -o NUL -w "%{http_code}" -H "device: pc" -H "country-id: 12" -H "language: ru_RU" "https://lalafo.kg/api/search/v3/ads/search?category_id=2046&city_id=103184&expand=url&page=1&per-page=2"

curl.exe -s -o NUL -w "%{http_code}" -H "country-id: 12" -H "language: ru_RU" "https://lalafo.kg/api/search/v3/ads/search?category_id=2046&city_id=103184&expand=url&page=1&per-page=2"