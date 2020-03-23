using System;
using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
    [Entity(SingularName = "FinancialYear", PluralName = "FinancialYears")]
    public class FinancialYearSubset
    {
        ///<summary> Direct URL to the record </summary>
        [ReadOnly]
        [JsonProperty("@url")]
        public string Url { get; private set; }

        ///<summary> The ID of the financial year </summary>
        [ReadOnly]
        [JsonProperty]
        public int? Id { get; private set; }

        ///<summary> Start date of the financial year </summary>
        [JsonProperty]
        public DateTime? FromDate { get; set; }

        ///<summary> End date of the financial year </summary>
        [JsonProperty]
        public DateTime? ToDate { get; set; }

        ///<summary> Type of the account chart </summary>
        [JsonProperty("accountCharts")]
        public string AccountChartType { get; set; }

        ///<summary> Accounting Method </summary>
        [JsonProperty]
        public AccountingMethod? AccountingMethod { get; set; }
    }
}
