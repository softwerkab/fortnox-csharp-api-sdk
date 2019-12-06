using System;
using System.Collections.Generic;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>

    [Serializable]
	
	
	public class SupplierInvoices
	{
		/// <remarks/>
		public List<SupplierInvoiceSubset> SupplierInvoiceSubset { get; set; }

        /// <remarks/>
		public string TotalResources { get; set; }

        /// <remarks/>
		public string TotalPages { get; set; }

        /// <remarks/>
		public string CurrentPage { get; set; }
    }

	/// <remarks/>
	
	[Serializable]
	
	
	public class SupplierInvoiceSubset
	{
        /// <remarks/>
		public string Balance { get; set; }

        /// <remarks/>
        public string Booked { get; set; }

        /// <remarks/>
        public string Cancel { get; set; }

        /// <remarks/>
        public string DueDate { get; set; }

        /// <remarks/>
        public string GivenNumber { get; set; }

        /// <remarks/>
        public string InvoiceDate { get; set; }

        /// <remarks/>
        public string InvoiceNumber { get; set; }

        /// <remarks/>
        public string SupplierNumber { get; set; }

        /// <remarks/>
        public string SupplierName { get; set; }

        /// <remarks/>
        public string Total { get; set; }

        /// <remarks/>
		public string url { get; set; }
    }
}
