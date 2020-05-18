using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;

namespace FortnoxAPILibrary.Entities
{
    [Entity(SingularName = "Article", PluralName = "Articles")]
    public class Article
    {

        ///<summary> Direct url to the record. </summary>
        [ReadOnly]
        [JsonProperty("@url")]
        public string Url { get; private set; }

        ///<summary> If the article is active </summary>
        [JsonProperty]
        public bool? Active { get; set; }

        ///<summary> Article number. If no article number is provided, the next number in the series will be used. Only alpha numeric characters, with the addition of – + /  . and _, are allowed. </summary>
        [JsonProperty]
        public string ArticleNumber { get; set; }

        ///<summary> If the article is bulky. </summary>
        [JsonProperty]
        public bool? Bulky { get; set; }

        ///<summary> Account number for construction work (special VAT rules in Sweden). The number must be of an existing account. </summary>
        [JsonProperty]
        public int? ConstructionAccount { get; set; }

        ///<summary> The depth of the article in millimeters. </summary>
        [JsonProperty]
        public int? Depth { get; set; }

        ///<summary> The description of the article. </summary>
        [JsonProperty]
        public string Description { get; set; }

        ///<summary> Disposable quantity of the article. </summary>
        [ReadOnly]
        [JsonProperty]
        public decimal? DisposableQuantity { get; private set; }

        ///<summary> EAN bar code. </summary>
        [JsonProperty]
        public string EAN { get; set; }

        ///<summary> Account number for the sales account to EU. The number must be of an existing account. </summary>
        [JsonProperty]
        public int? EUAccount { get; set; }

        ///<summary> Account number for the sales account to EU with VAT. The number must be of an existing account. </summary>
        [JsonProperty]
        public int? EUVATAccount { get; set; }

        ///<summary> Account number for the sales account outside EU. The number must be of an existing account. </summary>
        [JsonProperty]
        public int? ExportAccount { get; set; }

        ///<summary> The height of the article in millimeters. </summary>
        [JsonProperty]
        public int? Height { get; set; }

        ///<summary> If the article is housework. </summary>
        [JsonProperty]
        public bool? Housework { get; set; }

        ///<summary> The type of house work. </summary>
        [JsonProperty]
        public HouseworkType? HouseworkType { get; set; }

        ///<summary> The manufacturer of the article </summary>
        [JsonProperty]
        public string Manufacturer { get; set; }

        ///<summary> The manufacturers article number. </summary>
        [JsonProperty]
        public string ManufacturerArticleNumber { get; set; }

        ///<summary> Text note. </summary>
        [JsonProperty]
        public string Note { get; set; }

        ///<summary> Account number for purchase. The number must be of an existing account. </summary>
        [JsonProperty]
        public int? PurchaseAccount { get; set; }

        ///<summary> Purchase price of the article. </summary>
        [JsonProperty]
        public decimal? PurchasePrice { get; set; }

        ///<summary> Quantity in stock of the article. </summary>
        [JsonProperty]
        public decimal? QuantityInStock { get; set; }

        ///<summary> Reserved quantity of the article. </summary>
        [ReadOnly]
        [JsonProperty]
        public decimal? ReservedQuantity { get; private set; }

        ///<summary> Account number for the sales account in Sweden. The number must be of an existing account. </summary>
        [JsonProperty]
        public int? SalesAccount { get; set; }

        ///<summary> Price of article for its default price list. </summary>
        [ReadOnly]
        [JsonProperty]
        public decimal? SalesPrice { get; private set; }

        ///<summary> If the article is stock goods. </summary>
        [JsonProperty]
        public bool? StockGoods { get; set; }

        ///<summary> Storage place for the article. </summary>
        [JsonProperty]
        public string StockPlace { get; set; }

        ///<summary> Value in stock of the article. </summary>
        [ReadOnly]
        [JsonProperty]
        public decimal? StockValue { get; private set; }

        ///<summary> When to start warning for low quantity in stock. </summary>
        [JsonProperty]
        public decimal? StockWarning { get; set; }

        ///<summary> Name of the supplier. </summary>
        [ReadOnly]
        [JsonProperty]
        public string SupplierName { get; private set; }

        ///<summary> Supplier number for the article. The number must be of an existing supplier. </summary>
        [JsonProperty]
        public string SupplierNumber { get; set; }

        ///<summary> The type of the article. Can be STOCK or SERVICE. </summary>
        [JsonProperty]
        public ArticleType? Type { get; set; }

        ///<summary> Unit code for the article. The code must be of an existing unit. </summary>
        [JsonProperty]
        public string Unit { get; set; }

        ///<summary> VAT percent, this is predefined by the VAT for the sales account. </summary>
        [JsonProperty]
        public decimal? VAT { get; set; }

        ///<summary> If the article is a webshop article. </summary>
        [JsonProperty]
        public bool? WebshopArticle { get; set; }

        ///<summary> Weight of the article in grams. </summary>
        [JsonProperty]
        public int? Weight { get; set; }

        ///<summary> Width of the article in millimeters. </summary>
        [JsonProperty]
        public int? Width { get; set; }

        ///<summary> If the article has expired. </summary>
        [JsonProperty]
        public bool? Expired { get; set; }

        ///<summary> Method for setting purchase price on the article, either manually by setting DirectCost, FreightCost and OtherCost manually (MANUAL), or automatically updated by the cost used in the lastest inbound delivery for the article (LAST_RELEASED_INBOUND ) </summary>
        [JsonProperty]
        public string CostCalculationMethod { get; set; }

        ///<summary> Custom bookkeeping account used for stock for the article </summary>
        [JsonProperty]
        public int? StockAccount { get; set; }

        ///<summary> Purchase price – Direct cost </summary>
        [JsonProperty]
        public int? DirectCost { get; set; }

        ///<summary> Purchase price – Freight cost </summary>
        [JsonProperty]
        public int? FreightCost { get; set; }

        ///<summary> Purchase price – Other cost </summary>
        [JsonProperty]
        public int? OtherCost { get; set; }
    }
}