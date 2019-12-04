using System;
using System.ComponentModel;
using System.Xml.Serialization;
using FortnoxAPILibrary.Connectors;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
    [Serializable]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public class Article
    {
        /// <remarks/>
        public string Active { get; set; }

        /// <remarks/>
		public string ArticleNumber { get; set; }

        /// <remarks/>
        public string Bulky { get; set; }

        /// <remarks/>
        public string ConstructionAccount { get; set; }

        /// <remarks/>
        public string Depth { get; set; }

        /// <remarks/>
        public string Description { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
		public string DisposableQuantity { get; set; }

        /// <remarks/>
        public string EAN { get; set; }

        /// <remarks/>
        public string EUAccount { get; set; }

        /// <remarks/>
        public string EUVATAccount { get; set; }

        /// <remarks/>
        public string Expired { get; set; }

		/// <remarks/>
		public string ExportAccount { get; set; }

        /// <remarks/>
        public string Height { get; set; }

        /// <remarks/>
        public string Housework { get; set; }

        /// <remarks/>
        public string HouseWorkType { get; set; }

		/// <remarks/>
		public string Manufacturer { get; set; }

        /// <remarks/>
        public string ManufacturerArticleNumber { get; set; }

        /// <remarks/>
        public string Note { get; set; }

        /// <remarks/>
        public string PurchaseAccount { get; set; }

        /// <remarks/>
        public string PurchasePrice { get; set; }

        /// <remarks/>
        [ReadOnly(true)]
	    public string SalesPrice { get; set; }

        /// <remarks/>
        public string QuantityInStock { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
		public string ReservedQuantity { get; set; }

        /// <remarks/>
        public string SalesAccount { get; set; }

        /// <remarks/>
        public string StockGoods { get; set; }

        /// <remarks/>
        public string StockPlace { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
		public string StockValue { get; set; }

        /// <remarks/>
        public string StockWarning { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
		public string SupplierName { get; set; }

        /// <remarks/>
        public string SupplierNumber { get; set; }

        /// <remarks/>
        public ArticleConnector.ArticleType? Type { get; set; }
        public bool TypeSpecified => Type != null;

        /// <remarks/>
        public string Unit { get; set; }

        /// <remarks/>
        public string VAT { get; set; }

        /// <remarks/>
        public string WebshopArticle { get; set; }

        /// <remarks/>
        public string Weight { get; set; }

        /// <remarks/>
        public string Width { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
		[XmlAttribute]
		public string url { get; set; }
    }
}
