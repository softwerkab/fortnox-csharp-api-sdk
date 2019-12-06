using System;
using System.Collections.Generic;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>

    
    
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class Labels {

        /// <remarks/>
        [JsonProperty]
        public List<LabelSubset> LabelSubset { get; set; }

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
    public class LabelSubset {

        /// <remarks/>
        [JsonProperty]
        public string Id { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Description { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string url { get; set; }
    }
}
