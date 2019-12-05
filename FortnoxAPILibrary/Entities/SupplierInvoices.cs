using System;
using System.Collections.Generic;
using System.Xml.Schema;
using System.Xml.Serialization;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>

    [Serializable]
	
	
	[XmlType(AnonymousType = true)]
	[XmlRoot(Namespace = "", IsNullable = false)]
	public class SupplierInvoices
	{
		/// <remarks/>
		[XmlElement("SupplierInvoiceSubset", Form = XmlSchemaForm.Unqualified)]
		public List<SupplierInvoiceSubset> SupplierInvoiceSubset { get; set; }

        /// <remarks/>
        [XmlAttribute]
		public string TotalResources { get; set; }

        /// <remarks/>
        [XmlAttribute]
		public string TotalPages { get; set; }

        /// <remarks/>
        [XmlAttribute]
		public string CurrentPage { get; set; }
    }

	/// <remarks/>
	
	[Serializable]
	
	
	[XmlType(AnonymousType = true)]
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
        [XmlAttribute]
		public string url { get; set; }
    }
}
