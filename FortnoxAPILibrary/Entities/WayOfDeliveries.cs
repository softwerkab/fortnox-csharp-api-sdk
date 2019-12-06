using System;
using System.Collections.Generic;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>

    [Serializable]
	
	
	public class WayOfDeliveries
	{
		/// <remarks/>
		public List<WayOfDeliverySubset> WayOfDeliverySubset { get; set; }
        /// <remarks/>
		public string TotalResources { get; set; }

        /// <remarks/>
		public string TotalPages { get; set; }

        /// <remarks/>
		public string CurrentPage { get; set; }
    }

	/// <remarks/>
	
	[Serializable]
	
	
	public class WayOfDeliverySubset
	{
        /// <remarks/>
		public string Code { get; set; }

        /// <remarks/>
        public string Description { get; set; }

        /// <remarks/>
		public string url { get; set; }
    }
}
