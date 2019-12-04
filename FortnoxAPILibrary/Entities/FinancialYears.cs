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
	public class FinancialYears
	{
		/// <remarks/>
		[XmlElement("FinancialYearSubset")]
		public List<FinancialYearSubset> FinancialYearSubset { get; set; }

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
	public class FinancialYearSubset
	{
        /// <remarks/>
		public string Id { get; set; }

        /// <remarks/>
        public string FromDate { get; set; }

        /// <remarks/>
        public string ToDate { get; set; }

        /// <remarks/>
        [XmlAttribute]
		public string url { get; set; }
    }
}
