using System;
using System.Collections.Generic;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>

	
	
	[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
	public class VoucherFileConnections
	{
		/// <remarks/>
		[JsonProperty]
		public List<VoucherFileConnectionSubset> VoucherFileConnectionSubset { get; set; }

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
	public class VoucherFileConnectionSubset
	{
		/// <remarks/>
		[JsonProperty]
		public string FileId { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string VoucherDescription { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string VoucherNumber { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string VoucherSeries { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string VoucherYear { get; set; }

        /// <remarks/>
		[JsonProperty]
		public string url { get; set; }
    }
}
