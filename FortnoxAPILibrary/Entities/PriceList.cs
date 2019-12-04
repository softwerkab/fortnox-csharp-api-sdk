namespace FortnoxAPILibrary
{
	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
	public partial class PriceList
	{
        /// <remarks/>
		public string Code { get; set; }

        /// <remarks/>
        public string Description { get; set; }

        /// <remarks/>
        public string Comments { get; set; }

        /// <remarks/>
        public string PreSelected { get; set; }

		/// <summary>This field is Read-Only in Fortnox</summary>
		[System.ComponentModel.ReadOnly(true)]
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string url { get; set; }
    }
}