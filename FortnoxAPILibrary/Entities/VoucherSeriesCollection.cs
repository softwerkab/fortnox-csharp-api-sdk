using System;
using System.Collections.Generic;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>

	
	
	public class VoucherSeriesCollection
	{
		/// <remarks/>
		public List<VoucherSeriesSubset> VoucherSeriesSubset { get; set; }

        /// <remarks/>
		public string TotalResources { get; set; }

        /// <remarks/>
		public string TotalPages { get; set; }

        /// <remarks/>
		public string CurrentPage { get; set; }
    }

	/// <remarks/>
	
	
	
	public class VoucherSeriesSubset
	{
        /// <remarks/>
		public string Accrual { get; set; }

        /// <remarks/>
        public string Code { get; set; }

        /// <remarks/>
        public string Description { get; set; }

        /// <remarks/>
        public string Manual { get; set; }

        /// <remarks/>
		public string url { get; set; }
    }
}
