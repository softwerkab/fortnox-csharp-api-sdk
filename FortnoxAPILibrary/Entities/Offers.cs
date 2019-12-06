using System;
using System.Collections.Generic;
using System.ComponentModel;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
    [Serializable]
	public class Offers
	{
		/// <remarks/>
		public List<OfferSubset> OfferSubset { get; set; }

        /// <remarks/>
		public string TotalResources { get; set; }

        /// <remarks/>
		public string TotalPages { get; set; }

        /// <remarks/>
		public string CurrentPage { get; set; }
    }

	/// <remarks/>
    [Serializable]
	public class OfferSubset
	{
        /// <remarks/>
		public string Cancelled { get; set; }

        /// <remarks/>
        public string Currency { get; set; }

        /// <remarks/>
        public string CustomerName { get; set; }

        /// <remarks/>
        public string CustomerNumber { get; set; }

        /// <remarks/>
        public string DocumentNumber { get; set; }

        /// <remarks/>
        public string OfferDate { get; set; }

        /// <remarks/>
        public string Project { get; set; }

        /// <remarks/>
        public string Sent { get; set; }

        /// <remarks/>
        public string Total { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
		public string url { get; set; }
    }
}
