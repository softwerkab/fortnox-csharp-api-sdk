using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using ComposableAsync;
using FortnoxAPILibrary.SDK.Auth;
using RateLimiter;

namespace FortnoxAPILibrary
{
    public class BaseClient
    {
        private const int LimitPerSecond = 4;
        private static readonly Dictionary<string, TimeLimiter> RateLimiters = new Dictionary<string, TimeLimiter>();

        /// <summary>
        /// Http client used under-the-hood for all request (except file upload due to a server-side limitation)
        /// </summary>
        private HttpClient HttpClient { get; }
        
        public FortnoxAuthorization Authorization { get; set; }

        public int Timeout
        {
            get => (int) HttpClient.Timeout.TotalMilliseconds;
            set => HttpClient.Timeout = TimeSpan.FromMilliseconds(value);
        }

        /// <summary>
        /// Base fortnox server URI
        /// </summary>
        public string BaseUrl { get; set; }

        public bool UseRateLimiter { get; set; }

        public BaseClient()
        {
            HttpClient = new HttpClient();
            
            BaseUrl = ConnectionSettings.FortnoxAPIServer;
            Timeout = ConnectionSettings.Timeout;
            UseRateLimiter = ConnectionSettings.UseRateLimiter;
        }

        public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
        {
            Authorization?.ApplyTo(request);

            if (UseRateLimiter)
                await Throttle();

            return await HttpClient.SendAsync(request).ConfigureAwait(false);
        }

        public async Task<HttpWebResponse> SendAsync(HttpWebRequest request)
        {
            Authorization?.ApplyTo(request);
            
            request.Timeout = Timeout;

            if (UseRateLimiter)
                await Throttle();

            return (HttpWebResponse) await request.GetResponseAsync().ConfigureAwait(false);
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
}
