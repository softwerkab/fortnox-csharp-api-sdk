using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
    [Entity(SingularName = "Article", PluralName = "Articles")]
    public class ArticleSubset
    {
        ///<summary> Direct url to the record. </summary>
        [ReadOnly]
        [JsonProperty("@url")]
        public string Url { get; private set; }

        ///<summary> Article number. If no article number is provided, the next number in the series will be used. Only alpha numeric characters, with the addition of � + /  . and _, are allowed. </summary>
        [JsonProperty]
        public string ArticleNumber { get; set; }
        
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

        ///<summary> If the article is housework. </summary>
        [JsonProperty]
        public bool? Housework { get; set; }
        
        ///<summary> Purchase price of the article. </summary>
        [JsonProperty]
        public decimal? PurchasePrice { get; set; }

        ///<summary> Price of article for its default price list. </summary>
        [ReadOnly]
        [JsonProperty]
        public decimal? SalesPrice { get; private set; }

        ///<summary> Storage place for the article. </summary>
        [JsonProperty]
        public string StockPlace { get; set; }

        ///<summary> Value in stock of the article. </summary>
        [ReadOnly]
        [JsonProperty]
        public decimal? StockValue { get; private set; }

        ///<summary> Unit code for the article. The code must be of an existing unit. </summary>
        [JsonProperty]
        public string Unit { get; set; }

        ///<summary> If the article is a webshop article. </summary>
        [JsonProperty]
        public bool? WebshopArticle { get; set; }
    }
}
