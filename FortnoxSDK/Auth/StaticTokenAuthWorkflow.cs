using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Serialization;

namespace Fortnox.SDK.Auth;

internal class StaticTokenAuthWorkflow : BaseClient, IStaticTokenAuthWorkflow
{
    public const string ActivationUri = @"https://api.fortnox.se/3";
    public const string AuthRevokeUri = "https://apps.fortnox.se/oauth-v1/revoke";

    public ISerializer Serializer { get; internal set; }

    public StaticTokenAuthWorkflow(HttpClient httpClient, bool useHttp2 = true)
    {
        HttpClient = httpClient;
        Serializer = new JsonEntitySerializer();
        UseHttp2 = useHttp2;
    }

    public async Task<string> GetTokenAsync(string authCode, string clientSecret)
    {
        var httpRequest = new HttpRequestMessage(HttpMethod.Get, ActivationUri);
        httpRequest.Headers.Add("Authorization-Code", authCode);
        httpRequest.Headers.Add("Client-Secret", clientSecret);
        httpRequest.Headers.Add("Accept", "application/json");

        var responseData = await SendAsync(httpRequest).ConfigureAwait(false);
        var responseJson = Encoding.UTF8.GetString(responseData);
        var result = Serializer.Deserialize<EntityWrapper<AuthorizationData>>(responseJson);

        var accessToken = result?.Entity.AccessToken;
        return accessToken;
    }

    public async Task<bool> RevokeTokenAsync(string accessToken)
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