using System;
using System.Collections.Generic;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
    [Serializable]
    public class Accounts
	{
        /// <remarks/>
		public List<AccountSubset> AccountSubset { get; set; }

        /// <remarks/>
		public string TotalResources { get; set; }

        /// <remarks/>
		public string TotalPages { get; set; }

        /// <remarks/>
		public string CurrentPage { get; set; }
    }

	/// <remarks/>
    [Serializable]
	public class AccountSubset
	{
        /// <remarks/>
		public string Active { get; set; }

        /// <remarks/>
        public string Description { get; set; }

        /// <remarks/>
        public string Number { get; set; }

        /// <remarks/>
        public string SRU { get; set; }

        /// <remarks/>
        public string Year { get; set; }

        /// <remarks/>
		public string url { get; set; }
    }
}
