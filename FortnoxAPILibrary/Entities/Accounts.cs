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
    public class Accounts
	{
        /// <remarks/>
		[XmlElement("AccountSubset", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public List<AccountSubset> AccountSubset { get; set; }

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
	public class AccountSubset
	{
        /// <remarks/>
		public string Active { get; set; }

        /// <remarks/>
        public string Description { get; set; }

        /// <remarks/>
        public string Number { get; set; }

        /// <remarks/>
        public string SRU { get; set; }

        /// <remarks/>
        public string Year { get; set; }

        /// <remarks/>
        [XmlAttribute]
		public string url { get; set; }
    }
}
