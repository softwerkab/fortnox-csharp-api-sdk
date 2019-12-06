using System;
using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
	[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
	public class InvoicePayment
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

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty]
		public string ExternalInvoiceReference1 { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty]
		public string ExternalInvoiceReference2 { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty]
		public string InvoiceCustomerName { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty]
		public string InvoiceCustomerNumber { get; private set; }

        /// <remarks/>
        [JsonProperty]
        public string InvoiceNumber { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty]
		public string InvoiceDueDate { get; private set; }

        /// <remarks/>
        [JsonProperty]
        public string InvoiceOCR { get; set; }

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
        public List<InvoiceWriteOff> WriteOffs { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty]
		public string url { get; private set; }
    }

	/// <remarks/>
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class InvoiceWriteOff
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
}
