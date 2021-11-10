using Newtonsoft.Json;

namespace Fortnox.SDK.Entities;

public class AuthError
{
    [JsonProperty("error")]
    public string Error { get; set; }

    [JsonProperty("error_description")]
    public string ErrorDescription { get; set; }
}