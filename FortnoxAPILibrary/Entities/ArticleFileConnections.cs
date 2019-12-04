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
    public class ArticleFileConnections
	{
        /// <remarks/>
		[XmlElement("ArticleFileConnectionSubset")]
		public List<ArticleFileConnectionSubset> ArticleFileConnectionSubset { get; set; }

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
	public class ArticleFileConnectionSubset
	{
		/// <remarks/>
		public string FileId { get; set; }

        /// <remarks/>
        public string ArticleNumber { get; set; }

        /// <remarks/>
        [XmlAttribute]
		public string url { get; set; }
    }
}
