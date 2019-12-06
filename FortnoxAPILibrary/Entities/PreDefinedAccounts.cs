using System;
using System.Collections.Generic;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
	public class PreDefinedAccounts
	{
        /// <remarks/>
		public List<PreDefinedAccountSubset> PreDefinedAccountSubset { get; set; }

        /// <remarks/>
		public string TotalResources { get; set; }

        /// <remarks/>
		public string TotalPages { get; set; }

        /// <remarks/>
		public string CurrentPage { get; set; }
    }

	/// <remarks/>
	
	
	
	public class PreDefinedAccountSubset
	{
        /// <remarks/>
		public string Account { get; set; }

        /// <remarks/>
        public string Name { get; set; }

        /// <remarks/>
		public string url { get; set; }
    }
}
