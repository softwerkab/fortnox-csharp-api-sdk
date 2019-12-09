using System;
using System.Collections.Generic;
using System.ComponentModel;
using FortnoxAPILibrary.Connectors;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
	[Entity(SingularName = "InvoiceAccrual", PluralName = "InvoiceAccruals")]
	public class InvoiceAccrual : InvoiceAccrualSubset
	{
        /// <remarks/>
		[JsonProperty]
		public string AccrualAccount { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Description { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string EndDate { get; set; }

        /// <remarks/>
		[JsonProperty]
		public List<InvoiceAccrualRow> InvoiceAccrualRows { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string InvoiceNumber { get; set; }

        /// <remarks/>
        [JsonProperty]
        public InvoiceAccrualConnector.Period? Period { get; set; }

		/// <remarks/>
		[JsonProperty]
		public string RevenueAccount { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string StartDate { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty]
		public string Times { get; private set; }

        /// <remarks/>
        [JsonProperty]
        public string Total { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string VATIncluded { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty(PropertyName = "@url")]
		public string Url { get; private set; }
    }

	/// <remarks/>
	public class InvoiceAccrualRow
	{
        /// <remarks/>
		[JsonProperty]
		public string Account { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string CostCenter { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Credit { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Debit { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string TransactionInformation { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Project { get; set; }
    }

    /// <remarks/>
    [Entity(SingularName = "InvoiceAccrual", PluralName = "InvoiceAccruals")]
    public class InvoiceAccrualSubset
    {
        /// <remarks/>
        [JsonProperty]
        public string Description { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string InvoiceNumber { get; set; }

        /// <remarks/>
        [JsonProperty]
        public InvoiceAccrualConnector.Period Period { get; set; }

        /// <remarks/>
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }
    }
}
