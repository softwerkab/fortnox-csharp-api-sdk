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
	public class TermsOfDeliveries
	{
        /// <remarks/>
		[XmlElement("TermsOfDeliverySubset", Form = XmlSchemaForm.Unqualified)]
		public List<TermsOfDeliverySubset> TermsOfDeliverySubset { get; set; }

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
	public class TermsOfDeliverySubset
	{

		private string codeField;

		private string descriptionField;

		private string urlField;

		/// <remarks/>
		public string Code
		{
			get
			{
				return codeField;
			}
			set
			{
				codeField = value;
			}
		}

		/// <remarks/>
		public string Description
		{
			get
			{
				return descriptionField;
			}
			set
			{
				descriptionField = value;
			}
		}

		/// <remarks/>
		[XmlAttribute]
		public string url
		{
			get
			{
				return urlField;
			}
			set
			{
				urlField = value;
			}
		}
	}
}
