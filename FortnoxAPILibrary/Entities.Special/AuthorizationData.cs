using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;

namespace FortnoxAPILibrary.Entities.Special
{
    [Entity(SingularName = "Authorization")]
    public class AuthorizationData
    {
        [JsonProperty]
        public string AccessToken { get; set; }
    }
}
