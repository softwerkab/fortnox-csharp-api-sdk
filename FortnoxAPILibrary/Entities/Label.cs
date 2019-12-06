using System.ComponentModel;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{

    /// <remarks/>
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class Label {
        
        /// <remarks/>
        [JsonProperty]
        public string Description { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; private set; }

        /// <remarks/>
        [JsonProperty]
        public string Id { get; set; }
    }
}
