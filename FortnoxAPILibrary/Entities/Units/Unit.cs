using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;

namespace FortnoxAPILibrary.Entities
{
    [Entity(SingularName = "Unit", PluralName = "Units")]
    public class Unit
    {

        ///<summary> Direct URL to the record </summary>
        [ReadOnly]
        [JsonProperty("@url")]
        public string Url { get; private set; }

        ///<summary> The code of the unit </summary>
        [JsonProperty]
        public string Code { get; set; }

        ///<summary> The description of the unit </summary>
        [JsonProperty]
        public string Description { get; set; }
    }
}