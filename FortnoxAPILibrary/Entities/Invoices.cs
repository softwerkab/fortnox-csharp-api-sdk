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
	public class Invoices
	{
		/// <remarks/>
		[JsonProperty]
		public List<InvoiceSubset> InvoiceSubset { get; set; }

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
	public class InvoiceSubset
	{
	    /// <remarks/>
		[JsonProperty]
		public string Balance { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Booked { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Cancelled { get; set; }

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
        public string CustomerName { get; set; }

        /// <remarks/>
		[JsonProperty]
		public string CustomerNumber { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string DocumentNumber { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string DueDate { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string ExternalInvoiceReference1 { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string ExternalInvoiceReference2 { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string InvoiceDate { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string NoxFinans { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string OCR { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Project { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Sent { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Total { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string TermsOfPayment { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string WayOfDelivery { get; set; }

		/// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty(PropertyName = "@url")]
		public string Url { get; private set; }
    }
}
