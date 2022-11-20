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
    private const int LimitOverPeriod = 25;
    private const int PeriodDurationInSeconds = 5;
    
    private static readonly Dictionary<string, TimeLimiter> RateLimiters = new();

    public async Task Trottle(string token)
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
                RateLimiters.Add(accessToken, TimeLimiter.GetFromMaxCountByInterval(LimitOverPeriod, TimeSpan.FromSeconds(PeriodDurationInSeconds)));

            return RateLimiters[accessToken];
        }
    }
}
