using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Entities
{

    /// <remarks/>
    [Entity(SingularName = "Label", PluralName = "Labels")]
    public class Label
    {
        /// <remarks/>
        [JsonProperty]
        public string Description { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly]
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; private set; }

        /// <remarks/>
        [JsonProperty]
        public string Id { get; set; }
    }

    /// <remarks/>
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
