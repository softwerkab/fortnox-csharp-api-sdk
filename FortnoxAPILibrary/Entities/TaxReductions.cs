using System;
using System.Collections.Generic;
using System.Xml.Serialization;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>

    [Serializable]
	
	
	[XmlType(AnonymousType = true)]
	[XmlRoot(Namespace = "", IsNullable = false)]
	public class TaxReductions
	{
        /// <remarks/>
		[XmlElement("TaxReductionSubset")]
		public List<TaxReductionSubset> TaxReductionSubset { get; set; }

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
	public class TaxReductionSubset
	{
        /// <remarks/>
		public string ApprovedAmount { get; set; }

        /// <remarks/>
        public string CustomerName { get; set; }

        /// <remarks/>
        public string Id { get; set; }

        /// <remarks/>
        public string ReferenceDocumentType { get; set; }

        /// <remarks/>
        public string ReferenceNumber { get; set; }

        /// <remarks/>
        public string SocialSecurityNumber { get; set; }

        /// <remarks/>
        [XmlAttribute]
		public string url { get; set; }
    }
}
