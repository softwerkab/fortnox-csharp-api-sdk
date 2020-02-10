using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FortnoxAPILibrary.Entities
{
    [Entity(SingularName = "LockedPeriod", PluralName = "LockedPeriods")]
    public class LockedPeriod
    {

        ///<summary> Direct URL to the record </summary>
        [ReadOnly]
        [JsonProperty("@url")]
        public string Url { get; private set; }

        ///<summary> End date of the locked period </summary>
        [ReadOnly]
        [JsonProperty]
        public DateTime? EndDate { get; private set; }
    }
}