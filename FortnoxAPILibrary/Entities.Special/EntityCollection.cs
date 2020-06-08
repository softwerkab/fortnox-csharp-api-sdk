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
        public int TotalResources => MetaInformation.TotalResources;

        /// <remarks/>
        public int TotalPages => MetaInformation.TotalPages;

        /// <remarks/>
        public int CurrentPage => MetaInformation.CurrentPage;
    }

    public class MetaInformation
    {
        [JsonProperty("@TotalResources")]
        public int TotalResources { get; set; }

        [JsonProperty("@TotalPages")]
        public int TotalPages { get; set; }

        [JsonProperty("@CurrentPage")]
        public int CurrentPage { get; set; }
    }
}
