using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    [Entity(SingularName = "ArticleFileConnection", PluralName = "ArticleFileConnections")]
    public class ArticleFileConnection : ArticleFileConnectionSubset
	{
        /// <remarks/>
		[JsonProperty]
		public string FileId { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string ArticleNumber { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty(PropertyName = "@url")]
		public string Url { get; private set; }
    }

    /// <remarks/>
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class ArticleFileConnectionSubset
    {
        /// <remarks/>
        [JsonProperty]
        public string FileId { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string ArticleNumber { get; set; }

        /// <remarks/>
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }
    }
}
