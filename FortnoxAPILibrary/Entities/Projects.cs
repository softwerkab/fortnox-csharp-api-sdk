using System;
using System.Collections.Generic;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>

    [Serializable]
	
	
	public class Projects
	{
        /// <remarks/>
		public List<ProjectSubset> ProjectSubset { get; set; }

        /// <remarks/>
		public string TotalResources { get; set; }

        /// <remarks/>
		public string TotalPages { get; set; }

        /// <remarks/>
		public string CurrentPage { get; set; }
    }

	/// <remarks/>
	
	[Serializable]
	
	
	public class ProjectSubset
	{
        /// <remarks/>
		public string Description { get; set; }

        /// <remarks/>
        public string EndDate { get; set; }

        /// <remarks/>
        public string ProjectNumber { get; set; }

        /// <remarks/>
        public string Status { get; set; }

        /// <remarks/>
        public string StartDate { get; set; }

        /// <remarks/>
		public string url { get; set; }
    }
}
