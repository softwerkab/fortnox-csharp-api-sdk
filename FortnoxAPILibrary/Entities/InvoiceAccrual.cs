using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using FortnoxAPILibrary.Connectors;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
    [Serializable]
    [XmlType(AnonymousType = true)]
	[XmlRoot(Namespace = "", IsNullable = false)]
	public class InvoiceAccrual
	{
        /// <remarks/>
		public string AccrualAccount { get; set; }

        /// <remarks/>
        public string Description { get; set; }

        /// <remarks/>
        public string EndDate { get; set; }

        /// <remarks/>
        [XmlArrayItem("InvoiceAccrualRow", IsNullable = false)]
		public List<InvoiceAccrualRow> InvoiceAccrualRows { get; set; }

        /// <remarks/>
        public string InvoiceNumber { get; set; }

        /// <remarks/>
        public InvoiceAccrualConnector.Period? Period { get; set; }
        public bool PeriodSpecified => Period != null;

		/// <remarks/>
		public string RevenueAccount { get; set; }

        /// <remarks/>
        public string StartDate { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
		public string Times { get; set; }

        /// <remarks/>
        public string Total { get; set; }

        /// <remarks/>
        public string VATIncluded { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [XmlAttribute]
		[ReadOnly(true)]
		public string url { get; set; }
    }

	/// <remarks/>
	[Serializable]
    [XmlType(AnonymousType = true)]
	public class InvoiceAccrualRow
	{
        /// <remarks/>
		public string Account { get; set; }

        /// <remarks/>
        public string CostCenter { get; set; }

        /// <remarks/>
        public string Credit { get; set; }

        /// <remarks/>
        public string Debit { get; set; }

        /// <remarks/>
        public string TransactionInformation { get; set; }

        /// <remarks/>
        public string Project { get; set; }
    }
}
