using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
    [Entity(SingularName = "Authorization")]
    public class Authorization {
    
        /// <remarks/>
        [JsonProperty]
        public string AccessToken { get; set; }
    }
}
