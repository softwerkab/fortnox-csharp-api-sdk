using System.Collections.Generic;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class Contracts : BaseEntityCollection
    {
        /// <remarks/>
        [JsonProperty(PropertyName="Contracts")]
        public List<ContractSubset> ContractSubset { get; set; }



    }

    /// <remarks/>
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class ContractSubset
    {
        /// <remarks/>
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Continuous { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string ContractLength { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Currency { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string CustomerName { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string CustomerNumber { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string DocumentNumber { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string InvoiceInterval { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string InvoicesRemaining { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string LastInvoiceDate { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string PeriodStart { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string PeriodEnd { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Status { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string TemplateNumber { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Total { get; set; }
    }
}
