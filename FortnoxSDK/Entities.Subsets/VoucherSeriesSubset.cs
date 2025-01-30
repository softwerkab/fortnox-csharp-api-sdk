using System;
using Fortnox.SDK.Serialization;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global

namespace Fortnox.SDK.Entities;

/// <remarks/>
[Entity(SingularName = "VoucherSeries", PluralName = "VoucherSeriesCollection")]
public class VoucherSeriesSubset
{
    ///<summary> Direct URL to the record </summary>
    [ReadOnly]
    [JsonProperty("@url")]
    public Uri Url { get; private set; }

    ///<summary> Approver </summary>
    [JsonProperty]
    public VoucherSeriesApprover Approver { get; set; }

    ///<summary> The code of the voucher series </summary>
    [JsonProperty]
    public string Code { get; set; }

    ///<summary> Description of the voucher series </summary>
    [JsonProperty]
    public string Description { get; set; }

    ///<summary> If manual </summary>
    [JsonProperty]
    public bool? Manual { get; set; }

    ///<summary> Id of the financial year </summary>
    [ReadOnly]
    [JsonProperty]
    public long? Year { get; private set; }
}