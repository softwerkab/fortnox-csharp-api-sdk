using System;
using System.Collections.Generic;
using System.ComponentModel;
using FortnoxAPILibrary.Connectors;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
    [Serializable]
    public class SupplierInvoice
    {
		/// <remarks/>
		public SupplierInvoice()
        {
            SupplierInvoiceRows = new List<SupplierInvoiceRow>();
        }

		/// <summary>This field is Read-Only in Fortnox</summary>
		[ReadOnly(true)]
		public string AccountingMethod { get; set; }

        /// <remarks/>
        public string AdministrationFee { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
        public string Balance { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
        public string Booked { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
        public string Cancelled { get; set; }

        /// <remarks/>
        public string Comments { get; set; }

        /// <remarks/>
        public string CostCenter { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
        public string Credit { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
        public string CreditReference { get; set; }

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
        [ReadOnly(true)]
        public string SupplierName { get; set; }

        /// <remarks/>
        public string Total { get; set; }

        /// <remarks/>
        public string VAT { get; set; }

        /// <remarks/>
        public SupplierInvoiceConnector.VATType VATType { get; set; }

        /// <remarks/>
        public List<SupplierInvoiceRow> SupplierInvoiceRows { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
        public string url { get; set; }

        /// <remarks/>
        public string YourReference { get; set; }
    }

    /// <remarks/>
    [Serializable]
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
