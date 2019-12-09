using System.ComponentModel;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{

    /// <remarks/>
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    [Entity(SingularName = "Label", PluralName = "Labels")]
    public class Label : LabelSubset{
        
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

    /// <remarks/>
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    [Entity(SingularName = "Label", PluralName = "Labels")]
    public class LabelSubset
    {

        /// <remarks/>
        [JsonProperty]
        public string Id { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Description { get; set; }

        /// <remarks/>
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }
    }
}
