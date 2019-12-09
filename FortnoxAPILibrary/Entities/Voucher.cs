using System;
using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
	[Entity(SingularName = "Voucher", PluralName = "Vouchers")]
	public class Voucher 
	{
        /// <remarks/>
        public Voucher()
        {
            VoucherRows = new List<VoucherRow>();
        }

		/// <remarks/>
		[JsonProperty]
		public string Comments { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string CostCenter { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Description { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Project { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty]
		public string ReferenceNumber { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty]
		public string ReferenceType { get; private set; }

        /// <remarks/>
        [JsonProperty]
        public string TransactionDate { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty]
		public string VoucherNumber { get; private set; }

        /// <remarks/>
		[JsonProperty]
		public List<VoucherRow> VoucherRows { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string VoucherSeries { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty]
		public string Year { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty(PropertyName = "@url")]
		public string Url { get; private set; }
    }

	/// <remarks/>
	public class VoucherRow
	{
        /// <remarks/>
		[JsonProperty]
		public string Account { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Description { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Debit { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string CostCenter { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Credit { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Project { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Quantity { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty]
		public string Removed { get; private set; }

        /// <remarks/>
        [JsonProperty]
        public string TransactionInformation { get; set; }
    }

    /// <remarks/>
    [Entity(SingularName = "Voucher", PluralName = "Vouchers")]
    public class VoucherSubset
    {

        /// <remarks/>
        [JsonProperty]
        public string ReferenceNumber { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string ReferenceType { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string VoucherNumber { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string VoucherSeries { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Year { get; set; }

        /// <remarks/>
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }
    }
}
