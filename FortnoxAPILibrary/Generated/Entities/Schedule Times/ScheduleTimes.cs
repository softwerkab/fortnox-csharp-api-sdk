using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FortnoxAPILibrary.Entities
{
    [Entity(SingularName = "ScheduleTimes", PluralName = "ScheduleTimes")]
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
        public double? Hours { get; set; }

        ///<summary> Amount of hours </summary>
        [JsonProperty]
        public double? IWH1 { get; set; }

        ///<summary> Amount of hours </summary>
        [JsonProperty]
        public double? IWH2 { get; set; }

        ///<summary> Amount of hours </summary>
        [JsonProperty]
        public double? IWH3 { get; set; }
    }
}