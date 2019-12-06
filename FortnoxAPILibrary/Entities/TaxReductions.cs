using System;
using System.Collections.Generic;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>

	
	
	[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
	public class TaxReductions : BaseEntityCollection
	{
        /// <remarks/>
		[JsonProperty(PropertyName="TaxReductions")]
		public List<TaxReductionSubset> TaxReductionSubset { get; set; }



    }

	/// <remarks/>
	
	
	
	[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
	public class TaxReductionSubset
	{
        /// <remarks/>
		[JsonProperty]
		public string ApprovedAmount { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string CustomerName { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Id { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string ReferenceDocumentType { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string ReferenceNumber { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string SocialSecurityNumber { get; set; }

        /// <remarks/>
		[JsonProperty(PropertyName = "@url")]
		public string Url { get; set; }
    }
}
