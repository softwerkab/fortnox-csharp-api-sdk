using System;
using System.Net.Http;

namespace Fortnox.SDK.Authorization;

/// <summary>
/// Handles authorization by standard JWT token obtained by OAuth2 workflow.
/// </summary>
public class StandardAuth : FortnoxAuthorization
{
    public StandardAuth(string accessToken)
    {
        if (string.IsNullOrEmpty(accessToken))
            throw new ArgumentException("The access token is null or empty.", nameof(accessToken));

        AccessToken = accessToken;
    }

    internal override void ApplyTo(HttpRequestMessage request)
    {
        request.Headers.Add("Authorization", $"Bearer {AccessToken}");
    }
}