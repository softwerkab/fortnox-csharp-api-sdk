using System;
using Fortnox.SDK.Serialization;
using Newtonsoft.Json;

namespace Fortnox.SDK.Entities
{
    [Entity(SingularName = "PreDefinedVoucherSeries", PluralName = "PreDefinedVoucherSeriesCollection")]
    public class PredefinedVoucherSeries
    {

        ///<summary> Direct url to the record. </summary>
        [ReadOnly]
        [JsonProperty("@url")]
        public Uri Url { get; private set; }

        ///<summary> Name of voucher type </summary>
        [ReadOnly]
        [JsonProperty]
        public string Name { get; private set; }

        ///<summary> Predefined voucher series </summary>
        [JsonProperty]
        public string VoucherSeries { get; set; }
    }
}