using Fortnox.SDK.Serialization;
using Newtonsoft.Json;

namespace Fortnox.SDK.Entities
{
    [Entity(SingularName = "Authorization")]
    public class AuthorizationData
    {
        [JsonProperty]
        public string AccessToken { get; set; }
    }
}
