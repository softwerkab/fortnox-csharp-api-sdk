using System;
using System.Collections.Generic;
using FortnoxAPILibrary.Connectors;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
	[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
	public class InvoiceAccruals
	{
        /// <remarks/>
		[JsonProperty]
		public List<InvoiceAccrualSubset> InvoiceAccrualSubset { get; set; }

        /// <remarks/>
		[JsonProperty]
		public string TotalResources { get; set; }

        /// <remarks/>
		[JsonProperty]
		public string TotalPages { get; set; }

        /// <remarks/>
		[JsonProperty]
		public string CurrentPage { get; set; }
    }

	/// <remarks/>
	[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
	public class InvoiceAccrualSubset
	{
        /// <remarks/>
		[JsonProperty]
		public string Description { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string InvoiceNumber { get; set; }

        /// <remarks/>
        [JsonProperty]
        public InvoiceAccrualConnector.Period Period { get; set; }

        /// <remarks/>
		[JsonProperty(PropertyName = "@url")]
		public string Url { get; set; }
    }
}
