using System;
using Fortnox.SDK.Serialization;
using Newtonsoft.Json;

namespace Fortnox.SDK.Entities
{
    [Entity(SingularName = "PriceList", PluralName = "PriceLists")]
    public class PriceList
    {

        ///<summary> Direct url to the record </summary>
        [ReadOnly]
        [JsonProperty("@url")]
        public Uri Url { get; private set; }

        ///<summary> Code of pricelist </summary>
        ///<remarks> It is recommended to use upper-case value. Other values can cause some undesired effects on server side.</remarks>
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