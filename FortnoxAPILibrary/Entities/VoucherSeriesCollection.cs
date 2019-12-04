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
	public partial class VoucherSeriesCollection
	{
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("VoucherSeriesSubset")]
		public List<VoucherSeriesSubset> VoucherSeriesSubset { get; set; }

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
	public partial class VoucherSeriesSubset
	{
        /// <remarks/>
		public string Accrual { get; set; }

        /// <remarks/>
        public string Code { get; set; }

        /// <remarks/>
        public string Description { get; set; }

        /// <remarks/>
        public string Manual { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
		public string url { get; set; }
    }
}