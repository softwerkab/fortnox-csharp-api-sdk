using System;
using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
	[Entity(SingularName = "SupplierInvoicePayment", PluralName = "SupplierInvoicePayments")]
	public class SupplierInvoicePayment 
	{
        /// <remarks/>
		[JsonProperty]
		public string Amount { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string AmountCurrency { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty]
		public string Booked { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty]
		public string Currency { get; private set; }

        /// <remarks/>
        [JsonProperty]
        public string CurrencyRate { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty]
		public string CurrencyUnit { get; private set; }

        /// <remarks/>
        [JsonProperty]
        public string Information { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string InvoiceNumber { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty]
		public string InvoiceDueDate { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty]
		public string InvoiceOCR { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty]
		public string InvoiceSupplierName { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty]
		public string InvoiceSupplierNumber { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty]
		public string InvoiceTotal { get; private set; }

        /// <remarks/>
        [JsonProperty]
        public string ModeOfPayment { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty]
		public string Number { get; private set; }

        /// <remarks/>
        [JsonProperty]
        public string PaymentDate { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty]
		public string Source { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty]
		public string VoucherNumber { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty]
		public string VoucherSeries { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty]
		public string VoucherYear { get; private set; }

        /// <remarks/>
		[JsonProperty]
		public List<SupplierInvoiceWriteOff> WriteOffs { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty(PropertyName = "@url")]
		public string Url { get; private set; }
    }

	/// <remarks/>
	public class SupplierInvoiceWriteOff
	{
        /// <remarks/>
		[JsonProperty]
		public string Amount { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string AccountNumber { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string CostCenter { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty]
		public string Currency { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty]
		public string Description { get; private set; }

        /// <remarks/>
        [JsonProperty]
        public string TransactionInformation { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Project { get; set; }
    }

    /// <remarks/>
    [Entity(SingularName = "SupplierInvoicePayment", PluralName = "SupplierInvoicePayments")]
    public class SupplierInvoicePaymentSubset
    {
        /// <remarks/>
        [JsonProperty]
        public string Amount { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Booked { get; set; }

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
        public string InvoiceNumber { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Number { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Source { get; set; }

        /// <remarks/>
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }
    }
}
