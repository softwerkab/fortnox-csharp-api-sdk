using System;
using System.Collections.Generic;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>

	public class FinancialYears
	{
		/// <remarks/>
		public List<FinancialYearSubset> FinancialYearSubset { get; set; }

        /// <remarks/>
		public string TotalResources { get; set; }

        /// <remarks/>
		public string TotalPages { get; set; }

        /// <remarks/>
		public string CurrentPage { get; set; }
    }

	/// <remarks/>
	public class FinancialYearSubset
	{
        /// <remarks/>
		public string Id { get; set; }

        /// <remarks/>
        public string FromDate { get; set; }

        /// <remarks/>
        public string ToDate { get; set; }

        /// <remarks/>
		public string url { get; set; }
    }
}
