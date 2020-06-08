using System;
using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
    [Entity(SingularName = "Offer", PluralName = "Offers")]
    public class OfferSubset
    {
        ///<summary> Direct url to the record and URL to Taxreduction for the offer (URL to Taxreduction shows even if � Taxreduction is connected to offer) </summary>
        [ReadOnly]
        [JsonProperty("@url")]
        public string Url { get; private set; }

        ///<summary> If the offer is cancelled </summary>
        [ReadOnly]
        [JsonProperty]
        public bool? Cancelled { get; private set; }

        ///<summary> Currency </summary>
        [JsonProperty]
        public string Currency { get; set; }

        ///<summary> Customer name </summary>
        [JsonProperty]
        public string CustomerName { get; set; }

        ///<summary> Customer number </summary>
        [JsonProperty]
        public string CustomerNumber { get; set; }

        ///<summary> Document Number </summary>
        [JsonProperty]
        public int? DocumentNumber { get; set; }

        ///<summary> Date of order </summary>
        [JsonProperty]
        public DateTime? OfferDate { get; set; }

        ///<summary> Project code </summary>
        [JsonProperty]
        public string Project { get; set; }

        ///<summary> If document is printed or e-mailed to customer </summary>
        [ReadOnly]
        [JsonProperty]
        public bool? Sent { get; private set; }

        ///<summary> Total amount </summary>
        [ReadOnly]
        [JsonProperty]
        public decimal? Total { get; private set; }
    }
}
