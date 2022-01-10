using Newtonsoft.Json;

namespace Fortnox.SDK.Auth;

internal class RevokeResult
{
    [JsonProperty("revoked")]
    public bool Revoked { get; set; }
}
