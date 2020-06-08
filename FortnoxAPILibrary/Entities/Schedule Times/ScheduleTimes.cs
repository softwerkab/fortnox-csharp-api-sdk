using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;
using System;

namespace FortnoxAPILibrary.Entities
{
    [Entity(SingularName = "ScheduleTime", PluralName = "ScheduleTimes")]
    public class ScheduleTimes
    {
        ///<summary> Unique employee-id </summary>
        [JsonProperty]
        public string EmployeeId { get; set; }

        ///<summary> Date </summary>
        [JsonProperty]
        public DateTime? Date { get; set; }

        ///<summary> Unique schedule-od </summary>
        [JsonProperty]
        public string ScheduleId { get; set; }

        ///<summary> Amount of hours </summary>
        [JsonProperty]
        public decimal? Hours { get; set; }

        ///<summary> Amount of hours </summary>
        [JsonProperty]
        public decimal? IWH1 { get; set; }

        ///<summary> Amount of hours </summary>
        [JsonProperty]
        public decimal? IWH2 { get; set; }

        ///<summary> Amount of hours </summary>
        [JsonProperty]
        public decimal? IWH3 { get; set; }
    }
}