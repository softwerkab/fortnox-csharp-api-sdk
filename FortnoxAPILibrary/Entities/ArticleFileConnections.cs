using System;
using System.Collections.Generic;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class ArticleFileConnections
	{
        /// <remarks/>
		[JsonProperty]
		public List<ArticleFileConnectionSubset> ArticleFileConnectionSubset { get; set; }

        /// <remarks/>
		[JsonProperty]
		public string TotalResources { get; set; }

        /// <remarks/>
		[JsonProperty]
		public string TotalPages { get; set; }

        /// <remarks/>
		[JsonProperty]
		public string CurrentPage { get; set; }
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
