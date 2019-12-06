using System;
using System.Collections.Generic;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
	public class Orders
	{
        /// <remarks/>
		public List<OrderSubset> OrderSubset { get; set; }

        /// <remarks/>
		public string TotalResources { get; set; }

        /// <remarks/>
		public string TotalPages { get; set; }

        /// <remarks/>
		public string CurrentPage { get; set; }
    }

	/// <remarks/>
	public class OrderSubset
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
        public string DeliveryDate { get; set; }

        /// <remarks/>
        public string DocumentNumber { get; set; }

        /// <remarks/>
        public string ExternalInvoiceReference1 { get; set; }

        /// <remarks/>
        public string ExternalInvoiceReference2 { get; set; }

        /// <remarks/>
        public string OrderDate { get; set; }

        /// <remarks/>
        public string Project { get; set; }

        /// <remarks/>
        public string Sent { get; set; }

        /// <remarks/>
        public string Total { get; set; }

        /// <remarks/>
		public string url { get; set; }
    }
}
