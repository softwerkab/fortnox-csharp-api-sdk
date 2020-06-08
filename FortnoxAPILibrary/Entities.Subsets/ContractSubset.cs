using System;
using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
    [Entity(SingularName = "Contract", PluralName = "Contracts")]
    public class ContractSubset
    {
        ///<summary> Direct URL to the record </summary>
        [ReadOnly]
        [JsonProperty("@url")]
        public string Url { get; private set; }

        ///<summary> If the contract is continuous </summary>
        [JsonProperty]
        public bool? Continuous { get; set; }

        ///<summary> Contract length </summary>
        [JsonProperty]
        public int? ContractLength { get; set; }

        ///<summary> Currency </summary>
        [JsonProperty]
        public string Currency { get; set; }

        ///<summary> Customer name </summary>
        [JsonProperty]
        public string CustomerName { get; set; }

        ///<summary> Customer number </summary>
        [JsonProperty]
        public string CustomerNumber { get; set; }

        ///<summary> Document number </summary>
        [JsonProperty]
        public int? DocumentNumber { get; set; }

        ///<summary> Invoice interval </summary>
        [JsonProperty("Interval")]
        public int? InvoiceInterval { get; set; }

        ///<summary> Invoices remaining </summary>
        [ReadOnly]
        [JsonProperty]
        public int? InvoicesRemaining { get; private set; }

        ///<summary> Last invoice date </summary>
        [ReadOnly]
        [JsonProperty]
        public DateTime? LastInvoiceDate { get; private set; }

        ///<summary> End of the period </summary>
        [JsonProperty]
        public DateTime? PeriodEnd { get; set; }

        ///<summary> Start of the period </summary>
        [JsonProperty]
        public DateTime? PeriodStart { get; set; }

        ///<summary> Template number </summary>
        [JsonProperty]
        public int? TemplateNumber { get; set; }

        ///<summary> Total </summary>
        [ReadOnly]
        [JsonProperty]
        public decimal? Total { get; private set; }

        [JsonProperty]
        public string Status { get; set; }
    }
}
