using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FortnoxAPILibrary.Entities
{
    [Entity(SingularName = "SupplierInvoiceAccrual", PluralName = "SupplierInvoiceAccruals")]
    public class SupplierInvoiceAccrual
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

        ///<summary> Description of the accrual </summary>
        [JsonProperty]
        public string Description { get; set; }

        ///<summary> End date </summary>
        [JsonProperty]
        public DateTime? EndDate { get; set; }

        ///<summary> Number of the supplier invoice </summary>
        [JsonProperty]
        public int? SupplierInvoiceNumber { get; set; }

        ///<summary> Type of period </summary>
        [JsonProperty]
        public string Period { get; set; }

        ///<summary> – </summary>
        [JsonProperty]
        public List<SupplierInvoiceAccrualRow> SupplierInvoiceAccrualRows { get; set; }

        ///<summary> Start date </summary>
        [JsonProperty]
        public DateTime? StartDate { get; set; }

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