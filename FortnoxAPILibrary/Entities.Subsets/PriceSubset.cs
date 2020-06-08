using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
    [Entity(SingularName = "Price", PluralName = "Prices")]
    public class PriceSubset
    {
        ///<summary> Direct URL to the record </summary>
        [ReadOnly]
        [JsonProperty("@url")]
        public string Url { get; private set; }

        ///<summary> The article number </summary>
        [JsonProperty]
        public string ArticleNumber { get; set; }

        ///<summary> The quantity from where the price is applicable. </summary>
        [JsonProperty]
        public decimal? FromQuantity { get; set; }

        ///<summary> The price </summary>
        [JsonProperty("Price")]
        public decimal? PriceValue { get; set; }

        ///<summary> Price list of the price </summary>
        [JsonProperty]
        public string PriceList { get; set; }
    }
}
