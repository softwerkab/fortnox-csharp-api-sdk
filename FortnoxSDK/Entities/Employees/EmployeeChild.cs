using Fortnox.SDK.Serialization;
using Newtonsoft.Json;

namespace Fortnox.SDK.Entities;

[Entity(SingularName = "EmployeeChild", PluralName = "EmployeeChildren")]
public class EmployeeChild
{

    [JsonProperty]
    public long? ApprovedDays { get; set; }

    [JsonProperty]
    public string Child { get; set; }

    [JsonProperty]
    public string EmployeeId { get; set; }

    [JsonProperty]
    public string Id { get; set; }

    [JsonProperty]
    public long? IngoingWithdrawnDays { get; set; }

    [JsonProperty]
    public decimal? WithdrawnDays { get; set; }
}