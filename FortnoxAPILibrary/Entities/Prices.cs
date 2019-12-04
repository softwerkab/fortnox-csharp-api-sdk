using System;
using System.Collections.Generic;
using System.Xml.Serialization;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary
{
    /// <remarks/>

    [Serializable]
	
	
	[XmlType(AnonymousType = true)]
	[XmlRoot(Namespace = "", IsNullable = false)]
	public class Prices
	{
        /// <remarks/>
		[XmlElement("PriceSubset")]
		public List<PriceSubset> PriceSubset { get; set; }

        /// <remarks/>
        [XmlAttribute]
		public string TotalResources { get; set; }

        /// <remarks/>
        [XmlAttribute]
		public string TotalPages { get; set; }

        /// <remarks/>
        [XmlAttribute]
		public string CurrentPage { get; set; }
    }

	/// <remarks/>
	
	[Serializable]
	
	
	[XmlType(AnonymousType = true)]
	public class PriceSubset
	{
        /// <remarks/>
		public string ArticleNumber { get; set; }

        /// <remarks/>
        public string FromQuantity { get; set; }

        /// <remarks/>
        public string PriceList { get; set; }

        /// <remarks/>
        public string Price { get; set; }

        /// <remarks/>
        [XmlAttribute]
		public string url { get; set; }
    }
}
