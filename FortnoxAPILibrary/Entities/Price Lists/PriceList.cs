using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;

namespace FortnoxAPILibrary.Entities
{
    [Entity(SingularName = "PriceList", PluralName = "PriceLists")]
    public class PriceList
    {

        ///<summary> Direct url to the record </summary>
        [ReadOnly]
        [JsonProperty("@url")]
        public string Url { get; private set; }

        ///<summary> Code of pricelist </summary>
        [JsonProperty]
        public string Code { get; set; }

        ///<summary> Description of pricelist </summary>
        [JsonProperty]
        public string Description { get; set; }

        ///<summary> Comments for pricelist </summary>
        [JsonProperty]
        public string Comments { get; set; }

        ///<summary> If the price list is pre selected </summary>
        [ReadOnly]
        [JsonProperty]
        public bool? PreSelected { get; private set; }
    }
}