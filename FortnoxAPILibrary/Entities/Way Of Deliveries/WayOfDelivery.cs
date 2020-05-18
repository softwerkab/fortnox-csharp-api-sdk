using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;

namespace FortnoxAPILibrary.Entities
{
    [Entity(SingularName = "WayOfDelivery", PluralName = "WayOfDeliveries")]
    public class WayOfDelivery
    {

        ///<summary> Direct URL to the record </summary>
        [ReadOnly]
        [JsonProperty("@url")]
        public string Url { get; private set; }

        ///<summary> The code of the way of delivery </summary>
        [JsonProperty]
        public string Code { get; set; }

        ///<summary> The description of the way of delivery </summary>
        [JsonProperty]
        public string Description { get; set; }
    }
}