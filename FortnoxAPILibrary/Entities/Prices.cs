using System;
using System.Collections.Generic;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>

	
	
	public class Prices
	{
        /// <remarks/>
		public List<PriceSubset> PriceSubset { get; set; }

        /// <remarks/>
		public string TotalResources { get; set; }

        /// <remarks/>
		public string TotalPages { get; set; }

        /// <remarks/>
		public string CurrentPage { get; set; }
    }

	/// <remarks/>
	
	
	
	public class PriceSubset
	{
        /// <remarks/>
		public string ArticleNumber { get; set; }

        /// <remarks/>
        public string FromQuantity { get; set; }

        /// <remarks/>
        public string PriceList { get; set; }

        /// <remarks/>
        public string Price { get; set; }

        /// <remarks/>
		public string url { get; set; }
    }
}
