using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using FortnoxAPILibrary.Connectors;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
    [Serializable]
    [XmlType(AnonymousType = true)]
	[XmlRoot(Namespace = "", IsNullable = false)]
	public class InvoiceAccruals
	{
        /// <remarks/>
		[XmlElement("InvoiceAccrualSubset")]
		public List<InvoiceAccrualSubset> InvoiceAccrualSubset { get; set; }

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
	public class InvoiceAccrualSubset
	{
        /// <remarks/>
		public string Description { get; set; }

        /// <remarks/>
        public string InvoiceNumber { get; set; }

        /// <remarks/>
        public InvoiceAccrualConnector.Period Period { get; set; }

        /// <remarks/>
        [XmlAttribute]
		public string url { get; set; }
    }
}
