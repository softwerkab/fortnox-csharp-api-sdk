using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
    [Entity(SingularName = "Article", PluralName = "Articles")]
    public class Article 
    {
        /// <remarks/>
        [JsonProperty]
        public bool? Active { get; set; }

        /// <remarks/>
		[JsonProperty]
		public string ArticleNumber { get; set; }

        /// <remarks/>
        [JsonProperty]
        public bool? Bulky { get; set; }

        /// <remarks/>
        [JsonProperty]
        public int? ConstructionAccount { get; set; }

        /// <remarks/>
        [JsonProperty]
        public int? Depth { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Description { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[ReadOnly]
		[JsonProperty]
		public double? DisposableQuantity { get; private set; }

        /// <remarks/>
        [JsonProperty]
        public string EAN { get; set; }

        /// <remarks/>
        [JsonProperty]
        public int? EUAccount { get; set; }

        /// <remarks/>
        [JsonProperty]
        public int? EUVATAccount { get; set; }

        /// <remarks/>
        [JsonProperty]
        public bool? Expired { get; set; }

		/// <remarks/>
		[JsonProperty]
		public int? ExportAccount { get; set; }

        /// <remarks/>
        [JsonProperty]
        public int? Height { get; set; }

        /// <remarks/>
        [JsonProperty]
        public bool? Housework { get; set; }

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
        public int? PurchaseAccount { get; set; }

        /// <remarks/>
        [JsonProperty]
        public double? PurchasePrice { get; set; }

        /// <remarks/>
	    [ReadOnly]
	    [JsonProperty]
	    public double? SalesPrice { get; private set; }

        /// <remarks/>
        [JsonProperty]
        public double? QuantityInStock { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[ReadOnly]
		[JsonProperty]
		public double? ReservedQuantity { get; private set; }

        /// <remarks/>
        [JsonProperty]
        public int? SalesAccount { get; set; }

        /// <remarks/>
        [JsonProperty]
        public bool? StockGoods { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string StockPlace { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[ReadOnly]
		[JsonProperty]
		public double? StockValue { get; private set; }

        /// <remarks/>
        [JsonProperty]
        public double? StockWarning { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[ReadOnly]
		[JsonProperty]
		public string SupplierName { get; private set; }

        /// <remarks/>
        [JsonProperty]
        public string SupplierNumber { get; set; }

        /// <remarks/>
        [JsonProperty]
        public ArticleType? Type { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Unit { get; set; }

        /// <remarks/>
        [JsonProperty]
        public double? VAT { get; set; }

        /// <remarks/>
        [JsonProperty]
        public bool? WebshopArticle { get; set; }

        /// <remarks/>
        [JsonProperty]
        public int? Weight { get; set; }

        /// <remarks/>
        [JsonProperty]
        public int? Width { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[ReadOnly]
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
        public double? DisposableQuantity { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string EAN { get; set; }

        /// <remarks/>
        [JsonProperty]
        public bool? Housework { get; set; }

        /// <remarks/>
        [JsonProperty]
        public double? PurchasePrice { get; set; }

        /// <remarks/>
        [ReadOnly]
        [JsonProperty]
        public double? SalesPrice { get; private set; }

        /// <remarks/>
        [JsonProperty]
        public double? QuantityInStock { get; set; }

        /// <remarks/>
        [JsonProperty]
        public double? ReservedQuantity { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string StockPlace { get; set; }

        /// <remarks/>
        [JsonProperty]
        public double? StockValue { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Unit { get; set; }

        /// <remarks/>
        [JsonProperty]
        public double? VAT { get; set; }

        /// <remarks/>
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }

        /// <remarks/>
        [JsonProperty]
        public bool? WebshopArticle { get; set; }
    }

    /// <remarks/>
    public enum ArticleType
    {
        /// <remarks/>
        STOCK,
        /// <remarks/>
        SERVICE
    }
}
