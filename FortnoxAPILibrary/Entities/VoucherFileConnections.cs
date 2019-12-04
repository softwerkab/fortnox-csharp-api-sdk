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
	public class VoucherFileConnections
	{
		/// <remarks/>
		[XmlElement("VoucherFileConnectionSubset")]
		public List<VoucherFileConnectionSubset> VoucherFileConnectionSubset { get; set; }

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
	public class VoucherFileConnectionSubset
	{
		/// <remarks/>
		public string FileId { get; set; }

        /// <remarks/>
        public string VoucherDescription { get; set; }

        /// <remarks/>
        public string VoucherNumber { get; set; }

        /// <remarks/>
        public string VoucherSeries { get; set; }

        /// <remarks/>
        public string VoucherYear { get; set; }

        /// <remarks/>
        [XmlAttribute]
		public string url { get; set; }
    }
}
