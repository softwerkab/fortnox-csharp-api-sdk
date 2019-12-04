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
    public class Accounts
	{
        /// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("AccountSubset", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public List<AccountSubset> AccountSubset { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
		public string TotalResources { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
		public string TotalPages { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
		public string CurrentPage { get; set; }
    }

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.1432")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
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
        [System.Xml.Serialization.XmlAttributeAttribute()]
		public string url { get; set; }
    }
}
