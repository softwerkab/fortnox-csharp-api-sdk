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
	public class SupplierInvoiceAccruals : BaseEntityCollection
	{
        /// <remarks/>
		[JsonProperty(PropertyName="SupplierInvoiceAccruals")]
		public List<SupplierInvoiceAccrualSubset> SupplierInvoiceAccrualSubset { get; set; }



    }

	/// <remarks/>
	
	
	
	[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
	public class SupplierInvoiceAccrualSubset
	{
        /// <remarks/>
		[JsonProperty]
		public string Description { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string InvoiceNumber { get; set; }

        /// <remarks/>
        [JsonProperty]
        public SupplierInvoiceAccrualConnector.Period Period { get; set; }

        /// <remarks/>
		[JsonProperty(PropertyName = "@url")]
		public string Url { get; set; }
    }
}
