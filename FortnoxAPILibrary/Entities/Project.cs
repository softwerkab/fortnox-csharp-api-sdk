using System;
using System.ComponentModel;
using FortnoxAPILibrary.Connectors;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>

    [Serializable]
	
	
	public class Project
	{
        /// <remarks/>
		public string Comments { get; set; }

        /// <remarks/>
        public string ContactPerson { get; set; }

        /// <remarks/>
        public string Description { get; set; }

        /// <remarks/>
        public string EndDate { get; set; }

        /// <remarks/>
        public string ProjectLeader { get; set; }

        /// <remarks/>
        public string ProjectNumber { get; set; }

        /// <remarks/>
        public ProjectConnector.Status Status { get; set; }

        /// <remarks/>
        public string StartDate { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
		public string url { get; set; }
    }
}
