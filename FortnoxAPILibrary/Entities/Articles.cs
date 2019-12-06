using System;
using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class Articles : BaseEntityCollection
	{

		/// <remarks/>
		[JsonProperty]
		public List<ArticleSubset> ArticleSubset { get; set; }



    }

	/// <remarks/>
	[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
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
