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
	public class WayOfDeliveries
	{
		/// <remarks/>
		[XmlElement("WayOfDeliverySubset", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public List<WayOfDeliverySubset> WayOfDeliverySubset { get; set; }
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
	public class WayOfDeliverySubset
	{
        /// <remarks/>
		public string Code { get; set; }

        /// <remarks/>
        public string Description { get; set; }

        /// <remarks/>
        [XmlAttribute]
		public string url { get; set; }
    }
}
