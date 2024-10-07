using System;
using Fortnox.SDK.Serialization;
using Newtonsoft.Json;

namespace Fortnox.SDK.Entities;

[Entity(SingularName = "VoucherFileConnection", PluralName = "VoucherFileConnections")]
public class VoucherFileConnection
{

    ///<summary> Direct URL to the record </summary>
    [ReadOnly]
    [JsonProperty("@url")]
    public Uri Url { get; private set; }

    ///<summary> Id of the file </summary>
    [JsonProperty]
    public string FileId { get; set; }

    ///<summary> Name of the file </summary>
    [ReadOnly]
    [JsonProperty]
    public string Name { get; private set; }

    ///<summary> Description of the voucher </summary>
    [ReadOnly]
    [JsonProperty]
    public string VoucherDescription { get; private set; }

    ///<summary> Voucher number </summary>
    [JsonProperty]
    public long? VoucherNumber { get; set; }

    ///<summary> Voucher series </summary>
    [JsonProperty]
    public string VoucherSeries { get; set; }

    ///<summary> Voucher year </summary>
    [ReadOnly]
    [JsonProperty]
    public long? VoucherYear { get; private set; }
}