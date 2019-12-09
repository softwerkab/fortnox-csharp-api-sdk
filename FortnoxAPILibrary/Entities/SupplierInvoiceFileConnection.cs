using System;
using System.ComponentModel;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
	[Entity(SingularName = "SupplierInvoiceFileConnection", PluralName = "SupplierInvoiceFileConnections")]
	public class SupplierInvoiceFileConnection 
	{
        /// <remarks/>
		[JsonProperty]
		public string FileId { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty]
		public string Name { get; private set; }

        /// <remarks/>
        [JsonProperty]
        public string SupplierInvoiceNumber { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty]
		public string SupplierName { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty(PropertyName = "@url")]
		public string Url { get; private set; }
    }

    /// <remarks/>
    [Entity(SingularName = "SupplierInvoiceFileConnection", PluralName = "SupplierInvoiceFileConnections")]
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
