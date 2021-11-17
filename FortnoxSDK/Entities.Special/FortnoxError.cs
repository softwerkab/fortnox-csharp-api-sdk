using Fortnox.SDK.Serialization;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global

namespace Fortnox.SDK.Entities;

/// <remarks/>
[Entity(SingularName = "ErrorInformation")]
public class ErrorInformation
{
    /// <remarks/>
    [JsonProperty("error")]
    public string Error { get; set; }

    /// <remarks/>
    [JsonProperty("message", Required = Required.Always)]
    public string Message { get; set; }

    /// <remarks/>
    [JsonProperty("code")]
    public string Code { get; set; }
}