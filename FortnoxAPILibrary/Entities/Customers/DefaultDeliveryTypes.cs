using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;

namespace FortnoxAPILibrary.Entities
{
    [Entity(SingularName = "DefaultDeliveryTypes", PluralName = "DefaultDeliveryTypes")]
    public class DefaultDeliveryTypes
    {

        ///<summary> Default delivery type for invoices. Can be PRINT EMAIL or PRINTSERVICE. </summary>
        [JsonProperty]
        public DefaultDeliveryType? Invoice { get; set; }

        ///<summary> Default delivery type for orders. Can be PRINT EMAIL or PRINTSERVICE. </summary>
        [JsonProperty]
        public DefaultDeliveryType? Order { get; set; }

        ///<summary> Default delivery type for offers. Can be PRINT EMAIL or PRINTSERVICE. </summary>
        [JsonProperty]
        public DefaultDeliveryType? Offer { get; set; }
    }
}