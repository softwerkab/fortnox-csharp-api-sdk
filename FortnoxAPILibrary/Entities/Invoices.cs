using System.Collections.Generic;

namespace FortnoxAPILibrary
{
	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
	public partial class Invoices
	{
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("InvoiceSubset")]
		public List<InvoiceSubset> InvoiceSubset { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
		public string TotalResources { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
		public string TotalPages { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
		public string CurrentPage { get; set; }
    }

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
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
		[System.ComponentModel.ReadOnly(true)]
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string url { get; set; }
    }
}