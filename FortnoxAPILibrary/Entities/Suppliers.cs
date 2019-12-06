using System;
using System.Collections.Generic;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>

	
	
	[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
	public class Suppliers : BaseEntityCollection
	{
        /// <remarks/>
		[JsonProperty(PropertyName="Suppliers")]
		public List<SupplierSubset> SupplierSubset { get; set; }



    }

	/// <remarks/>
	
	
	
	[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
	public class SupplierSubset
	{

        /// <remarks/>
		[JsonProperty]
		public string City { get; set; }

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
        public string SupplierNumber { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string ZipCode { get; set; }

        /// <remarks/>
		[JsonProperty(PropertyName = "@url")]
		public string Url { get; set; }
    }
}
