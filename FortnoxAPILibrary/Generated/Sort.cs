
// ReSharper disable UnusedMember.Global

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
				[StringValue("number")]
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
				[StringValue("articlenumber")]
				ArticleNumber,
				[StringValue("quantityinstock")]
				QuantityInStock,
				[StringValue("reservedquantity")]
				ReservedQuantity,
				[StringValue("stockvalue")]
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
				[StringValue("customername")]
				CustomerName,
				[StringValue("customernumber")]
				CustomerNumber,
				[StringValue("documentnumber")]
				DocumentNumber,
				[StringValue("invoicesremaining")]
				InvoicesRemaining,
				[StringValue("lastinvoicedate")]
				LastInvoiceDate,
				[StringValue("periodend")]
				PeriodEnd,
				[StringValue("periodstart")]
				PeriodStart,
				[StringValue("templatenumber")]
				TemplateNumber,
				[StringValue("total")]
				Total,
			}
			public enum CostCenter
			{
				[StringValue("code")]
				Code,
			}
			public enum Currency
			{
			}
			public enum Customer
			{
				[StringValue("customernumber")]
				CustomerNumber,
				[StringValue("name")]
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
				[StringValue("id")]
				Id,
				[StringValue("fromdate")]
				FromDate,
				[StringValue("todate")]
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
				[StringValue("customername")]
				CustomerName,
				[StringValue("customernumber")]
				CustomerNumber,
				[StringValue("documentnumber")]
				DocumentNumber,
				[StringValue("invoicedate")]
				InvoiceDate,
				[StringValue("ocr")]
				OCR,
				[StringValue("total")]
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
				[StringValue("code")]
				Code,
			}
			public enum NoxFinansInvoice
			{
			}
			public enum Offer
			{
				[StringValue("customername")]
				CustomerName,
				[StringValue("customernumber")]
				CustomerNumber,
				[StringValue("documentnumber")]
				DocumentNumber,
				[StringValue("offerdate")]
				OfferDate,
			}
			public enum Order
			{
				[StringValue("customername")]
				CustomerName,
				[StringValue("customernumber")]
				CustomerNumber,
				[StringValue("documentnumber")]
				DocumentNumber,
				[StringValue("orderdate")]
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
				[StringValue("code")]
				Code,
				[StringValue("comments")]
				Comments,
			}
			public enum Price
			{
				[StringValue("articlenumber")]
				ArticleNumber,
				[StringValue("pricelist")]
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
				[StringValue("name")]
				Name,
				[StringValue("suppliernumber")]
				SupplierNumber,
			}
			public enum TaxReduction
			{
				[StringValue("customername")]
				CustomerName,
				[StringValue("id")]
				Id,
			}
			public enum TermsOfDelivery
			{
				[StringValue("code")]
				Code,
			}
			public enum TermsOfPayment
			{
				[StringValue("code")]
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
				[StringValue("code")]
				Code,
			}
			public enum VoucherFileConnection
			{
			}
			public enum VoucherSeries
			{
				[StringValue("code")]
				Code,
			}
			public enum Voucher
			{
				[StringValue("referencenumber")]
				ReferenceNumber,
				[StringValue("vouchernumber")]
				VoucherNumber,
				[StringValue("voucherseries")]
				VoucherSeries,
			}
			public enum WayOfDelivery
			{
				[StringValue("code")]
				Code,
			}
		}

		public enum Order
		{
            [StringValue("ascending")]
            Ascending,
            [StringValue("descending")]
            Descending
		}
	}
}
