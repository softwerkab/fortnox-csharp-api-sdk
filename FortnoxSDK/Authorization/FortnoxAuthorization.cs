using System.Net.Http;

namespace Fortnox.SDK.Authorization;

/// <summary>
/// Represents authorization/credentials for accessing the Fortnox API.
/// </summary>
public abstract class FortnoxAuthorization
{
    public string AccessToken { get; set; }

    /// <summary>
    /// Applies credentials to the http request, typically sets headers.
    /// </summary>
    public abstract void ApplyTo(HttpRequestMessage request);
}