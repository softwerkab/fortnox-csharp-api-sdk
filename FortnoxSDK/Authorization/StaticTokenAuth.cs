using System.Net.Http;

namespace Fortnox.SDK.Authorization
{
    /// <summary>
    /// Handles authorization by non-expirable AccessToken and ClientSecret.
    /// Can only be used for unpublished Fortnox apps/integrations.
    /// </summary>
    public class StaticTokenAuth : FortnoxAuthorization

    {
        public string AccessToken { get; set; }
        public string ClientSecret { get; set; }

        public StaticTokenAuth(string accessToken, string clientSecret)
        {
            AccessToken = accessToken;
            ClientSecret = clientSecret;
        }

        internal override void ApplyTo(HttpRequestMessage request)
        {
            request.Headers.Add("Access-Token", AccessToken);
            request.Headers.Add("Client-Secret", ClientSecret);
        }
    }
}