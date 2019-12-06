using System;
using System.Collections.Generic;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>

	
	
	[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
	public class Projects : BaseEntityCollection
	{
        /// <remarks/>
		[JsonProperty(PropertyName="Projects")]
		public List<ProjectSubset> ProjectSubset { get; set; }



    }

	/// <remarks/>
	
	
	
	[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
	public class ProjectSubset
	{
        /// <remarks/>
		[JsonProperty]
		public string Description { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string EndDate { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string ProjectNumber { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Status { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string StartDate { get; set; }

        /// <remarks/>
		[JsonProperty(PropertyName = "@url")]
		public string Url { get; set; }
    }
}
