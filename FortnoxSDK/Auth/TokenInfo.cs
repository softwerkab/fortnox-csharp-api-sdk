using Newtonsoft.Json;

namespace Fortnox.SDK.Auth
{
    public class TokenInfo
    {
        /// <summary>
        /// The access token issued by the authorization server.
        /// </summary>
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        /// <summary>
        /// The refresh token, which can be used to obtain new access tokens using the same authorization grant.
        /// </summary>
        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }

        [JsonProperty("scope")]
        public string Scope { get; set; }

        /// <summary>
        /// The lifetime in seconds of the access token.
        /// </summary>
        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }

        /// <summary>
        /// The type of the token issued.
        /// </summary>
        [JsonProperty("token_type")]
        public string TokenType { get; set; }
    }
}
