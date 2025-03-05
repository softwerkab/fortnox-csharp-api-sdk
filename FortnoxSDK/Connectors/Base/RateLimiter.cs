using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ComposableAsync;
using RateLimiter;

namespace Fortnox.SDK.Connectors.Base;

/// <summary>
/// Rate limit - 25 requests per 5 seconds per token 
/// </summary>
internal class RateLimiter
{
    private const int MaxCount = 24; // Rate limit is 25 requests over 5 second sliding window, but using the max allowed still seems to trigger the limit. 24 req per 5 sec seems to work consistently.
    private static readonly TimeSpan Period = TimeSpan.FromSeconds(5);

    private static readonly Dictionary<string, TimeLimiter> RateLimiters = new();

    public async Task Throttle(string token)
    {
        if (token == null)
            return;

        var limiter = SelectRateLimiter(token);
        await limiter;
    }

    private static TimeLimiter SelectRateLimiter(string accessToken)
    {
        lock (RateLimiters)
        {
            //Add ratelimiter for access token if does not exist
            if (!RateLimiters.ContainsKey(accessToken))
                RateLimiters.Add(accessToken, TimeLimiter.GetFromMaxCountByInterval(MaxCount, Period));

            return RateLimiters[accessToken];
        }
    }
}
