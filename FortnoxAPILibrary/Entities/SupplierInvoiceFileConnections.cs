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
	public class SupplierInvoiceFileConnections
	{

        /// <remarks/>
		[XmlElement("SupplierInvoiceFileConnectionSubset")]
		public List<SupplierInvoiceFileConnectionSubset> SupplierInvoiceFileConnectionSubset { get; set; }

        /// <remarks/>
        [XmlAttribute]
		public byte TotalResources { get; set; }

        /// <remarks/>
        [XmlAttribute]
		public byte TotalPages { get; set; }

        /// <remarks/>
        [XmlAttribute]
		public byte CurrentPage { get; set; }
    }

	/// <remarks/>
	
	[Serializable]
	
	
	[XmlType(AnonymousType = true)]
	public class SupplierInvoiceFileConnectionSubset
	{
        /// <remarks/>
		public string FileId { get; set; }

        /// <remarks/>
        public string Name { get; set; }

        /// <remarks/>
        public string SupplierInvoiceNumber { get; set; }

        /// <remarks/>
        public string SupplierName { get; set; }

        /// <remarks/>
        [XmlAttribute]
		public string url { get; set; }
    }
}
