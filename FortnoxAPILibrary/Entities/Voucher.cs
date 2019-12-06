using System;
using System.Collections.Generic;
using System.ComponentModel;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
    [Serializable]
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
		public List<VoucherRow> VoucherRows { get; set; }

        /// <remarks/>
        public string VoucherSeries { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
		public string Year { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
		public string url { get; set; }
    }

	/// <remarks/>
    [Serializable]
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
