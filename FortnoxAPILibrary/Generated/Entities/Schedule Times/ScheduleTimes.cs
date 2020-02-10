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
        [ReadOnly]
        [JsonProperty]
        public string EmployeeId { get; private set; }

        ///<summary> Date </summary>
        [ReadOnly]
        [JsonProperty]
        public DateTime? Date { get; private set; }

        ///<summary> Unique schedule-od </summary>
        [ReadOnly]
        [JsonProperty]
        public string ScheduleId { get; private set; }

        ///<summary> Amount of hours </summary>
        [ReadOnly]
        [JsonProperty]
        public double? Hours { get; private set; }

        ///<summary> Amount of hours </summary>
        [ReadOnly]
        [JsonProperty]
        public double? IWH1 { get; private set; }

        ///<summary> Amount of hours </summary>
        [ReadOnly]
        [JsonProperty]
        public double? IWH2 { get; private set; }

        ///<summary> Amount of hours </summary>
        [ReadOnly]
        [JsonProperty]
        public double? IWH3 { get; private set; }
    }
}