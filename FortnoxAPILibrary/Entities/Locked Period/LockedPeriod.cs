using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;
using System;

namespace FortnoxAPILibrary.Entities
{
    [Entity(SingularName = "LockedPeriod", PluralName = "LockedPeriods")]
    public class LockedPeriod
    {
        ///<summary> End date of the locked period </summary>
        [ReadOnly]
        [JsonProperty]
        public DateTime? EndDate { get; private set; }
    }
}