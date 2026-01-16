using System.Net.Http;
using System.Threading.Tasks;
using Fortnox.SDK.Authorization;
using Fortnox.SDK.Interfaces;

namespace Fortnox.SDK.Connectors.Base;

internal abstract class BaseClient
{
    public ErrorHandler ErrorHandler { get; set; }
    public IRateLimiter RateLimiter { get; set; }
    public HttpClient HttpClient { get; set; }

    public bool UseRateLimiter { get; set; } = true;
    public bool UseHttp2 { get; set; } = true;
    public FortnoxAuthorization Authorization { get; set; }

    protected BaseClient()
    {
        RateLimiter = new RateLimiter();
        ErrorHandler = new ErrorHandler();
    }

    public async Task<byte[]> SendAsync(HttpRequestMessage request)
    {
        try
        {
            Authorization?.ApplyTo(request);

            if (UseHttp2)
                request.Version = new System.Version(2, 0);

            using var response = UseRateLimiter
                ? await RateLimiter.Throttle(Authorization?.AccessToken, () => HttpClient.SendAsync(request)).ConfigureAwait(false)
                : await HttpClient.SendAsync(request).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsByteArrayAsync().ConfigureAwait(false);

            await ErrorHandler.HandleErrorResponseAsync(response).ConfigureAwait(false);
            return default;
        }
        catch (HttpRequestException ex)
        {
            ErrorHandler.HandleNoResponse(ex);
            return default;
        }
    }
}