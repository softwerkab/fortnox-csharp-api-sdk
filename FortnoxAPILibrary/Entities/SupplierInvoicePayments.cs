using System;
using System.Collections.Generic;
using System.Xml.Serialization;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>

    [Serializable]
	
	
	[XmlType(AnonymousType = true)]
	[XmlRoot(Namespace = "", IsNullable = false)]
	public class SupplierInvoicePayments
	{
        /// <remarks/>
		[XmlElement("SupplierInvoicePaymentSubset")]
		public List<SupplierInvoicePaymentSubset> SupplierInvoicePaymentSubset { get; set; }

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
	public class SupplierInvoicePaymentSubset
	{
        /// <remarks/>
		public string Amount { get; set; }

        /// <remarks/>
        public string Booked { get; set; }

        /// <remarks/>
        public string Currency { get; set; }

        /// <remarks/>
        public string CurrencyRate { get; set; }

        /// <remarks/>
        public string CurrencyUnit { get; set; }

        /// <remarks/>
        public string InvoiceNumber { get; set; }

        /// <remarks/>
        public string Number { get; set; }

        /// <remarks/>
        public string Source { get; set; }

        /// <remarks/>
        [XmlAttribute]
		public string url { get; set; }
    }
}
