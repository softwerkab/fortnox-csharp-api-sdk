using System;
using System.Xml.Serialization;
using System.ComponentModel;
using System.Xml.Serialization;

namespace FortnoxAPILibrary
{
    /// <remarks/>
    [Serializable]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public class ArticleFileConnection
	{
        /// <remarks/>
		public string FileId { get; set; }

        /// <remarks/>
        public string ArticleNumber { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [System.Xml.Serialization.XmlAttributeAttribute()]
		[System.ComponentModel.ReadOnly(true)]
		public string url { get; set; }
    }
}