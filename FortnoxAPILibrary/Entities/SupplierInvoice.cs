using System;
using System.Collections.Generic;
using System.ComponentModel;
using FortnoxAPILibrary.Connectors;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
    public class SupplierInvoice
    {
		/// <remarks/>
		public SupplierInvoice()
        {
            SupplierInvoiceRows = new List<SupplierInvoiceRow>();
        }

		/// <summary>This field is Read-Only in Fortnox</summary>
		public string AccountingMethod { get; private set; }

        /// <remarks/>
        public string AdministrationFee { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        public string Balance { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        public string Booked { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        public string Cancelled { get; private set; }

        /// <remarks/>
        public string Comments { get; set; }

        /// <remarks/>
        public string CostCenter { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        public string Credit { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        public string CreditReference { get; private set; }

        /// <remarks/>
        public string Currency { get; set; }

        /// <remarks/>
        public string CurrencyRate { get; set; }

        /// <remarks/>
        public string CurrencyUnit { get; set; }

        /// <remarks/>
        public string DisablePaymentFile { get; set; }

        /// <remarks/>
        public string DueDate { get; set; }

        /// <remarks/>
        public string ExternalInvoiceNumber { get; set; }

        /// <remarks/>
        public string ExternalInvoiceSeries { get; set; }

        /// <remarks/>
        public string Freight { get; set; }

        /// <remarks/>
        public string VoucherSeries { get; set; }

        /// <remarks/>
        public string VoucherNumber { get; set; }

        /// <remarks/>
        public string VoucherYear { get; set; }

        /// <remarks/>
        public string GivenNumber { get; set; }

        /// <remarks/>
        public string InvoiceDate { get; set; }

        /// <remarks/>
        public string InvoiceNumber { get; set; }

        /// <remarks/>
        public string OCR { get; set; }

        /// <remarks/>
        public string OurReference { get; set; }

        /// <remarks/>
        public string PaymentPending { get; set; }

        /// <remarks/>
        public string Project { get; set; }

        /// <remarks/>
        public string RoundOffValue { get; set; }

        /// <remarks/>
        public SupplierInvoiceConnector.SalesType SalesType { get; set; }

        /// <remarks/>
        public string SupplierNumber { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        public string SupplierName { get; private set; }

        /// <remarks/>
        public string Total { get; set; }

        /// <remarks/>
        public string VAT { get; set; }

        /// <remarks/>
        public SupplierInvoiceConnector.VATType VATType { get; set; }

        /// <remarks/>
        public List<SupplierInvoiceRow> SupplierInvoiceRows { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        public string url { get; private set; }

        /// <remarks/>
        public string YourReference { get; set; }
    }

    /// <remarks/>
    public class SupplierInvoiceRow
    {
        /// <remarks/>
        public string Account { get; set; }

        /// <remarks/>
        public string ArticleNumber { get; set; }

        /// <remarks/>
        public string Code { get; set; }

        /// <remarks/>
        public string CostCenter { get; set; }

        /// <remarks/>
        public string Project { get; set; }

        /// <remarks/>
        public string TransactionInformation { get; set; }

        /// <remarks/>
        public string ItemDescription { get; set; }

        /// <remarks />
        public string AccountDescription { get; set; }

        /// <remarks/>
        public string Price { get; set; }

        /// <remarks/>
        public string Quantity { get; set; }

        /// <remarks/>
        public string Total { get; set; }

        /// <remarks/>
        public string Credit { get; set; }

        /// <remarks/>
        public string Debit { get; set; }

        /// <remarks/>
        public string CreditCurrency { get; set; }

        /// <remarks/>
        public string DebitCurrency { get; set; }
        /// <remarks/>
        public string Unit { get; set; }
    }
}
