using System;
using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
	[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
	public class Currencies
	{
		/// <remarks/>
		[JsonProperty]
		public List<CurrencySubset> CurrencySubset { get; set; }
    }

	/// <remarks/>
	[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
	public class CurrencySubset
	{
        /// <remarks/>
		[JsonProperty]
		public string BuyRate { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Code { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Date { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Description { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string SellRate { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Unit { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty(PropertyName = "@url")]
		public string Url { get; private set; }
    }
}
