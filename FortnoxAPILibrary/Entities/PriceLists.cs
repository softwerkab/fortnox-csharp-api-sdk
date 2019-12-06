using System;
using System.Collections.Generic;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>

	
	
	[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
	public class PriceLists
	{
        /// <remarks/>
		[JsonProperty]
		public List<PriceListSubset> PriceListSubset { get; set; }

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
	public class PriceListSubset
	{
        /// <remarks/>
		[JsonProperty]
		public string Code { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Description { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Comments { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string PreSelected { get; set; }

		/// <remarks/>
		[JsonProperty]
		public string url { get; set; }
    }
}
