using System;
using System.Collections.Generic;
using System.Xml.Schema;
using System.Xml.Serialization;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>

    [Serializable]
	
	
	[XmlType(AnonymousType = true)]
	[XmlRoot(Namespace = "", IsNullable = false)]
	public class TermsOfPayments
	{
		/// <remarks/>
		[XmlElement("TermsOfPaymentSubset", Form = XmlSchemaForm.Unqualified)]
		public List<TermsOfPaymentSubset> TermsOfPaymentSubset { get; set; }

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
	public class TermsOfPaymentSubset
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
