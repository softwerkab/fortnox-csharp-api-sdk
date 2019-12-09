using System;
using System.ComponentModel;
using FortnoxAPILibrary.Connectors;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
	[Entity(SingularName = "Project", PluralName = "Projects")]
	public class Project : ProjectSubset
	{
        /// <remarks/>
		[JsonProperty]
		public string Comments { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string ContactPerson { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Description { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string EndDate { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string ProjectLeader { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string ProjectNumber { get; set; }

        /// <remarks/>
        [JsonProperty]
        public ProjectConnector.Status Status { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string StartDate { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty(PropertyName = "@url")]
		public string Url { get; private set; }
    }

    /// <remarks/>
    [Entity(SingularName = "Project", PluralName = "Projects")]
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
