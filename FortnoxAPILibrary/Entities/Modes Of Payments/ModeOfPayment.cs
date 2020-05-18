using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;

namespace FortnoxAPILibrary.Entities
{
    [Entity(SingularName = "ModeOfPayment", PluralName = "ModesOfPayments")]
    public class ModeOfPayment
    {

        ///<summary> Direct url to the record </summary>
        [ReadOnly]
        [JsonProperty("@url")]
        public string Url { get; private set; }

        ///<summary> Code for mode of payment </summary>
        [JsonProperty]
        public string Code { get; set; }

        ///<summary> Description of mode of payment </summary>
        [JsonProperty]
        public string Description { get; set; }

        ///<summary> Account number </summary>
        [JsonProperty]
        public int? AccountNumber { get; set; }
    }
}