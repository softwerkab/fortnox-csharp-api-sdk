using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>

    [Serializable]
	
	
	[XmlType(AnonymousType = true)]
	[XmlRoot(Namespace = "", IsNullable = false)]
	public class Invoices
	{
		/// <remarks/>
		[XmlElement("InvoiceSubset")]
		public List<InvoiceSubset> InvoiceSubset { get; set; }

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
	public class InvoiceSubset
	{
	    /// <remarks/>
		public string Balance { get; set; }

        /// <remarks/>
        public string Booked { get; set; }

        /// <remarks/>
        public string Cancelled { get; set; }

        /// <remarks/>
        public string Currency { get; set; }

        /// <remarks/>
        public string CurrencyRate { get; set; }

        /// <remarks/>
        public string CurrencyUnit { get; set; }

        /// <remarks/>
        public string CustomerName { get; set; }

        /// <remarks/>
		public string CustomerNumber { get; set; }

        /// <remarks/>
        public string DocumentNumber { get; set; }

        /// <remarks/>
        public string DueDate { get; set; }

        /// <remarks/>
        public string ExternalInvoiceReference1 { get; set; }

        /// <remarks/>
        public string ExternalInvoiceReference2 { get; set; }

        /// <remarks/>
        public string InvoiceDate { get; set; }

        /// <remarks/>
        public string NoxFinans { get; set; }

        /// <remarks/>
        public string OCR { get; set; }

        /// <remarks/>
        public string Project { get; set; }

        /// <remarks/>
        public string Sent { get; set; }

        /// <remarks/>
        public string Total { get; set; }

        /// <remarks/>
        public string TermsOfPayment { get; set; }

        /// <remarks/>
        public string WayOfDelivery { get; set; }

		/// <summary>This field is Read-Only in Fortnox</summary>
		[ReadOnly(true)]
		[XmlAttribute]
		public string url { get; set; }
    }
}
