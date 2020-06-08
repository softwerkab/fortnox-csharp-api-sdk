using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace FortnoxAPILibrary.Entities
{
    [Entity(SingularName = "ContractAccrual", PluralName = "ContractAccruals")]
    public class ContractAccrual
    {

        ///<summary> Direct URL to the record </summary>
        [ReadOnly]
        [JsonProperty("@url")]
        public string Url { get; private set; }

        ///<summary> Account for the accrual </summary>
        [JsonProperty]
        public int? AccrualAccount { get; set; }

        ///<summary> Account for the cost </summary>
        [JsonProperty]
        public int? CostAccount { get; set; }

        ///<summary> Description </summary>
        [JsonProperty]
        public string Description { get; set; }

        ///<summary> – </summary>
        [JsonProperty]
        public List<ContractAccrualRow> AccrualRows { get; set; }

        ///<summary> Document number </summary>
        [JsonProperty]
        public int? DocumentNumber { get; set; }

        ///<summary> Type of period </summary>
        [ReadOnly]
        [JsonProperty]
        public Period? Period { get; private set; }

        ///<summary> Total times of accruals </summary>
        [ReadOnly]
        [JsonProperty]
        public int? Times { get; private set; }

        ///<summary> Total of the accrual </summary>
        [JsonProperty]
        public decimal? Total { get; set; }

        ///<summary> Is VAT included </summary>
        [JsonProperty]
        public bool? VATIncluded { get; set; }
    }
}