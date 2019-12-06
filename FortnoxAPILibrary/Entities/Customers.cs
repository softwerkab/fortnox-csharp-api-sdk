using System;
using System.Collections.Generic;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
    [Serializable]
	public class Customers
	{
        /// <remarks/>
		public List<CustomerSubset> CustomerSubset { get; set; }

        /// <remarks/>
		public string TotalResources { get; set; }

        /// <remarks/>
		public string TotalPages { get; set; }

        /// <remarks/>
		public string CurrentPage { get; set; }
    }

	/// <remarks/>
	
	[Serializable]
	public class CustomerSubset
	{
		/// <remarks/>
        public string Address1 { get; set; }

        /// <remarks/>
        public string Address2 { get; set; }

		/// <remarks/>
		public string City { get; set; }

        /// <remarks/>
        public string CustomerNumber { get; set; }

        /// <remarks/>
        public string Email { get; set; }

        /// <remarks/>
        public string Name { get; set; }

        /// <remarks/>
        public string OrganisationNumber { get; set; }

        /// <remarks/>
        public string Phone { get; set; }

        /// <remarks/>
        public string ZipCode { get; set; }

        /// <remarks/>
		public string url { get; set; }
    }
}
