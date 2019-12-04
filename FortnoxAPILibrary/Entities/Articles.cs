using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using System.ComponentModel;
using System.Xml.Serialization;

namespace FortnoxAPILibrary
{
    /// <remarks/>
    [Serializable]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public partial class Articles
	{

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("ArticleSubset", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public List<ArticleSubset> ArticleSubset { get; set; }

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
        [System.Xml.Serialization.XmlAttributeAttribute()]
		public string url { get; set; }

        /// <remarks/>
        public string WebshopArticle { get; set; }
    }
}