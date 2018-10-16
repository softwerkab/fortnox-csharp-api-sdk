
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
				[RealValue("number")]
				AccountNumber,
			}

			/// <remarks/>
			public enum AccountChart
			{
			}

			/// <remarks/>
			public enum Article
			{
				/// <remarks/>
				[RealValue("articlenumber")]
				ArticleNumber,
				/// <remarks/>
				[RealValue("quantityinstock")]
				QuantityInStock,
				/// <remarks/>
				[RealValue("reservedquantity")]
				ReservedQuantity,
				/// <remarks/>
				[RealValue("stockvalue")]
				StockValue,
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
                [RealValue("documentnumber")]
                DocumentNumber,
                /// <remarks/>
                [RealValue("customernumber")]
                CustomerNumber,
                /// <remarks/>
                [RealValue("customername")]
                CustomerName,
                /// <remarks/>
                [RealValue("templatenumber")]
                TemplateNumber,
                /// <remarks/>
                [RealValue("contractlength")]
                ContractLength,
                /// <remarks/>
                [RealValue("invoiceinterval")]
                InvoiceInterval,
                /// <remarks/>
                [RealValue("lastinvoicedate")]
                LastInvoiceDate,
                /// <remarks/>
                [RealValue("invoicesremaining")]
                InvoicesRemaining,
                /// <remarks/>
                [RealValue("periodstart")]
                PeriodStart,
                /// <remarks/>
                [RealValue("periodend")]
                PeriodEnd,
                /// <remarks/>
                [RealValue("total")]
                Total
            }

			/// <remarks/>
			public enum CostCenter
			{
				/// <remarks/>
				[RealValue("code")]
				Code
			}

			/// <remarks/>
			public enum Currency
			{
				/// <remarks/>
				[RealValue("code")]
				Code
			}

			/// <remarks/>
			public enum Customer
			{
				/// <remarks/>
				[RealValue("customernumber")]
				CustomerNumber,
				/// <remarks/>
				[RealValue("name")]
				Name

		    }

		    /// <remarks/>
		    public enum Employee
		    {
		    }

            /// <remarks/>
            public enum FinancialYear
			{
				/// <remarks/>
				[RealValue("id")]
				Id,
				/// <remarks/>
				[RealValue("fromdate")]
				FromDate,
				/// <remarks/>
				[RealValue("todate")]
				ToDate
			}

			/// <remarks/>
			public enum Folder
			{
				/// <remarks/>
				[RealValue("id")]
				Id,
				/// <remarks/>
				[RealValue("email")]
				Email,
				/// <remarks/>
				[RealValue("name")]
				Name
			}

			/// <remarks/>
			public enum Invoice
			{
				/// <remarks/>
				[RealValue("customername")]
				CustomerName,
				/// <remarks/>
				[RealValue("customernumber")]
				CustomerNumber,
				/// <remarks/>
				[RealValue("documentnumber")]
				DocumentNumber,
				/// <remarks/>
				[RealValue("invoicedate")]
				InvoiceDate,
				/// <remarks/>
				[RealValue("ocr")]
				OCR,
				/// <remarks/>
				[RealValue("total")]
				Total,

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
                [RealValue("id")]
                Id,
                /// <remarks/>
                [RealValue("description")]
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
				[RealValue("code")]
				Code,
			}

			/// <remarks/>
			public enum Offer
			{
				/// <remarks/>
				[RealValue("customername")]
				CustomerName,
				/// <remarks/>
				[RealValue("customernumber")]
				CustomerNumber,
				/// <remarks/>
				[RealValue("documentnumber")]
				DocumentNumber,
				/// <remarks/>
				[RealValue("offerdate")]
				OfferDate,
				/// <remarks/>
				[RealValue("total")]
				Total,
			}

			/// <remarks/>
			public enum Order
			{
				/// <remarks/>
				[RealValue("customername")]
				CustomerName,
				/// <remarks/>
				[RealValue("customernumber")]
				CustomerNumber,
				/// <remarks/>
				[RealValue("documentnumber")]
				DocumentNumber,
				/// <remarks/>
				[RealValue("orderdate")]
				OrderDate,
				/// <remarks/>
				[RealValue("total")]
				Total,
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
				[RealValue("articlenumber")]
				ArticleNumber,
				/// <remarks/>
				[RealValue("pricelist")]
				PriceList
			}

			/// <remarks/>
			public enum PriceList
			{
				/// <remarks/>
				[RealValue("code")]
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
				[RealValue("id")]
				Id,
				/// <remarks/>
				[RealValue("description")]
				Description
			}

			/// <remarks/>
			public enum SalaryTransaction
			{
			}
			
			/// <remarks/>
			public enum Sie
			{

			}

			/// <remarks/>
			public enum Supplier
			{
				/// <remarks/>
				[RealValue("name")]
				Name,
				/// <remarks/>
				[RealValue("suppliernumber")]
				SupplierNumber
			}

			/// <remarks/>
			public enum SupplierInvoice
			{
				/// <remarks/>
				[RealValue("name")]
				SupplierName,
				/// <remarks/>
				[RealValue("suppliernumber")]
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
				[RealValue("id")]
				Id,
				/// <remarks/>
				[RealValue("customername")]
				CustomerName,
				/// <remarks/>
				[RealValue("invoicereferencenumber")]
				InvoiceReferenceNumber
			}

			/// <remarks/>
			public enum TermsOfPayment
			{
				/// <remarks/>
				[RealValue("code")]
				Code
			}

          /// <remarks/>
			public enum TermsOfDelivery
			{
				/// <remarks/>
				[RealValue("code")]
				Code
			}

			/// <remarks/>
			public enum Unit
			{
				/// <remarks/>
				[RealValue("code")]
				Code
			}

			/// <remarks/>
			public enum Voucher
			{
				/// <remarks/>
				[RealValue("referencenumber")]
				ReferenceNumber,
				/// <remarks/>
				[RealValue("referencetype")]
				ReferenceYype,
				/// <remarks/>
				[RealValue("vouchernumber")]
				VoucherNumber,
				/// <remarks/>
				[RealValue("voucherseries")]
				VoucherSeries,

			}

			/// <remarks/>
			public enum VoucherFileConnection
			{

			}

			/// <remarks/>
			public enum VoucherSeries
			{
				/// <remarks/>
				[RealValue("code")]
				Code,
			}

			/// <remarks/>
			public enum WayOfDelivery
			{
				/// <remarks/>
				[RealValue("code")]
				Code
			}

		}

		/// <remarks/>
		public enum Order
		{
			/// <remarks/>
			Ascending,
			/// <remarks/>
			Descending
		}
	}
}
