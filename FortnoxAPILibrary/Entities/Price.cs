using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
	[Entity(SingularName = "Price", PluralName = "Prices")]
	public class Price 
	{
        /// <remarks/>
		[JsonProperty]
		public string ArticleNumber { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[ReadOnly]
		[JsonProperty]
		public string Date { get; private set; }

        /// <remarks/>
        [JsonProperty]
        public string FromQuantity { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Percent { get; set; }

        /// <remarks/>
		[JsonProperty]
		public string PriceValue { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string PriceList { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[ReadOnly]
		[JsonProperty(PropertyName = "@url")]
		public string Url { get; private set; }
    }

    [Entity(SingularName = "Price", PluralName = "Prices")]
    public class PriceSubset
    {
        /// <remarks/>
        [JsonProperty]
        public string ArticleNumber { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string FromQuantity { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string PriceList { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Price { get; set; }

        /// <remarks/>
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }
    }
}
