using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;
using System;

namespace FortnoxAPILibrary.Entities
{
    [Entity(SingularName = "Currency", PluralName = "Currencies")]
    public class Currency
    {

        ///<summary> Direct URL to the record </summary>
        [ReadOnly]
        [JsonProperty("@url")]
        public string Url { get; private set; }

        ///<summary> The buy rate of the currency </summary>
        [JsonProperty]
        public decimal? BuyRate { get; set; }

        ///<summary> The code of the currency </summary>
        [JsonProperty]
        public string Code { get; set; }

        ///<summary> The date of retrieval of the buy/sell rates </summary>
        [ReadOnly]
        [JsonProperty]
        public DateTime? Date { get; private set; }

        ///<summary> The description of the currency </summary>
        [JsonProperty]
        public string Description { get; set; }

        ///<summary> The sell rate of the currency </summary>
        [JsonProperty]
        public decimal? SellRate { get; set; }

        ///<summary> The unit of the currency </summary>
        [JsonProperty]
        public decimal? Unit { get; set; }

        ///<summary> If the currency has automatic updates on it </summary>
        [ReadOnly]
        [JsonProperty]
        public bool? IsAutomatic { get; private set; }
    }
}