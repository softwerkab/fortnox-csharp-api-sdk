using Newtonsoft.Json;

namespace FortnoxAPILibrary.Entities
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class BaseEntityCollection
    {
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
        [JsonProperty(PropertyName = "@TotalResources")]
        public string TotalResources { get; set; }

        [JsonProperty(PropertyName = "@TotalPages")]
        public string TotalPages { get; set; }

        [JsonProperty(PropertyName = "@CurrentPage")]
        public string CurrentPage { get; set; }
    }
}
