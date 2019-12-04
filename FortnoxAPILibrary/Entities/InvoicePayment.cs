using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
    [Serializable]
    [XmlType(AnonymousType = true)]
	[XmlRoot(Namespace = "", IsNullable = false)]
	public class InvoicePayment
	{
        /// <remarks/>
		public string Amount { get; set; }

        /// <remarks/>
        public string AmountCurrency { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
		public string Booked { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
		public string Currency { get; set; }

        /// <remarks/>
        public string CurrencyRate { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
		public string CurrencyUnit { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
		public string ExternalInvoiceReference1 { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
		public string ExternalInvoiceReference2 { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
		public string InvoiceCustomerName { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
		public string InvoiceCustomerNumber { get; set; }

        /// <remarks/>
        public string InvoiceNumber { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
		public string InvoiceDueDate { get; set; }

        /// <remarks/>
        public string InvoiceOCR { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
		public string InvoiceTotal { get; set; }

        /// <remarks/>
        public string ModeOfPayment { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
		public string Number { get; set; }

        /// <remarks/>
        public string PaymentDate { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
		public string Source { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
		public string VoucherNumber { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
		public string VoucherSeries { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
		public string VoucherYear { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlElementAttribute("WriteOffs", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public List<InvoiceWriteOff> WriteOffs { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [XmlAttribute]
		[ReadOnly(true)]
		public string url { get; set; }
    }

	/// <remarks/>
    [Serializable]
    [XmlType(AnonymousType = true)]
    public class InvoiceWriteOff
	{
		/// <remarks/>
		public string Amount { get; set; }

        /// <remarks/>
        public string AccountNumber { get; set; }

        /// <remarks/>
        public string CostCenter { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
		public string Currency { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
		public string Description { get; set; }

        /// <remarks/>
        public string TransactionInformation { get; set; }

        /// <remarks/>
        public string Project { get; set; }
    }
}
