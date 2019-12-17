// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary
{
	/// <remarks/>
	public class Filter
    {
        /// <remarks/>
        public enum Contract
        {
            /// <remarks/>
            [StringValue("active")]
            Active,
            /// <remarks/>
            [StringValue("inactive")]
            Inactive,
            /// <remarks/>
            [StringValue("finished")]
            Finished
        }

		/// <remarks/>
		public enum Invoice
		{
			/// <remarks/>
			[StringValue("fullypaid")]
			FullyPaid,
			/// <remarks/>
			[StringValue("cancelled")]
			Cancelled,
			/// <remarks/>
			[StringValue("unpaid")]
			Unpaid,
			/// <remarks/>
			[StringValue("unpaidoverdue")]
			UnpaidOverdue,
			/// <remarks/>
			[StringValue("unbooked")]
			Unbooked
		}

        /// <remarks/>
        public enum SupplierInvoice
        {
            /// <remarks/>
            [StringValue("fullypaid")]
            FullyPaid,
            /// <remarks/>
            [StringValue("cancelled")]
            Cancelled,
            /// <remarks/>
            [StringValue("unpaid")]
            Unpaid,
            /// <remarks/>
            [StringValue("unpaidoverdue")]
            UnpaidOverdue,
            /// <remarks/>
            [StringValue("unbooked")]
            Unbooked,
			/// <remarks/>
			[StringValue("pendingpayment")]
			PendingPayment,
			/// <remarks/>
			[StringValue("authorizepending")]
			AuthorizePending
		}

		/// <remarks/>
		public enum Offer
		{
			/// <remarks/>
			[StringValue("cancelled")]
			Cancelled,
			/// <remarks/>
			[StringValue("expired")]
			Expired,
			/// <remarks/>
			[StringValue("ordercreated")]
			OrderCreated,
			/// <remarks/>
			[StringValue("ordernotcreated")]
			OrderNotCreated
		}

		/// <remarks/>
		public enum Order
		{
			/// <remarks/>
			[StringValue("cancelled")]
			Cancelled,
			/// <remarks/>
			[StringValue("expired")]
			Expired,
			/// <remarks/>
			[StringValue("invoicecreated")]
			InvoiceCreated,
			/// <remarks/>
			[StringValue("invoicenotcreated")]
			InvoiceNotCreated
		}

		/// <remarks/>
		public enum TaxReduction
		{
			/// <remarks/>
			[StringValue("invoices")]
			Invoices,
			/// <remarks/>
			[StringValue("offers")]
			Offers,
			/// <remarks/>
			[StringValue("orders")]
			Orders
		}

		/// <remarks/>
		public enum Customer
		{
			/// <remarks/>
			[StringValue("active")]
			Active,
			/// <remarks/>
			[StringValue("inactive")]
			Inactive
		}

		/// <remarks/>
		public enum Article
		{
			/// <remarks/>
			[StringValue("active")]
			Active,
			/// <remarks/>
			[StringValue("inactive")]
			Inactive
		}

	}
}
