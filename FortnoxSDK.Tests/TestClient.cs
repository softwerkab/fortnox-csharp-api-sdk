using Fortnox.SDK;
using Fortnox.SDK.Authorization;
using System;
using System.Threading.Tasks;

namespace FortnoxSDK.Tests;

public sealed class TestClient
{
    private static readonly Lazy<TestClient> lazy = new Lazy<TestClient>(() => new TestClient());

    public static TestClient Instance { get { return lazy.Value; } }

    private FortnoxClient FortnoxClient;


    private TestClient()
    {
    }

    public static async Task<FortnoxClient> GetFortnoxClient()
    {
        if (Instance.FortnoxClient is null)
        {
            var fortnoxAuthClient = new FortnoxAuthClient();
            var authWorkflow = fortnoxAuthClient.StandardAuthWorkflow;
            var token = await authWorkflow.GetTokenByClientCredentialsAsync(TestCredentials.ClientId, TestCredentials.ClientSecret, int.Parse(TestCredentials.TenantId));
            var authorization = new StandardAuth(token.AccessToken);
            Instance.FortnoxClient = new FortnoxClient(authorization)
            {
                WarehouseEnabled = true
            };
        }

        return Instance.FortnoxClient;
    }
}
