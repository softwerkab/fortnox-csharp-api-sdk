using System.Collections.Generic;
using System.ComponentModel;

namespace FortnoxAPILibrary
{
	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.1432")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
	public class Currencies
	{

		private List<CurrencySubset> currencySubsetField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("CurrencySubset", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public List<CurrencySubset> CurrencySubset { get; set; }
    }

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.1432")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public class CurrencySubset
	{
        /// <remarks/>
		public string BuyRate { get; set; }

        /// <remarks/>
        public string Code { get; set; }

        /// <remarks/>
        public string Date { get; set; }

        /// <remarks/>
        public string Description { get; set; }

        /// <remarks/>
        public string SellRate { get; set; }

        /// <remarks/>
        public string Unit { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [System.Xml.Serialization.XmlAttributeAttribute()]
		[ReadOnly(true)]
		public string url { get; set; }
    }
}