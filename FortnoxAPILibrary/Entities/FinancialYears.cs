using System;
using System.Collections.Generic;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>

	[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
	public class FinancialYears
	{
		/// <remarks/>
		[JsonProperty]
		public List<FinancialYearSubset> FinancialYearSubset { get; set; }

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
	public class FinancialYearSubset
	{
        /// <remarks/>
		[JsonProperty]
		public string Id { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string FromDate { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string ToDate { get; set; }

        /// <remarks/>
		[JsonProperty(PropertyName = "@url")]
		public string Url { get; set; }
    }
}
