using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Serialization;
using Fortnox.SDK.Utility;

namespace Fortnox.SDK.Auth
{
    internal class StandardAuthWorkflow : BaseClient, IStandardAuthWorkflow
    {
        public const string AuthInitUri = "https://apps.fortnox.se/oauth-v1/auth";
        public const string AuthTokenUri = "https://apps.fortnox.se/oauth-v1/token";
        public ISerializer Serializer { get; internal set; }

        public StandardAuthWorkflow()
        {
            Serializer = new JsonEntitySerializer();
        }

        public TokenInfo GetToken(string authCode, string clientId, string clientSecret, string redirectUri = null)
        {
            return GetTokenAsync(authCode, clientId, clientSecret, redirectUri).GetResult();
        }

        public async Task<TokenInfo> GetTokenAsync(string authCode, string clientId, string clientSecret, string redirectUri = null)
        {
            var credentials = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{clientId}:{clientSecret}"));

            var request = new HttpRequestMessage(HttpMethod.Post, AuthTokenUri);
            request.Headers.Add("Authorization", $"Basic {credentials}");

            var parameters = new Dictionary<string, string>();
            parameters.Add("grant_type", "authorization_code");
            parameters.Add("code", authCode);
            if (redirectUri != null)
                parameters.Add("redirect_uri", redirectUri);

            request.Content = new FormUrlEncodedContent(parameters);

            var responseData = await SendAsync(request);
            var responseJson = Encoding.UTF8.GetString(responseData);
            var tokenInfo = Serializer.Deserialize<TokenInfo>(responseJson);

            return tokenInfo;
        }

        public TokenInfo RefreshToken(string refreshToken, string clientId, string clientSecret)
        {
            return RefreshTokenAsync(refreshToken, clientId, clientSecret).GetResult();
        }

        public async Task<TokenInfo> RefreshTokenAsync(string refreshToken, string clientId, string clientSecret)
        {
            var credentials = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{clientId}:{clientSecret}"));

            var request = new HttpRequestMessage(HttpMethod.Post, AuthTokenUri);
            request.Headers.Add("Authorization", $"Basic {credentials}");

            var parameters = new Dictionary<string, string>();
            parameters.Add("grant_type", "refresh_token");
            parameters.Add("refresh_token", refreshToken);

            request.Content = new FormUrlEncodedContent(parameters);

            var response = await HttpClient.SendAsync(request);
            var json = await response.Content.ReadAsStringAsync();
            var token = Serializer.Deserialize<TokenInfo>(json);

            return token;
        }

        public string BuildAuthUri(string clientId, IEnumerable<Scope> scopes, string state, string redirectUri = null)
        {
            var parameters = new Dictionary<string, string>();
            parameters.Add("client_id", clientId);
            if (redirectUri != null)
                parameters.Add("redirect_uri", redirectUri);
            parameters.Add("scope", string.Join(" ", scopes.Select(s => s.GetStringValue())));
            parameters.Add("state", state);
            parameters.Add("access_type", "offline");
            parameters.Add("response_type", "code");

            var query = string.Join("&",parameters.Select(p => $"{p.Key}={HttpUtility.UrlEncode(p.Value)}"));
            var uri = string.Join("?", AuthInitUri, query);

            return new Uri(uri).AbsoluteUri;
        }
    }
}