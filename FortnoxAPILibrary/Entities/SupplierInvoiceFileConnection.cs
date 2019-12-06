using System;
using System.ComponentModel;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>

	
	
	public class SupplierInvoiceFileConnection
	{
        /// <remarks/>
		public string FileId { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		public string Name { get; private set; }

        /// <remarks/>
        public string SupplierInvoiceNumber { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		public string SupplierName { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		public string url { get; private set; }
    }
}
