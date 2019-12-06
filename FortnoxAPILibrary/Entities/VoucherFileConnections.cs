using System;
using System.Collections.Generic;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>

	
	
	[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
	public class VoucherFileConnections : BaseEntityCollection
	{
		/// <remarks/>
		[JsonProperty(PropertyName="VoucherFileConnections")]
		public List<VoucherFileConnectionSubset> VoucherFileConnectionSubset { get; set; }



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
		[JsonProperty(PropertyName = "@url")]
		public string Url { get; set; }
    }
}
