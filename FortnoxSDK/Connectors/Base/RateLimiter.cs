using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ComposableAsync;
using Fortnox.SDK.Interfaces;
using RateLimiter;

namespace Fortnox.SDK.Connectors.Base;

/// <summary>
/// Rate limit - 4 requests per 1 seconds per token
/// </summary>
internal class RateLimiter : IRateLimiter
{
    private const int MaxCount = 4;
    private static readonly TimeSpan Period = TimeSpan.FromSeconds(1);

    private static readonly Dictionary<string, TimeLimiter> RateLimiters = new();

    public async Task<HttpResponseMessage> Throttle(string token, Func<Task<HttpResponseMessage>> action)
    {
        if (token == null)
            return await action().ConfigureAwait(false);

        var limiter = SelectRateLimiter(token);
        await limiter;

        return await action().ConfigureAwait(false);
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
