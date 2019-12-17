using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
    [Entity(SingularName = "LockedPeriod")]
    public class LockedPeriod
    {
        /// <remarks/>
        [ReadOnly]
        [JsonProperty]
        public string EndDate { get; private set; }
    }
}
