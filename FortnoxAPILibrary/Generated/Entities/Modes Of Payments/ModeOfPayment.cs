using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FortnoxAPILibrary.Entities
{
    [Entity(SingularName = "ModeOfPayment", PluralName = "ModeOfPayments")]
    public class ModeOfPayment
    {

        ///<summary> Direct url to the record </summary>
        [JsonProperty("@url")]
        public string Url { get; set; }

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