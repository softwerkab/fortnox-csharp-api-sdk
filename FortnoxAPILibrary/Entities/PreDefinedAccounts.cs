using System;
using System.Collections.Generic;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
	[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
	public class PreDefinedAccounts : BaseEntityCollection
	{
        /// <remarks/>
		[JsonProperty(PropertyName="PreDefinedAccounts")]
		public List<PreDefinedAccountSubset> PreDefinedAccountSubset { get; set; }



    }

	/// <remarks/>
	
	
	
	[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
	public class PreDefinedAccountSubset
	{
        /// <remarks/>
		[JsonProperty]
		public string Account { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Name { get; set; }

        /// <remarks/>
		[JsonProperty(PropertyName = "@url")]
		public string Url { get; set; }
    }
}
