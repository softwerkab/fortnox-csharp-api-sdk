using System;
using Fortnox.SDK.Serialization;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global

namespace Fortnox.SDK.Entities
{
    /// <remarks/>
    [Entity(SingularName = "TaxReduction", PluralName = "TaxReductions")]
    public class TaxReductionSubset
    {
        ///<summary> Direct URL to the record </summary>
        [ReadOnly]
        [JsonProperty("@url")]
        public Uri Url { get; private set; }

        ///<summary> Apporoved amount </summary>
        [ReadOnly]
        [JsonProperty]
        public decimal? ApprovedAmount { get; private set; }

        ///<summary> Name of the customer </summary>
        [JsonProperty]
        public string CustomerName { get; set; }

        ///<summary> Id </summary>
        [ReadOnly]
        [JsonProperty]
        public string Id { get; private set; }

        ///<summary> Document type </summary>
        [JsonProperty]
        public ReferenceDocumentType? ReferenceDocumentType { get; set; }

        ///<summary> Reference number </summary>
        [JsonProperty]
        public long? ReferenceNumber { get; set; }

        ///<summary> Social security number </summary>
        [JsonProperty]
        public string SocialSecurityNumber { get; set; }
    }
}
