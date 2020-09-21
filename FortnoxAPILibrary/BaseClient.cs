using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using ComposableAsync;
using RateLimiter;

namespace FortnoxAPILibrary
{
    public class BaseClient
    {
        private const string AccessTokenHeader = "Access-Token";
        private const string ClientSecretHeader = "Client-Secret";
        
        /// <summary>
        /// Http client used under-the-hood for all request (except file upload due to a server-side limitation)
        /// </summary>
        private HttpClient HttpClient { get; }

        /// <summary>
        /// Optional Fortnox Access Token, if used it will override the static version.
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// Optional Fortnox Client Secret, if used it will override the static version.
        /// </summary>
        public string ClientSecret { get; set; }

        /// <summary>
        /// Timeout of requests sent to the Fortnox API in miliseconds
        /// </summary>
        public int Timeout
        {
            get => (int) HttpClient.Timeout.TotalMilliseconds;
            set => HttpClient.Timeout = TimeSpan.FromMilliseconds(value);
        }

        /// <summary>
        /// Base fortnox server URI
        /// </summary>
        public string BaseUrl
        {
            get => HttpClient.BaseAddress.AbsoluteUri;
            set => HttpClient.BaseAddress = new Uri(value);
        }

        public bool UseRateLimiter { get; set; }

        private const int LimitPerSecond = 3;
        private static readonly TimeLimiter RateLimiter = TimeLimiter.GetFromMaxCountByInterval(LimitPerSecond, TimeSpan.FromSeconds(1));

        public BaseClient()
        {
            HttpClient = new HttpClient();

            AccessToken = ConnectionCredentials.AccessToken;
            ClientSecret = ConnectionCredentials.ClientSecret;
            BaseUrl = ConnectionSettings.FortnoxAPIServer;
            Timeout = 30 * 10000;
            UseRateLimiter = ConnectionSettings.UseRateLimiter;
        }

        public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
        {
            request.Headers.Add(AccessTokenHeader, AccessToken);
            request.Headers.Add(ClientSecretHeader, ClientSecret);

            if (UseRateLimiter)
                await RateLimiter; //throttle every call to Fortnox

            return await HttpClient.SendAsync(request).ConfigureAwait(false);
        }

        public async Task<HttpWebResponse> SendAsync(HttpWebRequest request)
        {
            request.Headers.Add(AccessTokenHeader, AccessToken);
            request.Headers.Add(ClientSecretHeader, ClientSecret);
            request.Timeout = Timeout;

            if (UseRateLimiter)
                await RateLimiter; //throttle every call to Fortnox

            return (HttpWebResponse) await request.GetResponseAsync().ConfigureAwait(false);
        }
    }
}
