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
    public class ArticleFileConnection
	{
        /// <remarks/>
		public string FileId { get; set; }

        /// <remarks/>
        public string ArticleNumber { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [XmlAttribute]
		[ReadOnly(true)]
		public string url { get; set; }
    }
}
