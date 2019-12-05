using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Schema;
using System.Xml.Serialization;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>

    [Serializable]
	
	
	[XmlType(AnonymousType = true)]
	[XmlRoot(Namespace = "", IsNullable = false)]
	public class SupplierInvoicePayment
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

        /// <remarks/>
        public string Information { get; set; }

        /// <remarks/>
        public string InvoiceNumber { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
		public string InvoiceDueDate { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
		public string InvoiceOCR { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
		public string InvoiceSupplierName { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
		public string InvoiceSupplierNumber { get; set; }

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
        [XmlElement("WriteOff", Form = XmlSchemaForm.Unqualified)]
		public List<SupplierInvoiceWriteOff> WriteOffs { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [XmlAttribute]
		[ReadOnly(true)]
		public string url { get; set; }
    }

	/// <remarks/>
	
	[Serializable]
	
	
	[XmlType(AnonymousType = true)]

	public class SupplierInvoiceWriteOff
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
