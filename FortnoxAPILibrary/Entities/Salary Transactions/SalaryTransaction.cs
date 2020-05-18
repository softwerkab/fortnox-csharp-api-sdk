using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;
using System;

namespace FortnoxAPILibrary.Entities
{
    [Entity(SingularName = "SalaryTransaction", PluralName = "SalaryTransactions")]
    public class SalaryTransaction
    {

        ///<summary> Unique employee-id </summary>
        [JsonProperty]
        public string EmployeeId { get; set; }

        ///<summary> Salary code </summary>
        [JsonProperty]
        public string SalaryCode { get; set; }

        ///<summary> Unique row ID </summary>
        [ReadOnly]
        [JsonProperty]
        public int? SalaryRow { get; private set; }

        ///<summary> Date </summary>
        [JsonProperty]
        public DateTime? Date { get; set; }

        ///<summary> Number of # </summary>
        [JsonProperty]
        public decimal? Number { get; set; }

        ///<summary> Cost per # in SEK </summary>
        [JsonProperty]
        public decimal? Amount { get; set; }

        ///<summary> Sum in SEK </summary>
        [JsonProperty]
        public decimal? Total { get; set; }

        ///<summary> Expense code from the expense registry </summary>
        [JsonProperty]
        public string Expense { get; set; }

        ///<summary> Sum VAT </summary>
        [JsonProperty]
        public decimal? VAT { get; set; }

        ///<summary> Optional additional text relating to the salary transaction </summary>
        [JsonProperty]
        public string TextRow { get; set; }

        ///<summary> Cost Center </summary>
        [JsonProperty]
        public string CostCenter { get; set; }

        ///<summary> Project </summary>
        [JsonProperty]
        public string Project { get; set; }
    }
}