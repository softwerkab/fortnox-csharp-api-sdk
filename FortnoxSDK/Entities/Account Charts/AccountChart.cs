using Fortnox.SDK.Serialization;
using Newtonsoft.Json;

namespace Fortnox.SDK.Entities
{
    [Entity(SingularName = "AccountChart", PluralName = "AccountCharts")]
    public class AccountChart
    {

        ///<summary> Name of the account chart </summary>
        [ReadOnly]
        [JsonProperty]
        public string Name { get; private set; }
    }
}