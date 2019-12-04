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
	public class Suppliers
	{
        /// <remarks/>
		[XmlElement("SupplierSubset", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public List<SupplierSubset> SupplierSubset { get; set; }

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
	public class SupplierSubset
	{

        /// <remarks/>
		public string City { get; set; }

        /// <remarks/>
        public string Email { get; set; }

        /// <remarks/>
        public string Name { get; set; }

        /// <remarks/>
        public string OrganisationNumber { get; set; }

        /// <remarks/>
        public string Phone { get; set; }

        /// <remarks/>
        public string SupplierNumber { get; set; }

        /// <remarks/>
        public string ZipCode { get; set; }

        /// <remarks/>
        [XmlAttribute]
		public string url { get; set; }
    }
}
