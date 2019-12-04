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
	public class VoucherSeriesCollection
	{
		/// <remarks/>
		[XmlElement("VoucherSeriesSubset")]
		public List<VoucherSeriesSubset> VoucherSeriesSubset { get; set; }

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
	public class VoucherSeriesSubset
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
        [XmlAttribute]
		public string url { get; set; }
    }
}
