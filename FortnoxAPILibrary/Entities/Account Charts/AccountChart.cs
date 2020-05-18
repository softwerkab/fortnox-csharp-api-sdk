using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;

namespace FortnoxAPILibrary.Entities
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