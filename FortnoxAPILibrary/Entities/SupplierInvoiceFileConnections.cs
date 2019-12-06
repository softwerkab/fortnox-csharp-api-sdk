using System;
using System.Collections.Generic;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>

	
	
	public class SupplierInvoiceFileConnections
	{

        /// <remarks/>
		public List<SupplierInvoiceFileConnectionSubset> SupplierInvoiceFileConnectionSubset { get; set; }

        /// <remarks/>
		public byte TotalResources { get; set; }

        /// <remarks/>
		public byte TotalPages { get; set; }

        /// <remarks/>
		public byte CurrentPage { get; set; }
    }

	/// <remarks/>
	
	
	
	public class SupplierInvoiceFileConnectionSubset
	{
        /// <remarks/>
		public string FileId { get; set; }

        /// <remarks/>
        public string Name { get; set; }

        /// <remarks/>
        public string SupplierInvoiceNumber { get; set; }

        /// <remarks/>
        public string SupplierName { get; set; }

        /// <remarks/>
		public string url { get; set; }
    }
}
