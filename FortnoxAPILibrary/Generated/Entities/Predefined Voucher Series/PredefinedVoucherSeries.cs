using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FortnoxAPILibrary.Entities
{
    [Entity(SingularName = "PredefinedVoucherSeries", PluralName = "PredefinedVoucherSeries")]
    public class PredefinedVoucherSeries
    {

        ///<summary> Direct url to the record. </summary>
        [ReadOnly]
        [JsonProperty("@url")]
        public string Url { get; private set; }

        ///<summary> Name of voucher type </summary>
        [ReadOnly]
        [JsonProperty]
        public string Name { get; private set; }

        ///<summary> Predefined voucher series </summary>
        [JsonProperty]
        public string VoucherSeries { get; set; }
    }
}