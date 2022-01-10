using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Serialization;
using Fortnox.SDK.Utility;

namespace Fortnox.SDK.Auth;

internal class StandardAuthWorkflow : BaseClient, IStandardAuthWorkflow
{
    public const string AuthInitUri = "https://apps.fortnox.se/oauth-v1/auth";
    public const string AuthTokenUri = "https://apps.fortnox.se/oauth-v1/token";
    public const string AuthRevokeUri = "https://apps.fortnox.se/oauth-v1/revoke";
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
        if (string.IsNullOrEmpty(authCode))
            throw new ArgumentException("Argument is null or empty.", nameof(authCode));

        if (string.IsNullOrEmpty(clientId))
            throw new ArgumentException("Argument is null or empty.", nameof(clientId));

        if (string.IsNullOrEmpty(clientSecret))
            throw new ArgumentException("Argument is null or empty.", nameof(clientSecret));

        var credentials = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{clientId}:{clientSecret}"));

        var request = new HttpRequestMessage(HttpMethod.Post, AuthTokenUri);
        request.Headers.Add("Authorization", $"Basic {credentials}");

        var parameters = new Dictionary<string, string>();
        parameters.Add("grant_type", "authorization_code");
        parameters.Add("code", authCode);
        if (redirectUri != null)
            parameters.Add("redirect_uri", redirectUri);

        request.Content = new FormUrlEncodedContent(parameters);

        var responseData = await SendAsync(request).ConfigureAwait(false);
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
        if (string.IsNullOrEmpty(refreshToken))
            throw new ArgumentException("Argument is null or empty.", nameof(refreshToken));

        if (string.IsNullOrEmpty(clientId))
            throw new ArgumentException("Argument is null or empty.", nameof(clientId));

        if (string.IsNullOrEmpty(clientSecret))
            throw new ArgumentException("Argument is null or empty.", nameof(clientSecret));

        var credentials = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{clientId}:{clientSecret}"));

        var request = new HttpRequestMessage(HttpMethod.Post, AuthTokenUri);
        request.Headers.Add("Authorization", $"Basic {credentials}");

        var parameters = new Dictionary<string, string>();
        parameters.Add("grant_type", "refresh_token");
        parameters.Add("refresh_token", refreshToken);

        request.Content = new FormUrlEncodedContent(parameters);

        var responseData = await SendAsync(request).ConfigureAwait(false);
        var responseJson = Encoding.UTF8.GetString(responseData);
        var tokenInfo = Serializer.Deserialize<TokenInfo>(responseJson);

        return tokenInfo;
    }

    public string GenerateState()
    {
        var data = new byte[32];

        using var rng = new RNGCryptoServiceProvider();
        rng.GetBytes(data);

        var state = Convert.ToBase64String(data).Replace('+', '-').Replace('/', '_').TrimEnd('=');

        return state;
    }

    public Uri BuildAuthUri(string clientId, IEnumerable<Scope> scopes, string state, string redirectUri = null)
    {
        if (string.IsNullOrEmpty(clientId))
            throw new ArgumentException("Argument is null or empty.", nameof(clientId));

        if (scopes == null)
            throw new ArgumentNullException(nameof(scopes), "Argument is null.");

        if (!scopes.Any())
            throw new ArgumentException("Collection is empty. No scopes specified.", nameof(scopes));

        if (string.IsNullOrEmpty(state))
            throw new ArgumentException("Argument is null or empty.", nameof(state));

        var parameters = new Dictionary<string, string>();
        parameters.Add("client_id", clientId);
        if (redirectUri != null)
            parameters.Add("redirect_uri", redirectUri);
        parameters.Add("scope", string.Join(" ", scopes.Select(s => s.GetStringValue())));
        parameters.Add("state", state);
        parameters.Add("access_type", "offline");
        parameters.Add("response_type", "code");

        var query = string.Join("&", parameters.Select(p => $"{p.Key}={Uri.EscapeDataString(p.Value)}"));
        var uri = string.Join("?", AuthInitUri, query);

        return new Uri(uri);
    }

    public async Task<bool> RevokeRefreshTokenAsync(string refreshToken, string clientId, string clientSecret)
    {
        if (string.IsNullOrEmpty(refreshToken))
            throw new ArgumentException("Argument is null or empty.", nameof(refreshToken));

        if (string.IsNullOrEmpty(clientId))
            throw new ArgumentException("Argument is null or empty.", nameof(clientId));

        if (string.IsNullOrEmpty(clientSecret))
            throw new ArgumentException("Argument is null or empty.", nameof(clientSecret));

        var credentials = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{clientId}:{clientSecret}"));

        var request = new HttpRequestMessage(HttpMethod.Post, AuthRevokeUri);
        request.Headers.Add("Authorization", $"Basic {credentials}");

        var parameters = new Dictionary<string, string>();
        parameters.Add("token_type_hint", "refresh_token");
        parameters.Add("token", refreshToken);

        request.Content = new FormUrlEncodedContent(parameters);

        var responseData = await SendAsync(request).ConfigureAwait(false);
        var responseJson = Encoding.UTF8.GetString(responseData);
        var result = Serializer.Deserialize<RevokeResult>(responseJson);

        return result.Revoked;
    }

    public async Task<bool> RevokeLegacyTokenAsync(string accessToken)
    {
        if (string.IsNullOrEmpty(accessToken))
            throw new ArgumentException("Argument is null or empty.", nameof(accessToken));

        var request = new HttpRequestMessage(HttpMethod.Post, AuthRevokeUri);

        var parameters = new Dictionary<string, string>();
        parameters.Add("token", accessToken);
        
        var formData = new MultipartFormDataContent();

        foreach (var parameter in parameters)
            formData.Add(new StringContent(parameter.Value), parameter.Key);

        request.Content = formData;

        var responseData = await SendAsync(request).ConfigureAwait(false);
        var responseJson = Encoding.UTF8.GetString(responseData);
        var result = Serializer.Deserialize<RevokeResult>(responseJson);

        return result.Revoked;
    }
}
