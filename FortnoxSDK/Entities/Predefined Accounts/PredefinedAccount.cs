using Fortnox.SDK.Serialization;
using Newtonsoft.Json;

namespace Fortnox.SDK.Entities
{
    [Entity(SingularName = "PreDefinedAccount", PluralName = "PreDefinedAccounts")]
    public class PredefinedAccount
    {

        ///<summary> Direct url to the record. </summary>
        [ReadOnly]
        [JsonProperty("@url")]
        public string Url { get; private set; }

        ///<summary> Name of account type </summary>
        [ReadOnly]
        [JsonProperty]
        public string Name { get; private set; }

        ///<summary> Predefined account </summary>
        [JsonProperty]
        public long? Account { get; set; }
    }
}