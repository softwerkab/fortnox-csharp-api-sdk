using System;
using System.Collections.Generic;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>

	
	
	[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
	public class Projects
	{
        /// <remarks/>
		[JsonProperty]
		public List<ProjectSubset> ProjectSubset { get; set; }

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
