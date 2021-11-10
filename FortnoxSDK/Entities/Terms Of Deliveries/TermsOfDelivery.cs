using System;
using Fortnox.SDK.Serialization;
using Newtonsoft.Json;

namespace Fortnox.SDK.Entities;

[Entity(SingularName = "TermsOfDelivery", PluralName = "TermsOfDeliveries")]
public class TermsOfDelivery
{

    ///<summary> Direct url to the record </summary>
    [ReadOnly]
    [JsonProperty("@url")]
    public Uri Url { get; private set; }

    ///<summary> Code of the term of delivery </summary>
    [JsonProperty]
    public string Code { get; set; }

    ///<summary> Description of the term of delivery </summary>
    [JsonProperty]
    public string Description { get; set; }
}