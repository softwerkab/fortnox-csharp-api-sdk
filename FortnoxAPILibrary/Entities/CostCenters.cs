using System;
using System.Collections.Generic;
using System.Xml.Schema;
using System.Xml.Serialization;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary
{
    /// <remarks/>
    [Serializable]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public class CostCenters
	{
		/// <remarks/>
		[XmlElement("CostCenterSubset", Form = XmlSchemaForm.Unqualified)]
		public List<CostCenterSubset> CostCenterSubset { get; set; }

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
    [XmlRoot(Namespace = "", IsNullable = false)]
    public class CostCenterSubset
	{
        /// <remarks/>
		public string Code { get; set; }

        /// <remarks/>
        public string Description { get; set; }

        /// <remarks/>
        public string Note { get; set; }

        /// <remarks/>
        public string Active { get; set; }

        /// <remarks/>
        [XmlAttribute]
		public string url { get; set; }
    }
}
