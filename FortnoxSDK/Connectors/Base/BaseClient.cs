using System.Net.Http;
using System.Threading.Tasks;
using Fortnox.SDK.Authorization;

namespace Fortnox.SDK.Connectors.Base;

internal abstract class BaseClient
{
    public ErrorHandler ErrorHandler { get; set; }
    public RateLimiter RateLimier { get; set; }
    public HttpClient HttpClient { get; set; }

    public bool UseRateLimiter { get; set; } = true;
    public FortnoxAuthorization Authorization { get; set; }

    protected BaseClient()
    {
        RateLimier = new RateLimiter();
        ErrorHandler = new ErrorHandler();
    }

    public async Task<byte[]> SendAsync(HttpRequestMessage request)
    {
        try
        {
            Authorization?.ApplyTo(request);

            if (UseRateLimiter)
                await RateLimier.Trottle(Authorization?.AccessToken).ConfigureAwait(false);

            using var response = await HttpClient.SendAsync(request).ConfigureAwait(false);

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