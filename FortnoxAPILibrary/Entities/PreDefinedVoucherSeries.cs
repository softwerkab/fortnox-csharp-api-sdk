using System;
using System.ComponentModel;
using FortnoxAPILibrary.Connectors;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class PreDefinedVoucherSeries {

        /// <summary>This field is Read-Only in Fortnox</summary>
        [JsonProperty]
        public PreDefinedVoucherSeriesConnector.PreDefinedVoucherSeriesName Name { get; private set; }

        /// <remarks/>
        [JsonProperty]
        public string VoucherSeries { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [JsonProperty]
        public string url { get; private set; }
    }
}
