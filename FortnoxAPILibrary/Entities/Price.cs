using System;
using System.ComponentModel;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
	[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
	public class Price
	{
        /// <remarks/>
		[JsonProperty]
		public string ArticleNumber { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty]
		public string Date { get; private set; }

        /// <remarks/>
        [JsonProperty]
        public string FromQuantity { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Percent { get; set; }

        /// <remarks/>
		[JsonProperty]
		public string PriceValue { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string PriceList { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty]
		public string url { get; private set; }
    }
}
