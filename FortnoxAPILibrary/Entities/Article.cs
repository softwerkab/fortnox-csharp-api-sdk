using FortnoxAPILibrary.Connectors;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
    [Entity(SingularName = "Article", PluralName = "Articles")]
    public class Article : ArticleSubset
    {
        /// <remarks/>
        [JsonProperty]
        public string Active { get; set; }

        /// <remarks/>
		[JsonProperty]
		public string ArticleNumber { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Bulky { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string ConstructionAccount { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Depth { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Description { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty]
		public string DisposableQuantity { get; private set; }

        /// <remarks/>
        [JsonProperty]
        public string EAN { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string EUAccount { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string EUVATAccount { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Expired { get; set; }

		/// <remarks/>
		[JsonProperty]
		public string ExportAccount { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Height { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Housework { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string HouseWorkType { get; set; }

		/// <remarks/>
		[JsonProperty]
		public string Manufacturer { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string ManufacturerArticleNumber { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Note { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string PurchaseAccount { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string PurchasePrice { get; set; }

        /// <remarks/>
	    [JsonProperty]
	    public string SalesPrice { get; private set; }

        /// <remarks/>
        [JsonProperty]
        public string QuantityInStock { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty]
		public string ReservedQuantity { get; private set; }

        /// <remarks/>
        [JsonProperty]
        public string SalesAccount { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string StockGoods { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string StockPlace { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty]
		public string StockValue { get; private set; }

        /// <remarks/>
        [JsonProperty]
        public string StockWarning { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty]
		public string SupplierName { get; private set; }

        /// <remarks/>
        [JsonProperty]
        public string SupplierNumber { get; set; }

        /// <remarks/>
        [JsonProperty]
        public ArticleConnector.ArticleType? Type { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Unit { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string VAT { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string WebshopArticle { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Weight { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Width { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty(PropertyName = "@url")]
		public string Url { get; private set; }

        /// <remarsk/>
        [JsonProperty]
        public string FreightCost { get; set; }

        /// <remarsk/>
        [JsonProperty]
        public string OtherCost { get; set; }

        /// <remarsk/>
        [JsonProperty]
        public string CostCalculationMethod { get; set; }
    }

    /// <remarks/>
    [Entity(SingularName = "Article", PluralName = "Articles")]
    public class ArticleSubset
    {
        /// <remarks/>
        [JsonProperty]
        public string ArticleNumber { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Description { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string DisposableQuantity { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string EAN { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Housework { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string PurchasePrice { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string SalesPrice { get; private set; }

        /// <remarks/>
        [JsonProperty]
        public string QuantityInStock { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string ReservedQuantity { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string StockPlace { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string StockValue { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Unit { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string VAT { get; set; }

        /// <remarks/>
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string WebshopArticle { get; set; }
    }
}
