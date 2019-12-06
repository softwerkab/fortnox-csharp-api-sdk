using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace FortnoxAPILibrary.Entities
{
// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

    /// <remarks/>
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class PreDefinedVoucherSeriesCollection {
        /// <remarks/>
        [JsonProperty]
        public List<PreDefinedVoucherSeriesSubset> PreDefinedVoucherSeriesSubset { get; set; }
    }

    /// <remarks/>
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class PreDefinedVoucherSeriesSubset {
        /// <remarks/>
        [JsonProperty]
        public string Name { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string VoucherSeries { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string url { get; set; }
    }
}
