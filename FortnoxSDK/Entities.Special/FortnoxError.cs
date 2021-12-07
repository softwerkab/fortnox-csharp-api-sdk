using Fortnox.SDK.Serialization;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global

namespace Fortnox.SDK.Entities;

[Entity(SingularName = "ErrorInformation")]
public class ErrorInformation
{
    [JsonProperty("error")]
    public string Error { get; set; }

    [JsonProperty("message", Required = Required.Always)]
    public string Message { get; set; }

    [JsonProperty("code")]
    public string Code { get; set; }
}