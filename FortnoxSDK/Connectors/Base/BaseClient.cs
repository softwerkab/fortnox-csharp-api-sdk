using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ComposableAsync;
using RateLimiter;

namespace Fortnox.SDK.Connectors.Base
{
    public abstract class BaseClient
    {
        private const string AccessTokenHeader = "Access-Token";
        private const string ClientSecretHeader = "Client-Secret";

        private const int LimitPerSecond = 4;
        private static readonly Dictionary<string, TimeLimiter> RateLimiters = new Dictionary<string, TimeLimiter>();
        
        private ErrorHandler ErrorHandler { get; }

        public HttpClient HttpClient { get; set; }

        public string AccessToken { get; set; }
        public string ClientSecret { get; set; }

        public bool UseRateLimiter { get; set; }
        protected bool UseAuthHeaders { get; set; }

        protected BaseClient()
        {
            HttpClient = FortnoxClient.HttpClientSharedInstance;
            ErrorHandler = new ErrorHandler();

            AccessToken = ConnectionCredentials.AccessToken;
            ClientSecret = ConnectionCredentials.ClientSecret;
            UseRateLimiter = true;
            UseAuthHeaders = true;
        }

        public async Task<byte[]> SendAsync(HttpRequestMessage request)
        {
            try
            {
                if (UseAuthHeaders)
                {
                    request.Headers.Add(AccessTokenHeader, AccessToken);
                    request.Headers.Add(ClientSecretHeader, ClientSecret);
                }

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
            if (string.IsNullOrEmpty(AccessToken))
                return;

            var limiter = SelectRateLimiter(AccessToken);
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
}
