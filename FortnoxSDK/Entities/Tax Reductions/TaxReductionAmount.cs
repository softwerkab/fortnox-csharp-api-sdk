using Newtonsoft.Json;

namespace Fortnox.SDK.Entities;

public class TaxReductionAmount
{
    ///<summary> Asked amount </summary>
    [JsonProperty]
    public double AskedAmount { get; set; }

    ///<summary> Tax reduction work type </summary>
    [JsonProperty]
    public TaxReductionWorkType WorkType { get; set; }
}