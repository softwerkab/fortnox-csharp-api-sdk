using System;
using System.Collections.Generic;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
	[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
	public class Customers : BaseEntityCollection
	{
        /// <remarks/>
		[JsonProperty(PropertyName="Customers")]
		public List<CustomerSubset> CustomerSubset { get; set; }



    }

	/// <remarks/>
	
	[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
	public class CustomerSubset
	{
		/// <remarks/>
        [JsonProperty]
        public string Address1 { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Address2 { get; set; }

		/// <remarks/>
		[JsonProperty]
		public string City { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string CustomerNumber { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Email { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Name { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string OrganisationNumber { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Phone { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string ZipCode { get; set; }

        /// <remarks/>
		[JsonProperty]
		public string url { get; set; }
    }
}
