using System;
using System.Collections.Generic;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>

    [Serializable]
	
	
	public class VoucherFileConnections
	{
		/// <remarks/>
		public List<VoucherFileConnectionSubset> VoucherFileConnectionSubset { get; set; }

        /// <remarks/>
		public string TotalResources { get; set; }

        /// <remarks/>
		public string TotalPages { get; set; }

        /// <remarks/>
		public string CurrentPage { get; set; }
    }

	/// <remarks/>
	
	[Serializable]
	
	
	public class VoucherFileConnectionSubset
	{
		/// <remarks/>
		public string FileId { get; set; }

        /// <remarks/>
        public string VoucherDescription { get; set; }

        /// <remarks/>
        public string VoucherNumber { get; set; }

        /// <remarks/>
        public string VoucherSeries { get; set; }

        /// <remarks/>
        public string VoucherYear { get; set; }

        /// <remarks/>
		public string url { get; set; }
    }
}
