using System;
using System.ComponentModel;
using FortnoxAPILibrary.Connectors;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
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
		public string DisposableQuantity { get; private set; }

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
	    public string SalesPrice { get; private set; }

        /// <remarks/>
        public string QuantityInStock { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		public string ReservedQuantity { get; private set; }

        /// <remarks/>
        public string SalesAccount { get; set; }

        /// <remarks/>
        public string StockGoods { get; set; }

        /// <remarks/>
        public string StockPlace { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		public string StockValue { get; private set; }

        /// <remarks/>
        public string StockWarning { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		public string SupplierName { get; private set; }

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
		public string url { get; private set; }

        /// <remarsk/>
        public string FreightCost { get; set; }

        /// <remarsk/>
        public string OtherCost { get; set; }

        /// <remarsk/>
        public string CostCalculationMethod { get; set; }
    }
}
