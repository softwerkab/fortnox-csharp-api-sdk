// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary
{
	/// <remarks/>
	public class Sort
	{
		/// <remarks/>
		public class By
		{

			/// <remarks/>
			public enum Account
			{
				/// <remarks/>
				[StringValue("number")]
				AccountNumber
			}

			/// <remarks/>
			public enum AccountChart
			{
			}

			/// <remarks/>
			public enum Article
			{
				/// <remarks/>
				[StringValue("articlenumber")]
				ArticleNumber,
				/// <remarks/>
				[StringValue("quantityinstock")]
				QuantityInStock,
				/// <remarks/>
				[StringValue("reservedquantity")]
				ReservedQuantity,
				/// <remarks/>
				[StringValue("stockvalue")]
				StockValue
			}

			/// <remarks/>
			public enum ArticleFileConnection
			{

			}

            /// <remarks/>
            public enum CompanySettings
            {
            }

            /// <remarks/>
            public enum Contract
            {
                /// <remarks/>
                [StringValue("documentnumber")]
                DocumentNumber,
                /// <remarks/>
                [StringValue("customernumber")]
                CustomerNumber,
                /// <remarks/>
                [StringValue("customername")]
                CustomerName,
                /// <remarks/>
                [StringValue("templatenumber")]
                TemplateNumber,
                /// <remarks/>
                [StringValue("contractlength")]
                ContractLength,
                /// <remarks/>
                [StringValue("invoiceinterval")]
                InvoiceInterval,
                /// <remarks/>
                [StringValue("lastinvoicedate")]
                LastInvoiceDate,
                /// <remarks/>
                [StringValue("invoicesremaining")]
                InvoicesRemaining,
                /// <remarks/>
                [StringValue("periodstart")]
                PeriodStart,
                /// <remarks/>
                [StringValue("periodend")]
                PeriodEnd,
                /// <remarks/>
                [StringValue("total")]
                Total
            }

			/// <remarks/>
			public enum CostCenter
			{
				/// <remarks/>
				[StringValue("code")]
				Code
			}

			/// <remarks/>
			public enum Currency
			{
				/// <remarks/>
				[StringValue("code")]
				Code
			}

			/// <remarks/>
			public enum Customer
			{
				/// <remarks/>
				[StringValue("customernumber")]
				CustomerNumber,
				/// <remarks/>
				[StringValue("name")]
				Name

			}

			/// <remarks/>
			public enum FinancialYear
			{
				/// <remarks/>
				[StringValue("id")]
				Id,
				/// <remarks/>
				[StringValue("fromdate")]
				FromDate,
				/// <remarks/>
				[StringValue("todate")]
				ToDate
			}

			/// <remarks/>
			public enum Folder
			{
				/// <remarks/>
				[StringValue("id")]
				Id,
				/// <remarks/>
				[StringValue("email")]
				Email,
				/// <remarks/>
				[StringValue("name")]
				Name
			}

			/// <remarks/>
			public enum Invoice
			{
				/// <remarks/>
				[StringValue("customername")]
				CustomerName,
				/// <remarks/>
				[StringValue("customernumber")]
				CustomerNumber,
				/// <remarks/>
				[StringValue("documentnumber")]
				DocumentNumber,
				/// <remarks/>
				[StringValue("invoicedate")]
				InvoiceDate,
				/// <remarks/>
				[StringValue("ocr")]
				OCR,
				/// <remarks/>
				[StringValue("total")]
				Total

			}

			/// <remarks/>
			public enum InvoiceAccrual
			{

			}

            /// <remarks/>
            public enum ContractAccrual
            {

            }

			/// <remarks/>
			public enum InvoicePayment
			{

			}

            /// <remarks/>
            public enum Label {
                /// <remarks/>
                [StringValue("id")]
                Id,
                /// <remarks/>
                [StringValue("description")]
                Description
            }

            /// <remarks/>
            public enum LockedPeriod
            {

            }

			/// <remarks/>
			public enum ModesOfPayment
			{
				/// <remarks/>
				[StringValue("code")]
				Code
			}

			/// <remarks/>
			public enum Offer
			{
				/// <remarks/>
				[StringValue("customername")]
				CustomerName,
				/// <remarks/>
				[StringValue("customernumber")]
				CustomerNumber,
				/// <remarks/>
				[StringValue("documentnumber")]
				DocumentNumber,
				/// <remarks/>
				[StringValue("offerdate")]
				OfferDate,
				/// <remarks/>
				[StringValue("total")]
				Total
			}

			/// <remarks/>
			public enum Order
			{
				/// <remarks/>
				[StringValue("customername")]
				CustomerName,
				/// <remarks/>
				[StringValue("customernumber")]
				CustomerNumber,
				/// <remarks/>
				[StringValue("documentnumber")]
				DocumentNumber,
				/// <remarks/>
				[StringValue("orderdate")]
				OrderDate,
				/// <remarks/>
				[StringValue("total")]
				Total
			}


			/// <remarks/>
			public enum PreDefinedAccount
			{

			}

			/// <remarks/>
			public enum PreDefinedVoucherSeries
			{

			}

			/// <remarks/>
			public enum Price
			{
				/// <remarks/>
				[StringValue("articlenumber")]
				ArticleNumber,
				/// <remarks/>
				[StringValue("pricelist")]
				PriceList
			}

			/// <remarks/>
			public enum PriceList
			{
				/// <remarks/>
				[StringValue("code")]
				Code
			}

			/// <remarks/>
			public enum PrintTemplate
			{

			}

			/// <remarks/>
			public enum Project
			{
				/// <remarks/>
				[StringValue("id")]
				Id,
				/// <remarks/>
				[StringValue("description")]
				Description
			}
			
			/// <remarks/>
			public enum Sie
			{

			}

			/// <remarks/>
			public enum Supplier
			{
				/// <remarks/>
				[StringValue("name")]
				Name,
				/// <remarks/>
				[StringValue("suppliernumber")]
				SupplierNumber
			}

			/// <remarks/>
			public enum SupplierInvoice
			{
				/// <remarks/>
				[StringValue("name")]
				SupplierName,
				/// <remarks/>
				[StringValue("suppliernumber")]
				SupplierNumber
			}

			/// <remarks/>
			public enum SupplierInvoiceAccrual
			{

			}

			/// <remarks/>
			public enum SupplierInvoiceFileConnection
			{

			}

            /// <remarks/>
            public enum SupplierInvoiceURLConnection
            {

            }

            /// <remarks/>
            public enum SupplierInvoiceExternalURLConnection
            {

            }

			/// <remarks/>
			public enum SupplierInvoicePayment
			{

			}

			/// <remarks/>
			public enum TaxReduction
			{
				/// <remarks/>
				[StringValue("id")]
				Id,
				/// <remarks/>
				[StringValue("customername")]
				CustomerName,
				/// <remarks/>
				[StringValue("invoicereferencenumber")]
				InvoiceReferenceNumber
			}

			/// <remarks/>
			public enum TermsOfPayment
			{
				/// <remarks/>
				[StringValue("code")]
				Code
			}

          /// <remarks/>
			public enum TermsOfDelivery
			{
				/// <remarks/>
				[StringValue("code")]
				Code
			}

			/// <remarks/>
			public enum Unit
			{
				/// <remarks/>
				[StringValue("code")]
				Code
			}

			/// <remarks/>
			public enum Voucher
			{
				/// <remarks/>
				[StringValue("referencenumber")]
				ReferenceNumber,
				/// <remarks/>
				[StringValue("referencetype")]
				ReferenceYype,
				/// <remarks/>
				[StringValue("vouchernumber")]
				VoucherNumber,
				/// <remarks/>
				[StringValue("voucherseries")]
				VoucherSeries

			}

			/// <remarks/>
			public enum VoucherFileConnection
			{

			}

			/// <remarks/>
			public enum VoucherSeries
			{
				/// <remarks/>
				[StringValue("code")]
				Code
			}

			/// <remarks/>
			public enum WayOfDelivery
			{
				/// <remarks/>
				[StringValue("code")]
				Code
			}

		}

		/// <remarks/>
		public enum Order
		{
            /// <remarks/>
            [StringValue("ascending")]
            Ascending,
            /// <remarks/>
            [StringValue("descending")]
            Descending
		}
	}
}
