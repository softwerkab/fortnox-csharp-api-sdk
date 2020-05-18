
// ReSharper disable UnusedMember.Global

using System.Runtime.Serialization;

namespace FortnoxAPILibrary
{
    /// <remarks/>
    public class Filter
	{
		/// <remarks/>
		public enum Contract
		{
			/// <remarks/>
			[EnumMember(Value = "active")]
			Active,
			/// <remarks/>
			[EnumMember(Value = "inactive")]
			Inactive,
			/// <remarks/>
			[EnumMember(Value = "finished")]
			Finished
		}

		/// <remarks/>
		public enum Invoice
		{
			/// <remarks/>
			[EnumMember(Value = "fullypaid")]
			FullyPaid,
			/// <remarks/>
			[EnumMember(Value = "cancelled")]
			Cancelled,
			/// <remarks/>
			[EnumMember(Value = "unpaid")]
			Unpaid,
			/// <remarks/>
			[EnumMember(Value = "unpaidoverdue")]
			UnpaidOverdue,
			/// <remarks/>
			[EnumMember(Value = "unbooked")]
			Unbooked
		}

		/// <remarks/>
		public enum SupplierInvoice
		{
			/// <remarks/>
			[EnumMember(Value = "fullypaid")]
			FullyPaid,
			/// <remarks/>
			[EnumMember(Value = "cancelled")]
			Cancelled,
			/// <remarks/>
			[EnumMember(Value = "unpaid")]
			Unpaid,
			/// <remarks/>
			[EnumMember(Value = "unpaidoverdue")]
			UnpaidOverdue,
			/// <remarks/>
			[EnumMember(Value = "unbooked")]
			Unbooked,
			/// <remarks/>
			[EnumMember(Value = "pendingpayment")]
			PendingPayment,
			/// <remarks/>
			[EnumMember(Value = "authorizepending")]
			AuthorizePending
		}

		/// <remarks/>
		public enum Offer
		{
			/// <remarks/>
			[EnumMember(Value = "cancelled")]
			Cancelled,
			/// <remarks/>
			[EnumMember(Value = "expired")]
			Expired,
			/// <remarks/>
			[EnumMember(Value = "ordercreated")]
			OrderCreated,
			/// <remarks/>
			[EnumMember(Value = "ordernotcreated")]
			OrderNotCreated
		}

		/// <remarks/>
		public enum Order
		{
			/// <remarks/>
			[EnumMember(Value = "cancelled")]
			Cancelled,
			/// <remarks/>
			[EnumMember(Value = "expired")]
			Expired,
			/// <remarks/>
			[EnumMember(Value = "invoicecreated")]
			InvoiceCreated,
			/// <remarks/>
			[EnumMember(Value = "invoicenotcreated")]
			InvoiceNotCreated
		}

		/// <remarks/>
		public enum TaxReduction
		{
			/// <remarks/>
			[EnumMember(Value = "invoices")]
			Invoices,
			/// <remarks/>
			[EnumMember(Value = "offers")]
			Offers,
			/// <remarks/>
			[EnumMember(Value = "orders")]
			Orders
		}

		/// <remarks/>
		public enum Customer
		{
			/// <remarks/>
			[EnumMember(Value = "active")]
			Active,
			/// <remarks/>
			[EnumMember(Value = "inactive")]
			Inactive
		}

		/// <remarks/>
		public enum Article
		{
			/// <remarks/>
			[EnumMember(Value = "active")]
			Active,
			/// <remarks/>
			[EnumMember(Value = "inactive")]
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
		public enum Archive
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
			/// <summary> Retrieves all active assets </summary>
			[EnumMember(Value = "active")]
			Active,
			/// <summary>Retrieves all inactive assets </summary>
			[EnumMember(Value = "inactive")]
			Inactive,
			/// <summary> Retrieves all fully depreciated assets </summary>
			[EnumMember(Value = "fully_depreciated")]
			FullyDepreciated,
			/// <summary> Retrieves all sold assets </summary>
			[EnumMember(Value = "sold")]
			Sold,    
			/// <summary> Retrieves all scrapped assets </summary>
			[EnumMember(Value = "scrapped")]
			Scrapped,
			/// <summary> Retrieves all voided assets </summary>
			[EnumMember(Value = "voided")]
			Voided
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
            [EnumMember(Value = "active")]
			Active,
            [EnumMember(Value = "inactive")]
			Inactive
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
            [EnumMember(Value = "order")]
            Order,
            [EnumMember(Value = "offer")]
            Offer,
            [EnumMember(Value = "invoice")]
            Invoice
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
