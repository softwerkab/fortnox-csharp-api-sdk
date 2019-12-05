using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public class Articles
	{

		/// <remarks/>
		[XmlElement("ArticleSubset", Form = XmlSchemaForm.Unqualified)]
		public List<ArticleSubset> ArticleSubset { get; set; }

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
	public class ArticleSubset
	{
        /// <remarks/>
		public string ArticleNumber { get; set; }

        /// <remarks/>
        public string Description { get; set; }

        /// <remarks/>
        public string DisposableQuantity { get; set; }

        /// <remarks/>
        public string EAN { get; set; }

        /// <remarks/>
        public string Housework { get; set; }

        /// <remarks/>
        public string PurchasePrice { get; set; }

        /// <remarks/>
        [ReadOnly(true)]
	    public string SalesPrice { get; set; }

        /// <remarks/>
        public string QuantityInStock { get; set; }

        /// <remarks/>
        public string ReservedQuantity { get; set; }

        /// <remarks/>
        public string StockPlace { get; set; }

        /// <remarks/>
        public string StockValue { get; set; }

        /// <remarks/>
        public string Unit { get; set; }

        /// <remarks/>
        public string VAT { get; set; }

        /// <remarks/>
        [XmlAttribute]
		public string url { get; set; }

        /// <remarks/>
        public string WebshopArticle { get; set; }
    }
}
