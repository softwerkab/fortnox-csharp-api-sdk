using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FortnoxAPILibrary.Entities
{
    [Entity(SingularName = "AccountChart", PluralName = "AccountCharts")]
    public class AccountChart
    {

        ///<summary> Name of the account chart </summary>
        [ReadOnly]
        [JsonProperty]
        public string Name { get; private set; }
    }
}