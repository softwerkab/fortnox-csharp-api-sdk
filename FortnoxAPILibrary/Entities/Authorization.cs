using System;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class Authorization {
    
        /// <remarks/>
        [JsonProperty]
        public string AccessToken { get; set; }
    }
}
