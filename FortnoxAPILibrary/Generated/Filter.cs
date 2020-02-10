
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

		public enum AbsenceTransaction
		{

		}
		public enum AccountChart
		{

		}
		public enum Account
		{

		}
		public enum File
		{

		}
		public enum ArticleFileConnection
		{

		}

        public enum AssetFileConnection
		{

		}
		public enum AssetTypes
		{

		}
		public enum Asset
		{

		}
		public enum AttendanceTransactions
		{

		}
		public enum CompanyInformation
		{

		}
		public enum CompanySettings
		{

		}
		public enum ContractAccrual
		{

		}
		public enum ContractTemplate
		{

		}
        public enum CostCenter
		{

		}
		public enum Currency
		{

		}
        public enum Employee
		{

		}
		public enum Expense
		{

		}
		public enum FinancialYear
		{

		}
		public enum InvoiceAccrual
		{

		}
		public enum InvoiceFileConnection
		{

		}
		public enum InvoicePayment
		{

		}
        public enum Label
		{

		}
		public enum LockedPeriod
		{

		}
		public enum ModeOfPayment
		{

		}
		public enum NoxFinansInvoice
		{

		}
        public enum PredefinedAccounts
		{

		}
		public enum PredefinedVoucherSeries
		{

		}
		public enum PriceList
		{

		}
		public enum Price
		{

		}
		public enum PrintTemplate
		{

		}
		public enum Project
		{

		}
		public enum SalaryTransaction
		{

		}
		public enum ScheduleTimes
		{

		}
		public enum SupplierInvoiceAccrual
		{

		}
		public enum SupplierInvoiceExternalURLConnection
		{

		}
		public enum SupplierInvoiceFileConnection
		{

		}
		public enum SupplierInvoicePayment
		{

		}
        public enum Supplier
		{

		}
        public enum TermsOfDelivery
		{

		}
		public enum TermsOfPayment
		{

		}
		public enum TrustedEmailDomains
		{

		}
		public enum TrustedEmailSenders
		{

		}
		public enum Unit
		{

		}
		public enum VoucherFileConnection
		{

		}
		public enum VoucherSeries
		{

		}
		public enum Voucher
		{

		}
		public enum WayOfDelivery
		{

		}
	}
}
