using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
    [Serializable]
    [XmlType(AnonymousType = true)]
	[XmlRoot(Namespace = "", IsNullable = false)]
	public class Currencies
	{
		/// <remarks/>
		[XmlElement("CurrencySubset", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public List<CurrencySubset> CurrencySubset { get; set; }
    }

	/// <remarks/>
    [Serializable]
    [XmlType(AnonymousType = true)]
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
        [XmlAttribute]
		[ReadOnly(true)]
		public string url { get; set; }
    }
}
