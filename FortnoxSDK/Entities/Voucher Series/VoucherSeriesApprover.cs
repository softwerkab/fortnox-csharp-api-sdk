using Newtonsoft.Json;

namespace Fortnox.SDK.Entities;

public class VoucherSeriesApprover
{
    ///<summary> Id of the approver </summary>
    [JsonProperty]
    public long? Id { get; set; }

    ///<summary> Name of the approver </summary>
    [JsonProperty]
    public string Name { get; set; }
}