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
	public class PreDefinedAccounts
	{
        /// <remarks/>
		[XmlElement("PreDefinedAccountSubset")]
		public List<PreDefinedAccountSubset> PreDefinedAccountSubset { get; set; }

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
	public class PreDefinedAccountSubset
	{
        /// <remarks/>
		public string Account { get; set; }

        /// <remarks/>
        public string Name { get; set; }

        /// <remarks/>
        [XmlAttribute]
		public string url { get; set; }
    }
}
