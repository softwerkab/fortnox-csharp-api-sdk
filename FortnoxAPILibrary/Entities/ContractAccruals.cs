using System.Collections.Generic;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class ContractAccruals
    {
        /// <remarks/>
        [JsonProperty]
        public List<ContractAccrualSubSet> ContractAccrualSubset { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string TotalResources { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string TotalPages { get; set; }
        
        /// <remarks/>
        [JsonProperty]
        public string CurrentPage { get; set; }
    }

    /// <remarks/>
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
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
