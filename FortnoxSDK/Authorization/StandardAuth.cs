using System.Net.Http;

namespace Fortnox.SDK.Authorization
{
    /// <summary>
    /// Handles authorization by standard JWT token obtained by OAuth2 workflow.
    /// Can only be used for published Fortnox apps.
    /// </summary>
    public class StandardAuth : FortnoxAuthorization

    {
        public string AccessToken { get; set; }

        public StandardAuth(string accessToken)
        {
            AccessToken = accessToken;
        }

        internal override void ApplyTo(HttpRequestMessage request)
        {
            request.Headers.Add("Authorization", $"Bearer {AccessToken}");
        }
    }
}