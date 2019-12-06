using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class ContractAccrual
    {
		/// <remarks/>
		[JsonProperty]
		public string AccrualAccount { get; set; }

		/// <remarks/>
		[JsonProperty]
		public string CostAccount { get; set; }

		/// <remarks/>
		[JsonProperty]
		public string Description { get; set; }

		/// <remarks/>
		[JsonProperty]
		public List<InvoiceAccrualRow> AccrualRows { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string DocumentNumber { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [JsonProperty]
        public string Period { get; private set; }

        /// <remarks/>
        [JsonProperty]
        public string RevenueAccount { get; set; }

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
        [JsonProperty]
        public string url { get; set; }
    }
}
