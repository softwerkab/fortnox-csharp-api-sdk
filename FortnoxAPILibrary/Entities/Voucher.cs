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
	public class Voucher
	{
        /// <remarks/>
        public Voucher()
        {
            VoucherRows = new List<VoucherRow>();
        }

		/// <remarks/>
		public string Comments { get; set; }

        /// <remarks/>
        public string CostCenter { get; set; }

        /// <remarks/>
        public string Description { get; set; }

        /// <remarks/>
        public string Project { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
		public string ReferenceNumber { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
		public string ReferenceType { get; set; }

        /// <remarks/>
        public string TransactionDate { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
		public string VoucherNumber { get; set; }

        /// <remarks/>
        [XmlArrayItem("VoucherRow", IsNullable = false)]
		public List<VoucherRow> VoucherRows { get; set; }

        /// <remarks/>
        public string VoucherSeries { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
		public string Year { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
		[XmlAttribute]
		public string url { get; set; }
    }

	/// <remarks/>
    [Serializable]
    [XmlType(AnonymousType = true)]
	public class VoucherRow
	{
        /// <remarks/>
		public string Account { get; set; }

        /// <remarks/>
        public string Description { get; set; }

        /// <remarks/>
        public string Debit { get; set; }

        /// <remarks/>
        public string CostCenter { get; set; }

        /// <remarks/>
        public string Credit { get; set; }

        /// <remarks/>
        public string Project { get; set; }

        /// <remarks/>
        public string Quantity { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
		public string Removed { get; set; }

        /// <remarks/>
        public string TransactionInformation { get; set; }
    }
}
