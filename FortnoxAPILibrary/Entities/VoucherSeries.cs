using System;
using System.ComponentModel;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
	[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
	[Entity(SingularName = "VoucherSeries", PluralName = "VoucherSeriesCollection")]
	public class VoucherSeries : VoucherSeriesSubset
	{
		/// <remarks/>
		[JsonProperty]
		public string Code { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Description { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Manual { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string NextVoucherNumber { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty]
		public string Year { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty(PropertyName = "@url")]
		public string Url { get; private set; }
    }

    /// <remarks/>
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    [Entity(SingularName = "VoucherSeries", PluralName = "VoucherSeriesCollection")]

    public class VoucherSeriesSubset
    {
        /// <remarks/>
        [JsonProperty]
        public string Accrual { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Code { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Description { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Manual { get; set; }

        /// <remarks/>
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }
    }
}
