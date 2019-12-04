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
	public partial class SupplierInvoiceFileConnections
	{

        /// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("SupplierInvoiceFileConnectionSubset")]
		public List<SupplierInvoiceFileConnectionSubset> SupplierInvoiceFileConnectionSubset { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
		public byte TotalResources { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
		public byte TotalPages { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
		public byte CurrentPage { get; set; }
    }

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class SupplierInvoiceFileConnectionSubset
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
        [System.Xml.Serialization.XmlAttributeAttribute()]
		public string url { get; set; }
    }
}