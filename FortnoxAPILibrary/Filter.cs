namespace FortnoxAPILibrary
{
	/// <remarks/>
	public class Filter
    {
        /// <remarks/>
        public enum Contract
        {
            /// <remarks/>
            [RealValue("active")]
            Active,
            /// <remarks/>
            [RealValue("inactive")]
            Inactive,
            /// <remarks/>
            [RealValue("finished")]
            Finished
        }

		/// <remarks/>
		public enum Invoice
		{
			/// <remarks/>
			[RealValue("fullypaid")]
			FullyPaid,
			/// <remarks/>
			[RealValue("cancelled")]
			Cancelled,
			/// <remarks/>
			[RealValue("unpaid")]
			Unpaid,
			/// <remarks/>
			[RealValue("unpaidoverdue")]
			UnpaidOverdue,
			/// <remarks/>
			[RealValue("unbooked")]
			Unbooked,
		}

        /// <remarks/>
        public enum SupplierInvoice
        {
            /// <remarks/>
            [RealValue("fullypaid")]
            FullyPaid,
            /// <remarks/>
            [RealValue("cancelled")]
            Cancelled,
            /// <remarks/>
            [RealValue("unpaid")]
            Unpaid,
            /// <remarks/>
            [RealValue("unpaidoverdue")]
            UnpaidOverdue,
            /// <remarks/>
            [RealValue("unbooked")]
            Unbooked,
			/// <remarks/>
			[RealValue("pendingpayment")]
			PendingPayment,
			/// <remarks/>
			[RealValue("authorizepending")]
			AuthorizePending,
		}

		/// <remarks/>
		public enum Offer
		{
			/// <remarks/>
			[RealValue("cancelled")]
			Cancelled,
			/// <remarks/>
			[RealValue("expired")]
			Expired,
			/// <remarks/>
			[RealValue("ordercreated")]
			OrderCreated,
			/// <remarks/>
			[RealValue("ordernotcreated")]
			OrderNotCreated
		}

		/// <remarks/>
		public enum Order
		{
			/// <remarks/>
			[RealValue("cancelled")]
			Cancelled,
			/// <remarks/>
			[RealValue("expired")]
			Expired,
			/// <remarks/>
			[RealValue("invoicecreated")]
			InvoiceCreated,
			/// <remarks/>
			[RealValue("invoicenotcreated")]
			InvoiceNotCreated,
		}

		/// <remarks/>
		public enum TaxReduction
		{
			/// <remarks/>
			[RealValue("invoices")]
			Invoices,
			/// <remarks/>
			[RealValue("offers")]
			Offers,
			/// <remarks/>
			[RealValue("orders")]
			Orders
		}

		/// <remarks/>
		public enum Customer
		{
			/// <remarks/>
			[RealValue("active")]
			Active,
			/// <remarks/>
			[RealValue("inactive")]
			Inactive,
		}
	}
}
