using System;
using System.ComponentModel;
using System.Xml.Serialization;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary
{
    /// <remarks/>

    [Serializable]
	
	
	[XmlType(AnonymousType = true)]
	[XmlRoot(Namespace = "", IsNullable = false)]
	public class PriceList
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
		[ReadOnly(true)]
		[XmlAttribute]
		public string url { get; set; }
    }
}
