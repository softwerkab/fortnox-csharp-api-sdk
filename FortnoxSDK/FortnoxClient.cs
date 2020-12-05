using Fortnox.SDK.Connectors.Base;
using System.Net.Http;

namespace Fortnox.SDK
{
    /// <summary>
    /// Factory for creating connectors. All connectors will be created using configured set-up.
    /// </summary>
    public class FortnoxClient
    {
        /// <summary>
        /// Default HttpClient instance
        /// </summary>
        internal static readonly HttpClient HttpClientSharedInstance = new HttpClient();

        /// <summary>
        /// Http client used under-the-hood for all request
        /// </summary>
        public HttpClient HttpClient { get; set; } = HttpClientSharedInstance;

        /// <summary>
        /// AccessToken needed for authentication with server
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// ClientSecret needed for authentication with server
        /// </summary>
        public string ClientSecret { get; set; }

        /// <summary>
        /// RateLimiter throttles thread for each request, which prevents connection failure due to server side rate limit
        /// If set to false, TooManyRequest error can occur.
        /// </summary>
        public bool UseRateLimiter { get; set; } = true;

        /// <summary>
        /// Creates a configured instance of a connector.
        /// </summary>
        /// <typeparam name="TConnector">Connector type to be created. In future, interface type may be used instead</typeparam>
        /// <returns></returns>
        public TConnector Get<TConnector>() where TConnector : BaseConnector, new()
        {
            return new TConnector()
            {
                AccessToken = AccessToken,
                ClientSecret = ClientSecret,
                UseRateLimiter = UseRateLimiter,
                HttpClient = HttpClient
            };
        }
    }
}
