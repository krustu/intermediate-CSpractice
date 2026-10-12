# GitHub API client

Console client that fetches repository info from the GitHub API.
Features: one shared HttpClient, 10 s timeout, retry (3 times, 1/2/4 s delays),
error messages for 4xx/5xx, cancellation by key press or after 60 s,
1 s pause between requests.

## Why one HttpClient and how it is configured
I create one HttpClient and reuse it for all requests, because ...
It is configured with Timeout = ... and the header User-Agent = ..., because ...

## A network error I caught
I got ... (404 / 403 / timeout). It meant ...
The client handles it by ... (retry or not, and why).

## API vs scraping in RealEstateAggregator
Lalafo uses ... (JSON API with headers), House.kg uses ... (HTML).
When House.kg changed, ... happened, and I noticed it by ...
With an API, a change usually ...