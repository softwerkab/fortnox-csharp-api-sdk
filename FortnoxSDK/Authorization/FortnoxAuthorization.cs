using System.Net.Http;

namespace Fortnox.SDK.Authorization;

/// <summary>
/// Represents authorization/credentials for accessing Fortnox API
/// </summary>
public abstract class FortnoxAuthorization
{
    public string AccessToken { get; set; }
    internal abstract void ApplyTo(HttpRequestMessage request);
}