using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fortnox.SDK;
using Fortnox.SDK.Auth;
using Fortnox.SDK.Authorization;
using Fortnox.SDK.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxSDK.Tests;

[TestClass]
public class AuthTests
{
    [Ignore("Requires new authorization code.")]
    [TestMethod]
    public async Task Test_StaticTokenAuth_GetToken()
    {
        var clientSecret = TestCredentials.Client_Secret;
        var authorizationCode = "ca7f0830-ccf1-63f8-f750-1f78f50c0d58";

        var fortnoxAuthClient = new FortnoxAuthClient();
        var authWorkflow = fortnoxAuthClient.StaticTokenAuthWorkflow;

        var token = await authWorkflow.GetTokenAsync(authorizationCode, clientSecret);
        Assert.IsNotNull(token);
    }

    [Ignore("Requires valid authorization code")]
    [TestMethod]
    public async Task Test_StandardAuth_GetToken()
    {
        var clientId = "8VurtMGDTeAI"; //"bhgmY4FYebfj";
        var clientSecret = "yFKwme8LEQ"; //"TestCredentials.Client_Secret;
        var redirectUri = "https://mysite.org/activation";
        var authorizationCode = "Placeholder";

        var fortnoxAuthClient = new FortnoxAuthClient();
        var authWorkflow = fortnoxAuthClient.StandardAuthWorkflow;

        var token = await authWorkflow.GetTokenAsync(authorizationCode, clientId, clientSecret, redirectUri);
        Assert.IsNotNull(token);
    }

    [TestMethod]
    public void Test_BuildUri_Example()
    {
        var clientId = "8VurtMGDTeAI";
        var clientSecret = "yFKwme8LEQ";
        var redirectUri = "https://mysite.org/activation";
        var scopes = new List<Scope>()
        {
            Scope.CompanyInformation
        };
        var state = "somestate123";

        var fortnoxAuthClient = new FortnoxAuthClient();
        var authWorkflow = fortnoxAuthClient.StandardAuthWorkflow;

        var uri = authWorkflow.BuildAuthUri(clientId, scopes, state, redirectUri);
        Assert.AreEqual(@"https://apps.fortnox.se/oauth-v1/auth?client_id=8VurtMGDTeAI&redirect_uri=https%3A%2F%2Fmysite.org%2Factivation&scope=companyinformation&state=somestate123&access_type=offline&response_type=code", uri.AbsoluteUri);
    }

    [TestMethod]
    public void Test_BuildUri_MultipleScopes()
    {
        var clientId = "8VurtMGDTeAI";
        var clientSecret = "yFKwme8LEQ";
        var redirectUri = "https://mysite.org/activation";
        var scopes = new List<Scope>()
        {
            Scope.Article,
            Scope.Bookkeeping,
            Scope.Customer
        };
        var state = "somestate123";

        var fortnoxAuthClient = new FortnoxAuthClient();
        var authWorkflow = fortnoxAuthClient.StandardAuthWorkflow;

        var uri = authWorkflow.BuildAuthUri(clientId, scopes, state, redirectUri);
        Assert.AreEqual(@"https://apps.fortnox.se/oauth-v1/auth?client_id=8VurtMGDTeAI&redirect_uri=https%3A%2F%2Fmysite.org%2Factivation&scope=article%20bookkeeping%20customer&state=somestate123&access_type=offline&response_type=code", uri.AbsoluteUri);
    }

    [TestMethod]
    public void Test_Token_IsExpired()
    {
        var expiredToken = @"eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJ1c2VySWQiOjEsInRlbmFudElkIjoxMDE4MzE4LCJjbGllbnRJZCI6InBURkRkQ0dmaHY5YSIsInJpZ2h0c0FzSnNvbiI6Ikg0c0lBQUFBQUFBQUE0MVgyNDdqTmd6OWwzM3VHT2ducEJsTU1VQzdPOWpNUGhSRkVjZ1M0MmgwTTNSSkpuOWZ5cEljeVU2eSt4QWdJaW5xa0NLUDZIK1wvV0JpTjlhN3JEM3QzTk9lOUJXVk93UFluRStnUjdONmFzXC92eTIyd21UZDlmcW5WXC9xQmJLc0NCaFF5bTRlZzhKalB2R2g2NVdvdlp3SmhhT0pqaW90MnVKcTU1MVo4czlcL0hCZ3ZcL1BoNk9NSlwvYUU3Y0UwMDVVVCtBOFR1d0h1dWg2ektJYVFGdFVBOE9LNVBobE1nbE5wQVpLMGkwb010K3FSZ2hNdUxKK0xxY29Md3dpVzhtOTNGZVZBdlJqTGNsaDBoRXBDdGp3ekNJVHA2Sk1vRTdiTnprQTNBUmZKUU1vSTlHS3NhckJPQU5zeERoR09KZGdkWUpHQUtxVG1rTjBhMCtGTHcyYWc1NmdxUUt6SmtjMGRPMERwb1VUWXFlWEFObm5aVnBiM0JhT0VFMXNzKzcyazg0aWt4Z3hhb3dVdVhuSGcrRmRQa1hMUFdlTDdzNEkycUxPc2tqT1J5SzR4VjBocUJORlNnUFRjc3JcL3NINkRDTjRLR0VSb0dQXC90YUpGWFJqbXVTWXcyRTZPSXFyREY2dGpHV3pRU3JCV2tJWXF6MzQzZ1wvMWVxV3J0aUwwV2wxanFxd1doWHUxYkNOYVZtN0JWbm15bUNyaW1uaktmM1Y1eXRudElrMXRCZ3VnUUh1MzBld2RySEt0RFo3UFdra2ZVQmEyUm11ZzhWcHViSGhOZU4zNnVLeDVJNWQ0NXM0VEg2SVZFbGxIalpUb01haThkcWprem5PeGQzTE1NaHYwSHF1SGlyd1dSR0t4RXN1RDJnK0JNM0JYd1wvSVBCdlNDXC9JdFY0b3llZXJLNGlvanljcG5VS0x2REI0MVhoM0FVV1VFV00rUXFqQUxwaUd0amVRbUNlS1JUWDhGS3JWUldubnhXcTloQ2lLTTRYNkNLNlprcVpxSGZSN1paNW5uUFwvZmo3alVSV1dabkIzeks3dXNRZkNJSlVRNFpCNDNuZnB3Zm41aDdKVEFXMkNiM0tudnNJTjRUajJ1TjhIZE1MdDRcL1dicEhsMWNYbnE4UGxcL09ROStYak5KTlh6UkZNQ1lOd0c5S0RBdmxmS24rXC9haFhHVVwvRmQzWVJ2RVVCRzQ5V0Y4U2tYY0tYSjVOcWxYTUowN0R6SDBubWpSeFgwbnZPQlg3V0d3aFl1cFVXb0tqYkN0VVNQUmw2cGVzM0txOEc5bmZVZnpGN2FsZHJBVWJcL21KMDY5QjlWUENzb2FyZkw4TDExc0xETnNhZzZ6Y0tOTmpIeTJNZDhwdGdqOUdZN29JSXBiZk0zZWtsOEEyaksxeEtXSUYrTlFFV1ZTR3FiekUrY0RQTkZvZjI4dzhXVUdhTTBSNnBhNk1LeUtiS3E3emNDS2FwME1zR1ByNjdJdjBDRFIrSk5ZZFBtaDRcLzlRWHp4TlBOMWJwNFdsRVNBR1kyVUJ6b2tUemdqU1dGZmJFSWlqaldDb1cyNnc5WlhKUTBEeFE0V2cyeXNRb1l2VkVpZlZySk83T1VTSU5QUVwvT0tuaUxBUTZzSFhHWWI3ZkhXOHFDQllUS0pyOVZsU1JQQnVrZHduOWVtOFwveXBGR3JPc1ZqRCtFTXVwMk1FalhZUzRjaE5ldlJtZ1wva3pBTlNwem1Ic1ZZNURuTTdOUHUzeGpVeTVCSXEzZ3pYalRRMjlTWTlrSzZXeDZ5YkM4RFM2Mmd4TldGazZVWnFGUEM1UkxINmlpakdtYUZxR1VXMDJBUytsZWFudXpITXBCZ1RYV2FIYUFlamY1a29EdWFSNG9iSkRrZFVcL3RnazltaXRSODRlWlhBUFh1Tkp2UWlXWW9CSUxqRWdta1lWWXp2R1hWNzhzUmhpN3UwNDRTQWVjXC8wODczeGdURWFza3hQOHF1OVloM1dnZDR3K2JzUEZMc0Y2d0E4OG01dm9LNXhqNmxBVmhVK1JBOU1SSlNWeXNGT21rdm1yUnY3REhQNXBES3UxZ0orWXI3ckhhMmU1Z290R0VZM2M5b3pjaEo4VkhOWXUzNnpKSlBYTlpyb3NCcmtSSDFnczdxK0lWM05abGhNcGIwampwOHRiaU4rSERsWW5aTEw5KzM0WTQwKzIzc3NaRXFSK1N4SHVZcGVcL2t6S2pyZmxSM3VYSDZTNlQrZlJGdkdGNFZtdzZnb1dBZWtaV3psQTBXRE1SVXBvdllCNFF2dnozUHhUUVVZdVRFQUFBIiwic2NvcGVzIjpbImNvbXBhbnlpbmZvcm1hdGlvbiIsImJvb2trZWVwaW5nIiwiY29zdGNlbnRlciJdLCJhdXRoc291cmNlIjoiT0FVVEgyIiwiaWQiOiI4OTE3MGMxNGRjMWNlNzU4YmI4Nzg2ZDc3N2FhNmM2MTkyNDAxMTIwIiwianRpIjoiODkxNzBjMTRkYzFjZTc1OGJiODc4NmQ3NzdhYTZjNjE5MjQwMTEyMCIsImlzcyI6Imh0dHBzOlwvXC9hcGkuZm9ydG5veC5zZVwvb2F1dGgyIiwiYXVkIjoicFRGRGRDR2ZodjlhIiwic3ViIjoiMUAxMDE4MzE4IiwiZXhwIjoxNjM3MjM0NTkwLCJpYXQiOjE2MzcyMzA5OTAsInRva2VuX3R5cGUiOiJiZWFyZXIiLCJzY29wZSI6ImNvbXBhbnlpbmZvcm1hdGlvbiBib29ra2VlcGluZyBjb3N0Y2VudGVyIn0.96U6tfHiKYrPU0Med6Fv0PikhrfPaIBInlObq0KjlNs";
        var auth = new StandardAuth(expiredToken);

        var isExpired = auth.IsExpired();

        Assert.AreEqual(true, isExpired);
    }

    [TestMethod]
    public async Task Revoke_RefreshToken()
    {
        var authClient = new FortnoxAuthClient();
        var authWorkflow = authClient.StandardAuthWorkflow;

        var refreshToken = TestUtils.RandomString(40);
        var clientId = "pTFDdCGfhv9a";
        var clientSecret = "xcvtLzVjVs";

        var success = await authWorkflow.RevokeRefreshTokenAsync(refreshToken, clientId, clientSecret);
        Assert.IsTrue(success);
    }

    [TestMethod]
    public async Task Revoke_LegacyToken()
    {
        var authClient = new FortnoxAuthClient();
        var authWorkflow = authClient.StaticTokenAuthWorkflow;

        var accessToken = Guid.NewGuid().ToString();

        var success = await authWorkflow.RevokeTokenAsync(accessToken);
        Assert.IsTrue(success);
    }

    [TestMethod]
    public async Task New_Sandbox()
    {
        var authorization = new StaticTokenAuth("6a5f9523-0f21-4488-801f-6094faba624d", "1Pevde6Pls");
        var client = new FortnoxClient(authorization);

        var company = await client.CompanyInformationConnector.GetAsync();
        Assert.AreEqual("Richard-Sandbox-2022", company.CompanyName);
    }
}