using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
    [Entity(SingularName = "Authorization")]
    public class Authorization
    {

        /// <remarks/>
        [JsonProperty]
        public string AccessToken { get; set; }
    }
}
