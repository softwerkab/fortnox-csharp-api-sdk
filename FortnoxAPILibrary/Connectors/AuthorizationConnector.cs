using System.Net.Http;
using System.Threading.Tasks;
using FortnoxAPILibrary.Entities;
using FortnoxAPILibrary.Entities.Special;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class AuthorizationConnector : BaseConnector, IAuthorizationConnector
    {
        public AuthorizationConnector()
        {
            Resource = "";
            UseAuthHeaders = false;
        }

        /// <summary>
        /// <para>Use this function to create and get your Access-Token.</para>
        /// <para>NOTE!</para>
        /// <para>This function should be used only once to get your access-token. If used again the authorisation-code given to you by Fortnox will be invalid. </para>
        /// </summary>
        /// <param name="authorizationCode">The authorisation-code given to you by Fortnox</param>
        /// <param name="clientSecret">The Client-Secret code given to you by Fortnox</param>
        /// <returns>The Access-Token to use with Fortnox</returns>
        public string GetAccessToken(string authorizationCode, string clientSecret)
        {
            return GetAccessTokenAsync(authorizationCode, clientSecret).GetResult();
        }

        public async Task<string> GetAccessTokenAsync(string authorizationCode, string clientSecret)
        {
            if (string.IsNullOrEmpty(authorizationCode))
                return null;
            if (string.IsNullOrEmpty(clientSecret))
                return null;

            try
            {
                var wr = SetupRequest(BaseUrl+"/"+Resource, authorizationCode, clientSecret);
                using var response = await HttpClient.SendAsync(wr).ConfigureAwait(false);

                if (!response.IsSuccessStatusCode)
                {
                    ErrorHandler.HandleErrorResponse(response);
                    return null;
                }

                var json = response.Content.ReadAsStringAsync().GetResult();
                var result = Serializer.Deserialize<EntityWrapper<AuthorizationData>>(json);

                var accessToken = result?.Entity.AccessToken;
                return accessToken;
            }
            catch (HttpRequestException we)
            {
                ErrorHandler.HandleNoResponse(we);
                return null;
            }
        }

        private HttpRequestMessage SetupRequest(string requestUriString, string authorizationCode, string clientSecret)
        {
            var wr = new HttpRequestMessage(HttpMethod.Get,  requestUriString);
            wr.Headers.Add("Authorization-Code", authorizationCode);
            wr.Headers.Add("Client-Secret", clientSecret);
            wr.Headers.Add("Accept", "application/json");
            return wr;
        }
    }
}
