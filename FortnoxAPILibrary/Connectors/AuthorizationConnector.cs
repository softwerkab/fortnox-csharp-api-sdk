using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FortnoxAPILibrary.Entities;
using FortnoxAPILibrary.Entities.Special;
using FortnoxAPILibrary.Requests;

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
            var fortnoxRequest = new FortnoxRequest()
            {
                Method = HttpMethod.Get,
                BaseUrl = BaseUrl,
                Resource = Resource,
                Headers = new Dictionary<string, string>()
                {
                    { "Authorization-Code", authorizationCode },
                    { "Client-Secret", clientSecret },
                    { "Accept", "application/json" }
                }
            };

            var responseData = await SendAsync(fortnoxRequest).ConfigureAwait(false);
            var responseJson = Encoding.UTF8.GetString(responseData);
            var result = Serializer.Deserialize<EntityWrapper<AuthorizationData>>(responseJson);

            var accessToken = result?.Entity.AccessToken;
            return accessToken;
        }
    }
}
