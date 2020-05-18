
// ReSharper disable UnusedMember.Global

using System.Runtime.Serialization;

namespace FortnoxAPILibrary
{
	//TODO: Fix plurals

    /// <remarks/>
    public class Sort
	{
		public class By 
		{
			public enum AbsenceTransaction
			{
			}
			public enum AccountChart
			{
			}
			public enum Account
			{
				[EnumMember(Value = "number")]
				Number,
			}
			public enum Archive
			{
			}
			public enum ArticleFileConnection
			{
			}
			public enum Article
			{
				[EnumMember(Value = "articlenumber")]
				ArticleNumber,
				[EnumMember(Value = "quantityinstock")]
				QuantityInStock,
				[EnumMember(Value = "reservedquantity")]
				ReservedQuantity,
				[EnumMember(Value = "stockvalue")]
				StockValue,
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
			public enum Contract
			{
				[EnumMember(Value = "customername")]
				CustomerName,
				[EnumMember(Value = "customernumber")]
				CustomerNumber,
				[EnumMember(Value = "documentnumber")]
				DocumentNumber,
				[EnumMember(Value = "invoicesremaining")]
				InvoicesRemaining,
				[EnumMember(Value = "lastinvoicedate")]
				LastInvoiceDate,
				[EnumMember(Value = "periodend")]
				PeriodEnd,
				[EnumMember(Value = "periodstart")]
				PeriodStart,
				[EnumMember(Value = "templatenumber")]
				TemplateNumber,
				[EnumMember(Value = "total")]
				Total,
			}
			public enum CostCenter
			{
				[EnumMember(Value = "code")]
				Code,
			}
			public enum Currency
			{
			}
			public enum Customer
			{
				[EnumMember(Value = "customernumber")]
				CustomerNumber,
				[EnumMember(Value = "name")]
				Name,
			}
			public enum Employee
			{
			}
			public enum Expense
			{
			}
			public enum FinancialYear
			{
				[EnumMember(Value = "id")]
				Id,
				[EnumMember(Value = "fromdate")]
				FromDate,
				[EnumMember(Value = "todate")]
				ToDate,
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
			public enum Invoice
			{
				[EnumMember(Value = "customername")]
				CustomerName,
				[EnumMember(Value = "customernumber")]
				CustomerNumber,
				[EnumMember(Value = "documentnumber")]
				DocumentNumber,
				[EnumMember(Value = "invoicedate")]
				InvoiceDate,
				[EnumMember(Value = "ocr")]
				OCR,
				[EnumMember(Value = "total")]
				Total,
			}
			public enum Label
			{
			}
			public enum LockedPeriod
			{
			}
			public enum ModeOfPayment
			{
				[EnumMember(Value = "code")]
				Code,
			}
			public enum NoxFinansInvoice
			{
			}
			public enum Offer
			{
				[EnumMember(Value = "customername")]
				CustomerName,
				[EnumMember(Value = "customernumber")]
				CustomerNumber,
				[EnumMember(Value = "documentnumber")]
				DocumentNumber,
				[EnumMember(Value = "offerdate")]
				OfferDate,
			}
			public enum Order
			{
				[EnumMember(Value = "customername")]
				CustomerName,
				[EnumMember(Value = "customernumber")]
				CustomerNumber,
				[EnumMember(Value = "documentnumber")]
				DocumentNumber,
				[EnumMember(Value = "orderdate")]
				OrderDate,
			}
			public enum PredefinedAccounts
			{
			}
			public enum PredefinedVoucherSeries
			{
			}
			public enum PriceList
			{
				[EnumMember(Value = "code")]
				Code,
				[EnumMember(Value = "comments")]
				Comments,
			}
			public enum Price
			{
				[EnumMember(Value = "articlenumber")]
				ArticleNumber,
				[EnumMember(Value = "pricelist")]
				PriceList,
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
			public enum SupplierInvoice
			{
			}
			public enum Supplier
			{
				[EnumMember(Value = "name")]
				Name,
				[EnumMember(Value = "suppliernumber")]
				SupplierNumber,
			}
			public enum TaxReduction
			{
				[EnumMember(Value = "customername")]
				CustomerName,
				[EnumMember(Value = "id")]
				Id,
			}
			public enum TermsOfDelivery
			{
				[EnumMember(Value = "code")]
				Code,
			}
			public enum TermsOfPayment
			{
				[EnumMember(Value = "code")]
				Code,
			}
			public enum TrustedEmailDomains
			{
			}
			public enum TrustedEmailSenders
			{
			}
			public enum Unit
			{
				[EnumMember(Value = "code")]
				Code,
			}
			public enum VoucherFileConnection
			{
			}
			public enum VoucherSeries
			{
				[EnumMember(Value = "code")]
				Code,
			}
			public enum Voucher
			{
				[EnumMember(Value = "referencenumber")]
				ReferenceNumber,
				[EnumMember(Value = "vouchernumber")]
				VoucherNumber,
				[EnumMember(Value = "voucherseries")]
				VoucherSeries,
			}
			public enum WayOfDelivery
			{
				[EnumMember(Value = "code")]
				Code,
			}
		}

		public enum Order
		{
            [EnumMember(Value = "ascending")]
            Ascending,
            [EnumMember(Value = "descending")]
            Descending
		}
	}
}
