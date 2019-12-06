using System;
using System.Collections.Generic;
using System.ComponentModel;
using FortnoxAPILibrary.Connectors;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class SupplierInvoice
    {
		/// <remarks/>
		public SupplierInvoice()
        {
            SupplierInvoiceRows = new List<SupplierInvoiceRow>();
        }

		/// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty]
		public string AccountingMethod { get; private set; }

        /// <remarks/>
        [JsonProperty]
        public string AdministrationFee { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [JsonProperty]
        public string Balance { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [JsonProperty]
        public string Booked { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [JsonProperty]
        public string Cancelled { get; private set; }

        /// <remarks/>
        [JsonProperty]
        public string Comments { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string CostCenter { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [JsonProperty]
        public string Credit { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [JsonProperty]
        public string CreditReference { get; private set; }

        /// <remarks/>
        [JsonProperty]
        public string Currency { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string CurrencyRate { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string CurrencyUnit { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string DisablePaymentFile { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string DueDate { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string ExternalInvoiceNumber { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string ExternalInvoiceSeries { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Freight { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string VoucherSeries { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string VoucherNumber { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string VoucherYear { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string GivenNumber { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string InvoiceDate { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string InvoiceNumber { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string OCR { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string OurReference { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string PaymentPending { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Project { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string RoundOffValue { get; set; }

        /// <remarks/>
        [JsonProperty]
        public SupplierInvoiceConnector.SalesType SalesType { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string SupplierNumber { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [JsonProperty]
        public string SupplierName { get; private set; }

        /// <remarks/>
        [JsonProperty]
        public string Total { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string VAT { get; set; }

        /// <remarks/>
        [JsonProperty]
        public SupplierInvoiceConnector.VATType VATType { get; set; }

        /// <remarks/>
        [JsonProperty]
        public List<SupplierInvoiceRow> SupplierInvoiceRows { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [JsonProperty]
        public string url { get; private set; }

        /// <remarks/>
        [JsonProperty]
        public string YourReference { get; set; }
    }

    /// <remarks/>
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class SupplierInvoiceRow
    {
        /// <remarks/>
        [JsonProperty]
        public string Account { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string ArticleNumber { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Code { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string CostCenter { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Project { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string TransactionInformation { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string ItemDescription { get; set; }

        /// <remarks />
        [JsonProperty]
        public string AccountDescription { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Price { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Quantity { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Total { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Credit { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Debit { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string CreditCurrency { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string DebitCurrency { get; set; }
        /// <remarks/>
        [JsonProperty]
        public string Unit { get; set; }
    }
}
