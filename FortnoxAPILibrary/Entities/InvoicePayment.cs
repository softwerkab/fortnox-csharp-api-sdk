using System;
using System.Collections.Generic;
using System.ComponentModel;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
	public class InvoicePayment
	{
        /// <remarks/>
		public string Amount { get; set; }

        /// <remarks/>
        public string AmountCurrency { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		public string Booked { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		public string Currency { get; private set; }

        /// <remarks/>
        public string CurrencyRate { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		public string CurrencyUnit { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		public string ExternalInvoiceReference1 { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		public string ExternalInvoiceReference2 { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		public string InvoiceCustomerName { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		public string InvoiceCustomerNumber { get; private set; }

        /// <remarks/>
        public string InvoiceNumber { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		public string InvoiceDueDate { get; private set; }

        /// <remarks/>
        public string InvoiceOCR { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		public string InvoiceTotal { get; private set; }

        /// <remarks/>
        public string ModeOfPayment { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		public string Number { get; private set; }

        /// <remarks/>
        public string PaymentDate { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		public string Source { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		public string VoucherNumber { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		public string VoucherSeries { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		public string VoucherYear { get; private set; }

        /// <remarks/>
        public List<InvoiceWriteOff> WriteOffs { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		public string url { get; private set; }
    }

	/// <remarks/>
    public class InvoiceWriteOff
	{
		/// <remarks/>
		public string Amount { get; set; }

        /// <remarks/>
        public string AccountNumber { get; set; }

        /// <remarks/>
        public string CostCenter { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		public string Currency { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		public string Description { get; private set; }

        /// <remarks/>
        public string TransactionInformation { get; set; }

        /// <remarks/>
        public string Project { get; set; }
    }
}
