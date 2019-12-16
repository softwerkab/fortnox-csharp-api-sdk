using System.Collections.Generic;
using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
    [Entity(SingularName = "ContractAccrual", PluralName = "ContractAccruals")]
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
        [ReadOnly]
        [JsonProperty]
        public string Period { get; private set; }

        /// <remarks/>
        [JsonProperty]
        public string RevenueAccount { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly]
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
        public string Url { get; set; }
    }

    /// <remarks/>
    [Entity(SingularName = "ContractAccrual", PluralName = "ContractAccruals")]
    public class ContractAccrualSubSet
    {
        /// <remarks/>
        [JsonProperty]
        public string Description { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string InvoiceNumber { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Period { get; set; }

        /// <remarks/>
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }
    }
}
