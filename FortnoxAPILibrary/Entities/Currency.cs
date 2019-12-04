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
	public class Currency
	{
        /// <summary>
		/// <para>The buy rate of the currency</para>
		/// <para>Required:		No</para>
		/// <para>Type:			Float</para>
		/// <para>Permissions:	RW</para>
		/// </summary>
		public string BuyRate { get; set; }

        /// <summary>
        /// <para>Code of the currency</para>
        /// <para>Required:		Yes</para>
        /// <para>Limits:		3 chars, A-Z</para>
        /// <para>Type:			String</para>
        /// <para>Permissions:	RW</para>
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// <para>Date of creation</para>
        /// <para>Type:			Date</para>
        /// <para>Permissions:	R</para>
        /// </summary>
        [ReadOnly(true)]
		public string Date { get; set; }

        /// <summary>
        /// <para>Description of the currency</para>
        /// <para>Required:		No</para>
        /// <para>Type:			Date</para>
        /// <para>Permissions:	R</para>
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// <para>The sell rate of the currency</para>
        /// <para>Required:		No</para>
        /// <para>Type:			Float</para>
        /// <para>Permissions:	RW</para>
        /// </summary>
        public string SellRate { get; set; }

        /// <summary>
        /// <para>The unit of the currency</para>
        /// <para>Required:		No</para>
        /// <para>Type:			Float</para>
        /// <para>Permissions:	RW</para>
        /// </summary>
        public string Unit { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [System.Xml.Serialization.XmlAttributeAttribute()]
		[ReadOnly(true)]
		public string url { get; set; }
    }
}


