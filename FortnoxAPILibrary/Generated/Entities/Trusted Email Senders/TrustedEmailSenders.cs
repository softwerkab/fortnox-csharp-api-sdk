using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FortnoxAPILibrary.Entities
{
    [Entity(SingularName = "TrustedEmailSenders", PluralName = "TrustedEmailSenders")]
    public class TrustedEmailSenders
    {

        ///<summary> Id of the record </summary>
        [ReadOnly]
        [JsonProperty]
        public int? Id { get; private set; }

        ///<summary> Email address of trusted/rejected sender </summary>
        [JsonProperty]
        public string Email { get; set; }
    }
}