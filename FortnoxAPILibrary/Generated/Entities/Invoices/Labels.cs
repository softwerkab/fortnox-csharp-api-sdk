using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FortnoxAPILibrary.Entities
{
    [Entity(SingularName = "Labels", PluralName = "Labels")]
    public class Labels
    {

        ///<summary> Id of the label. </summary>
        [JsonProperty]
        public int? Id { get; set; }
    }
}