using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FortnoxAPILibrary.Entities
{
    [Entity(SingularName = "DefaultDeliveryTypes", PluralName = "DefaultDeliveryTypes")]
    public class DefaultDeliveryTypes
    {

        ///<summary> Default delivery type for invoices. Can be PRINT EMAIL or PRINTSERVICE. </summary>
        [JsonProperty]
        public Invoice? Invoice { get; set; }

        ///<summary> Default delivery type for orders. Can be PRINT EMAIL or PRINTSERVICE. </summary>
        [JsonProperty]
        public Order? Order { get; set; }

        ///<summary> Default delivery type for offers. Can be PRINT EMAIL or PRINTSERVICE. </summary>
        [JsonProperty]
        public Offer? Offer { get; set; }
    }
}