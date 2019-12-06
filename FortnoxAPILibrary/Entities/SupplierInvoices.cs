using System;
using System.Collections.Generic;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>

	
	
	[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
	public class SupplierInvoices : BaseEntityCollection
	{
		/// <remarks/>
		[JsonProperty(PropertyName="SupplierInvoices")]
		public List<SupplierInvoiceSubset> SupplierInvoiceSubset { get; set; }



    }

	/// <remarks/>
	
	
	
	[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
	public class SupplierInvoiceSubset
	{
        /// <remarks/>
		[JsonProperty]
		public string Balance { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Booked { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Cancel { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string DueDate { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string GivenNumber { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string InvoiceDate { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string InvoiceNumber { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string SupplierNumber { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string SupplierName { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Total { get; set; }

        /// <remarks/>
		[JsonProperty(PropertyName = "@url")]
		public string Url { get; set; }
    }
}
