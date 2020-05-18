using System;
using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
    [Entity(SingularName = "AttendanceTransaction", PluralName = "AttendanceTransactions")]
    public class AttendanceTransactionSubset
    {
        ///<summary> Direct URL to the record </summary>
        [JsonProperty("@url")]
        public string Url { get; set; }

        ///<summary> Unique employee-id </summary>
        [JsonProperty]
        public string EmployeeId { get; set; }

        ///<summary> Cause code </summary>
        [JsonProperty]
        public AttendanceCauseCode? CauseCode { get; set; }

        ///<summary> Date </summary>
        [JsonProperty]
        public DateTime? Date { get; set; }

        ///<summary> Amount of hours </summary>
        [JsonProperty]
        public decimal? Hours { get; set; }

        ///<summary> Cost Center </summary>
        [JsonProperty]
        public string CostCenter { get; set; }

        ///<summary> Project </summary>
        [JsonProperty]
        public string Project { get; set; }
    }
}
