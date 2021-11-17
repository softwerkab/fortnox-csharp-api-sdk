using Newtonsoft.Json;

namespace Fortnox.SDK.Entities;

internal class SimpleError
{
    [JsonProperty("message", Required = Required.Always)]
    public string Message { get; set; }
}
