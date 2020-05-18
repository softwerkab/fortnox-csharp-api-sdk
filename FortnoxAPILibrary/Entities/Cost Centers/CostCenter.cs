using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;

namespace FortnoxAPILibrary.Entities
{
    [Entity(SingularName = "CostCenter", PluralName = "CostCenters")]
    public class CostCenter
    {

        ///<summary> Direct URL to the record </summary>
        [ReadOnly]
        [JsonProperty("@url")]
        public string Url { get; private set; }

        ///<summary> The code of the cost center </summary>
        [JsonProperty]
        public string Code { get; set; }

        ///<summary> The description of the cost center </summary>
        [JsonProperty]
        public string Description { get; set; }

        ///<summary> The note of the cost center </summary>
        [JsonProperty]
        public string Note { get; set; }

        ///<summary> If the cost center is active or not </summary>
        [JsonProperty]
        public bool? Active { get; set; }
    }
}