using System;
using System.Collections.Generic;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
	public class SupplierInvoiceFileConnections : BaseEntityCollection
	{

        /// <remarks/>
		[JsonProperty(PropertyName="SupplierInvoiceFileConnections")]
		public List<SupplierInvoiceFileConnectionSubset> SupplierInvoiceFileConnectionSubset { get; set; }
    }

	/// <remarks/>
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
	public class SupplierInvoiceFileConnectionSubset
	{
        /// <remarks/>
		[JsonProperty]
		public string FileId { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Name { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string SupplierInvoiceNumber { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string SupplierName { get; set; }

        /// <remarks/>
		[JsonProperty(PropertyName = "@url")]
		public string Url { get; set; }
    }
}
