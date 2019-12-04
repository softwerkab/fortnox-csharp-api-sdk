namespace FortnoxAPILibrary
{
	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
	public partial class SupplierInvoiceFileConnection
	{
        /// <remarks/>
		public string FileId { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [System.ComponentModel.ReadOnly(true)]
		public string Name { get; set; }

        /// <remarks/>
        public string SupplierInvoiceNumber { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [System.ComponentModel.ReadOnly(true)]
		public string SupplierName { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [System.Xml.Serialization.XmlAttributeAttribute()]
		[System.ComponentModel.ReadOnly(true)]
		public string url { get; set; }
    }
}