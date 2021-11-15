using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ComposableAsync;
using Fortnox.SDK.Authorization;
using RateLimiter;

namespace Fortnox.SDK.Connectors.Base;

internal abstract class BaseClient
{
    private const int LimitPerSecond = 4;
    private static readonly Dictionary<string, TimeLimiter> RateLimiters = new();

    public ErrorHandler ErrorHandler { get; set; }
    public HttpClient HttpClient { get; set; }

    public bool UseRateLimiter { get; set; } = true;
    public FortnoxAuthorization Authorization { get; set; }

    protected BaseClient()
    {
        ErrorHandler = new ErrorHandler();
    }

    public async Task<byte[]> SendAsync(HttpRequestMessage request)
    {
        try
        {
            Authorization?.ApplyTo(request);

            if (UseRateLimiter)
                await Throttle().ConfigureAwait(false);

            using var response = await HttpClient.SendAsync(request).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsByteArrayAsync().ConfigureAwait(false);

            ErrorHandler.HandleErrorResponse(response);
            return default;
        }
        catch (HttpRequestException ex)
        {
            ErrorHandler.HandleNoResponse(ex);
            return default;
        }
    }

    private async Task Throttle()
    {
        if (string.IsNullOrEmpty(Authorization?.AccessToken))
            return;

        var limiter = SelectRateLimiter(Authorization.AccessToken);
        await limiter;
    }

    private static TimeLimiter SelectRateLimiter(string accessToken)
    {
        lock (RateLimiters)
        {
            //Add ratelimiter for access token if does not exist
            if (!RateLimiters.ContainsKey(accessToken))
                RateLimiters.Add(accessToken, TimeLimiter.GetFromMaxCountByInterval(LimitPerSecond, TimeSpan.FromSeconds(1)));

            return RateLimiters[accessToken];
        }
    }
}