using System;
using Fortnox.SDK.Serialization;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global

namespace Fortnox.SDK.Entities
{
    /// <remarks/>
    [Entity(SingularName = "SalaryTransaction", PluralName = "SalaryTransactions")]
    public class SalaryTransactionSubset : SalaryTransaction
    {
        ///<summary> Direct URL to the record </summary>
        [ReadOnly]
        [JsonProperty("@url")]
        public Uri Url { get; private set; }
    }
}
