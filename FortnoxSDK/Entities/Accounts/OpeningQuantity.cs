using Fortnox.SDK.Serialization;
using Newtonsoft.Json;

namespace Fortnox.SDK.Entities;

[Entity(SingularName = "Quantity", PluralName = "Quantities")]
public class OpeningQuantity
{

    ///<summary> Balance </summary>
    [JsonProperty]
    public long? Balance { get; set; }

    ///<summary> Project </summary>
    [JsonProperty]
    public string Project { get; set; }
}