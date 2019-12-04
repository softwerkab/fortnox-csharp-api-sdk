namespace FortnoxAPILibrary
{
	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
	public class Price
	{
        /// <remarks/>
		public string ArticleNumber { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [System.ComponentModel.ReadOnly(true)]
		public string Date { get; set; }

        /// <remarks/>
        public string FromQuantity { get; set; }

        /// <remarks/>
        public string Percent { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Price")]
		public string PriceValue { get; set; }

        /// <remarks/>
        public string PriceList { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [System.ComponentModel.ReadOnly(true)]
		public string url { get; set; }
    }
}