using System;
using System.Collections.Generic;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
    [Serializable]
    public class CostCenters
	{
		/// <remarks/>
		public List<CostCenterSubset> CostCenterSubset { get; set; }

        /// <remarks/>
		public string TotalResources { get; set; }

        /// <remarks/>
		public string TotalPages { get; set; }

        /// <remarks/>
		public string CurrentPage { get; set; }
    }

    /// <remarks/>
    [Serializable]
    public class CostCenterSubset
	{
        /// <remarks/>
		public string Code { get; set; }

        /// <remarks/>
        public string Description { get; set; }

        /// <remarks/>
        public string Note { get; set; }

        /// <remarks/>
        public string Active { get; set; }

        /// <remarks/>
		public string url { get; set; }
    }
}
