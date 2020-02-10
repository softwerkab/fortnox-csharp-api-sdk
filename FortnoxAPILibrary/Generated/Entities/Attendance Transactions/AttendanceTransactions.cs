using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FortnoxAPILibrary.Entities
{
    [Entity(SingularName = "AttendanceTransactions", PluralName = "AttendanceTransactions")]
    public class AttendanceTransactions
    {

        ///<summary> Unique employee-id </summary>
        [JsonProperty]
        public string EmployeeId { get; set; }

        ///<summary> Cause code </summary>
        [JsonProperty]
        public string CauseCode { get; set; }

        ///<summary> Date </summary>
        [JsonProperty]
        public DateTime? Date { get; set; }

        ///<summary> Amount of hours </summary>
        [JsonProperty]
        public double? Hours { get; set; }

        ///<summary> Cost Center </summary>
        [JsonProperty]
        public string CostCenter { get; set; }

        ///<summary> Project </summary>
        [JsonProperty]
        public string Project { get; set; }
    }
}