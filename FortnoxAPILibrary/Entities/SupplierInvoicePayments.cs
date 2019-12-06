using System;
using System.Collections.Generic;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>

	
	
	[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
	public class SupplierInvoicePayments
	{
        /// <remarks/>
		[JsonProperty]
		public List<SupplierInvoicePaymentSubset> SupplierInvoicePaymentSubset { get; set; }

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
	public class SupplierInvoicePaymentSubset
	{
        /// <remarks/>
		[JsonProperty]
		public string Amount { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Booked { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Currency { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string CurrencyRate { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string CurrencyUnit { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string InvoiceNumber { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Number { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Source { get; set; }

        /// <remarks/>
		[JsonProperty]
		public string url { get; set; }
    }
}
