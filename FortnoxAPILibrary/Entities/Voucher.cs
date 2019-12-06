using System;
using System.Collections.Generic;
using System.ComponentModel;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
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
		public string ReferenceNumber { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		public string ReferenceType { get; private set; }

        /// <remarks/>
        public string TransactionDate { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		public string VoucherNumber { get; private set; }

        /// <remarks/>
		public List<VoucherRow> VoucherRows { get; set; }

        /// <remarks/>
        public string VoucherSeries { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		public string Year { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		public string url { get; private set; }
    }

	/// <remarks/>
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
		public string Removed { get; private set; }

        /// <remarks/>
        public string TransactionInformation { get; set; }
    }
}
