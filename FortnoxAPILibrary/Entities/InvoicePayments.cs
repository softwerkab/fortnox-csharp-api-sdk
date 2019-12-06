using System;
using System.Collections.Generic;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
	public class InvoicePayments
	{
        /// <remarks/>
		public List<InvoicePaymentSubset> InvoicePaymentSubset { get; set; }

        /// <remarks/>
		public string TotalResources { get; set; }

        /// <remarks/>
		public string TotalPages { get; set; }

        /// <remarks/>
		public string CurrentPage { get; set; }
    }

	/// <remarks/>
	public class InvoicePaymentSubset
	{
        /// <remarks/>
		public string Amount { get; set; }

        /// <remarks/>
        public string Booked { get; set; }

        /// <remarks/>
        public string Currency { get; set; }

        /// <remarks/>
        public string CurrencyRate { get; set; }

        /// <remarks/>
        public string CurrencyUnit { get; set; }

        /// <remarks/>
        public string InvoiceNumber { get; set; }

        /// <remarks/>
        public string Number { get; set; }

        /// <remarks/>
        public string Source { get; set; }

        /// <remarks/>
        public string PaymentDate { get; set; }

		/// <remarks/>
		public string url { get; set; }
    }
}
