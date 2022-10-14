using Fortnox.SDK.Serialization;
using Newtonsoft.Json;

namespace Fortnox.SDK.Entities;

[Entity(SingularName = "CustomerReferenceRow")]
public class CustomerReferenceRow
{
    [JsonProperty]
    public string Reference { get; set; }

    [JsonProperty]
    public string CustomerNumber { get; set; }

    [ReadOnly]
    [JsonProperty]
    public long? Id { get; set; } 
}