using System;
using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
    [Entity(SingularName = "Project", PluralName = "Projects")]
    public class ProjectSubset
    {
        ///<summary> Direct URL to the record </summary>
        [ReadOnly]
        [JsonProperty("@url")]
        public string Url { get; private set; }
        
        ///<summary> Description of the project </summary>
        [JsonProperty]
        public string Description { get; set; }

        ///<summary> End date of the project. </summary>
        [JsonProperty]
        public DateTime? EndDate { get; set; }

        ///<summary> Projectleader </summary>
        [JsonProperty]
        public string ProjectLeader { get; set; }

        ///<summary> Projectnumber. </summary>
        [JsonProperty]
        public string ProjectNumber { get; set; }

        ///<summary> Status of the project </summary>
        [JsonProperty]
        public Status? Status { get; set; }

        ///<summary> Start date of the project </summary>
        [JsonProperty]
        public DateTime? StartDate { get; set; }
    }
}
