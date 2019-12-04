using System;
using System.ComponentModel;
using System.Xml.Serialization;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary
{
    /// <remarks/>

    [Serializable]
	
	
	[XmlType(AnonymousType = true)]
	[XmlRoot(Namespace = "", IsNullable = false)]
	public class SupplierInvoiceFileConnection
	{
        /// <remarks/>
		public string FileId { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
		public string Name { get; set; }

        /// <remarks/>
        public string SupplierInvoiceNumber { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
		public string SupplierName { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [XmlAttribute]
		[ReadOnly(true)]
		public string url { get; set; }
    }
}
