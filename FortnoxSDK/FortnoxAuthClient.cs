using System.Net.Http;
using System.Threading.Tasks;
using Fortnox.SDK.Connectors;
using Fortnox.SDK.Utility;

namespace Fortnox.SDK
{
    /// <summary>
    /// Entry point for Fortnox Authorization/Authentication workflow.
    /// </summary>
    public class FortnoxAuthClient
    {
        /// <summary>
        /// Default HttpClient instance
        /// </summary>
        internal static readonly HttpClient HttpClientSharedInstance = new HttpClient();
        
        public FortnoxAuthClient()
        {
        }

        public FortnoxAuthClient(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        /// <summary>
        /// Http client used under-the-hood for all request
        /// </summary>
        public HttpClient HttpClient { get; set; } = HttpClientSharedInstance;

        /// <summary>
        /// <para>Use this function to activate new integration and retrieve Access-Token.</para>
        /// <remarks>Note that an authorization-code can be used only once. Save the retrieved Access-Token in order to use it for FortnoxClient.</remarks>
        /// </summary>
        /// <param name="authCode">The API-code (authorization code) given to you by Fortnox</param>
        /// <param name="clientSecret">The Client-Secret code given to you by Fortnox</param>
        /// <returns>The Access-Token to use with Fortnox</returns>
        public string Activate(string authCode, string clientSecret)
        {
            return ActivateAsync(authCode, clientSecret).GetResult();
        }

        /// <summary>
        /// <para>Use this function to activate new integration and retrieve Access-Token.</para>
        /// <remarks>Note that an authorization-code can be used only once. Save the retrieved Access-Token in order to use it for FortnoxClient.</remarks>
        /// </summary>
        /// <param name="authCode">The API-code (authorization code) given to you by Fortnox</param>
        /// <param name="clientSecret">The Client-Secret code given to you by Fortnox</param>
        /// <returns>The Access-Token to use with Fortnox</returns>
        public async Task<string> ActivateAsync(string authCode, string clientSecret)
        {
            var authConnector = new AuthorizationConnector()
            {
                HttpClient = HttpClient
            };
            return await authConnector.GetAccessTokenAsync(authCode, clientSecret);
        }
    }
}
