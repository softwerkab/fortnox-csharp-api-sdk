using System;
using System.Collections.Generic;
using FortnoxAPILibrary.Connectors;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>

	
	
	public class SupplierInvoiceAccruals
	{
        /// <remarks/>
		public List<SupplierInvoiceAccrualSubset> SupplierInvoiceAccrualSubset { get; set; }

        /// <remarks/>
		public string TotalResources { get; set; }

        /// <remarks/>
		public string TotalPages { get; set; }

        /// <remarks/>
		public string CurrentPage { get; set; }
    }

	/// <remarks/>
	
	
	
	public class SupplierInvoiceAccrualSubset
	{
        /// <remarks/>
		public string Description { get; set; }

        /// <remarks/>
        public string InvoiceNumber { get; set; }

        /// <remarks/>
        public SupplierInvoiceAccrualConnector.Period Period { get; set; }

        /// <remarks/>
		public string url { get; set; }
    }
}
