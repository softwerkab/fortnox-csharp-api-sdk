using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FortnoxAPILibrary.Entities
{
    [Entity(SingularName = "TrustedDomain", PluralName = "TrustedDomains")]
    public class TrustedEmailDomain
    {

        ///<summary> Id of the record </summary>
        [ReadOnly]
        [JsonProperty]
        public int? Id { get; private set; }

        ///<summary> Domain address of trusted </summary>
        [JsonProperty]
        public string Domain { get; set; }
    }
}