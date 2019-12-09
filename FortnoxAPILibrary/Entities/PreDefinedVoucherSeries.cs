using System;
using System.ComponentModel;
using FortnoxAPILibrary.Connectors;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
    [Entity(SingularName = "PreDefinedVoucherSeries", PluralName = "PreDefinedVoucherSeriesCollection")]
    public class PreDefinedVoucherSeries
    {
        /// <summary>This field is Read-Only in Fortnox</summary>
        [JsonProperty]
        public PreDefinedVoucherSeriesConnector.PreDefinedVoucherSeriesName Name { get; private set; }

        /// <remarks/>
        [JsonProperty]
        public string VoucherSeries { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; private set; }
    }

    [Entity(SingularName = "PreDefinedVoucherSeries", PluralName = "PreDefinedVoucherSeriesCollection")]
    public class PreDefinedVoucherSeriesSubset
    {
        /// <remarks/>
        [JsonProperty]
        public string Name { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string VoucherSeries { get; set; }

        /// <remarks/>
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }
    }
}
