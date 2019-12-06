using System;
using System.Collections.Generic;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>

	
	
	public class TaxReductions
	{
        /// <remarks/>
		public List<TaxReductionSubset> TaxReductionSubset { get; set; }

        /// <remarks/>
		public string TotalResources { get; set; }

        /// <remarks/>
		public string TotalPages { get; set; }

        /// <remarks/>
		public string CurrentPage { get; set; }
    }

	/// <remarks/>
	
	
	
	public class TaxReductionSubset
	{
        /// <remarks/>
		public string ApprovedAmount { get; set; }

        /// <remarks/>
        public string CustomerName { get; set; }

        /// <remarks/>
        public string Id { get; set; }

        /// <remarks/>
        public string ReferenceDocumentType { get; set; }

        /// <remarks/>
        public string ReferenceNumber { get; set; }

        /// <remarks/>
        public string SocialSecurityNumber { get; set; }

        /// <remarks/>
		public string url { get; set; }
    }
}
