using System.Net;
using System.Net.Http;

namespace FortnoxAPILibrary.SDK.Auth
{
    /// <summary>
    /// Handles authorization by standard JWT token obtained by OAuth2 workflow.
    /// </summary>
    public class StandardAuth : FortnoxAuthorization

    {
        public StandardAuth(string accessToken)
        {
            AccessToken = accessToken;
        }

        internal override void ApplyTo(HttpRequestMessage request)
        {
            request.Headers.Add("Authorization", $"Bearer {AccessToken}");
        }
        
        internal override void ApplyTo(HttpWebRequest request)
        {
            request.Headers.Add("Authorization", $"Bearer {AccessToken}");
        }
    }
}