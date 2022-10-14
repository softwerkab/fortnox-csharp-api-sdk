using Fortnox.SDK.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Fortnox.SDK.Entities;

[Entity(SingularName = "CustomerReference", PluralName = "CustomerReference")]
internal class CustomerReference
{
    [JsonProperty]
    public IList<CustomerReferenceRow> CustomerReferenceRows { get; set; }
}