using System.Collections.Generic;

namespace FortnoxAPILibrary
{
	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.1432")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
	public partial class SupplierInvoices
	{
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("SupplierInvoiceSubset", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public List<SupplierInvoiceSubset> SupplierInvoiceSubset { get; set; }

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
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.1432")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class SupplierInvoiceSubset
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
        [System.Xml.Serialization.XmlAttributeAttribute()]
		public string url { get; set; }
    }
}