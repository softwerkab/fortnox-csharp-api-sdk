using System.Collections.Generic;
using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;

namespace FortnoxAPILibrary.Entities
{
    public class EntityCollection<T>
    {
        [GenericPropertyName]
        [JsonProperty]
        public List<T> Entities { get; set; }

        [JsonProperty]
        private MetaInformation MetaInformation { get; set; }

        /// <remarks/>
        public string TotalResources => MetaInformation.TotalResources;

        /// <remarks/>
        public string TotalPages => MetaInformation.TotalPages;

        /// <remarks/>
        public string CurrentPage => MetaInformation.CurrentPage;
    }

    public class MetaInformation
    {
        [JsonProperty("@TotalResources")]
        public string TotalResources { get; set; }

        [JsonProperty("@TotalPages")]
        public string TotalPages { get; set; }

        [JsonProperty("@CurrentPage")]
        public string CurrentPage { get; set; }
    }
}
