using System;
using System.Collections.Generic;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class CostCenters : BaseEntityCollection
	{
		/// <remarks/>
		[JsonProperty(PropertyName="CostCenters")]
		public List<CostCenterSubset> CostCenterSubset { get; set; }



    }

    /// <remarks/>
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class CostCenterSubset
	{
        /// <remarks/>
		[JsonProperty]
		public string Code { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Description { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Note { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Active { get; set; }

        /// <remarks/>
		[JsonProperty(PropertyName = "@url")]
		public string Url { get; set; }
    }
}
