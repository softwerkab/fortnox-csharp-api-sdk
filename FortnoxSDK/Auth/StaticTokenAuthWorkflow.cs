using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Serialization;
using Fortnox.SDK.Utility;

namespace Fortnox.SDK.Auth;

internal class StaticTokenAuthWorkflow : BaseClient, IStaticTokenAuthWorkflow
{
    public const string ActivationUri = @"https://api.fortnox.se/3";

    public ISerializer Serializer { get; internal set; }

    public StaticTokenAuthWorkflow()
    {
        Serializer = new JsonEntitySerializer();
    }

    public string GetToken(string authCode, string clientSecret)
    {
        return GetTokenAsync(authCode, clientSecret).GetResult();
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
}