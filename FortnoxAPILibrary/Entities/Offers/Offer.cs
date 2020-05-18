using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FortnoxAPILibrary.Entities
{
    [Entity(SingularName = "Offer", PluralName = "Offers")]
    public class Offer
    {

        ///<summary> Direct url to the record and URL to Taxreduction for the offer (URL to Taxreduction shows even if – Taxreduction is connected to offer) </summary>
        [ReadOnly]
        [JsonProperty("@url")]
        public string Url { get; private set; }

        ///<summary> Administration fee </summary>
        [JsonProperty]
        public decimal? AdministrationFee { get; set; }

        ///<summary> VAT of the administration fee </summary>
        [ReadOnly]
        [JsonProperty]
        public decimal? AdministrationFeeVAT { get; private set; }

        ///<summary> Address 1 </summary>
        [JsonProperty]
        public string Address1 { get; set; }

        ///<summary> Address 2 </summary>
        [JsonProperty]
        public string Address2 { get; set; }

        ///<summary> The amount that Taxreduction is based on </summary>
        [ReadOnly]
        [JsonProperty]
        public decimal? BasisTaxReduction { get; private set; }

        ///<summary> If the offer is cancelled </summary>
        [ReadOnly]
        [JsonProperty]
        public bool? Cancelled { get; private set; }

        ///<summary> City </summary>
        [JsonProperty]
        public string City { get; set; }

        ///<summary> Comments </summary>
        [JsonProperty]
        public string Comments { get; set; }

        ///<summary> Contribution in Percent </summary>
        [ReadOnly]
        [JsonProperty]
        public decimal? ContributionPercent { get; private set; }

        ///<summary> Contribution in amount </summary>
        [ReadOnly]
        [JsonProperty]
        public decimal? ContributionValue { get; private set; }

        ///<summary> Remarks will be copied from offer to order </summary>
        [JsonProperty]
        public bool? CopyRemarks { get; set; }

        ///<summary> Country </summary>
        [JsonProperty]
        public string Country { get; set; }

        ///<summary> Cost center </summary>
        [JsonProperty]
        public string CostCenter { get; set; }

        ///<summary> Currency </summary>
        [JsonProperty]
        public string Currency { get; set; }

        ///<summary> Currency rate </summary>
        [JsonProperty]
        public decimal? CurrencyRate { get; set; }

        ///<summary> Currency unit </summary>
        [JsonProperty]
        public decimal? CurrencyUnit { get; set; }

        ///<summary> Customer name </summary>
        [JsonProperty]
        public string CustomerName { get; set; }

        ///<summary> Customer number </summary>
        [JsonProperty]
        public string CustomerNumber { get; set; }

        ///<summary> Delivery address 1 </summary>
        [JsonProperty]
        public string DeliveryAddress1 { get; set; }

        ///<summary> Delivery address 2 </summary>
        [JsonProperty]
        public string DeliveryAddress2 { get; set; }

        ///<summary> Delivery City </summary>
        [JsonProperty]
        public string DeliveryCity { get; set; }

        ///<summary> Delivery Country </summary>
        [JsonProperty]
        public string DeliveryCountry { get; set; }

        ///<summary> Delivery date </summary>
        [JsonProperty]
        public DateTime? DeliveryDate { get; set; }

        ///<summary> Delivery name </summary>
        [JsonProperty]
        public string DeliveryName { get; set; }

        ///<summary> Delivery zipcode </summary>
        [JsonProperty]
        public string DeliveryZipCode { get; set; }

        ///<summary> Document Number </summary>
        [JsonProperty]
        public int? DocumentNumber { get; set; }

        ///<summary> – </summary>
        [JsonProperty]
        public EmailInformation EmailInformation { get; set; }

        ///<summary> Expire date </summary>
        [JsonProperty]
        public DateTime? ExpireDate { get; set; }

        ///<summary> Freight </summary>
        [JsonProperty]
        public decimal? Freight { get; set; }

        ///<summary> VAT of the freight </summary>
        [ReadOnly]
        [JsonProperty]
        public decimal? FreightVAT { get; private set; }

        ///<summary> Gross value of the offer </summary>
        [ReadOnly]
        [JsonProperty]
        public decimal? Gross { get; private set; }

        ///<summary> If offer is marked with housework </summary>
        [ReadOnly]
        [JsonProperty]
        public bool? HouseWork { get; private set; }

        ///<summary> Net amount </summary>
        [ReadOnly]
        [JsonProperty]
        public decimal? Net { get; private set; }

        ///<summary> If the offer is marked Completed (this mark stops the offer from being cancelled or that a user can create an order from the offer ) </summary>
        [JsonProperty]
        public bool? Completed { get; set; }

        ///<summary> Date of order </summary>
        [JsonProperty]
        public DateTime? OfferDate { get; set; }

        ///<summary> Reference to order </summary>
        [ReadOnly]
        [JsonProperty]
        public int? OrderReference { get; private set; }

        ///<summary> Organisation number </summary>
        [JsonProperty]
        public string OrganisationNumber { get; set; }

        ///<summary> Our reference </summary>
        [JsonProperty]
        public string OurReference { get; set; }

        ///<summary> Phone 1 </summary>
        [JsonProperty]
        public string Phone1 { get; set; }

        ///<summary> Phone 2 </summary>
        [JsonProperty]
        public string Phone2 { get; set; }

        ///<summary> Pricelist code </summary>
        [JsonProperty]
        public string PriceList { get; set; }

        ///<summary> Print document template </summary>
        [JsonProperty]
        public string PrintTemplate { get; set; }

        ///<summary> Project code </summary>
        [JsonProperty]
        public string Project { get; set; }

        ///<summary> Remarks on offer </summary>
        [JsonProperty]
        public string Remarks { get; set; }

        ///<summary> Round off amount </summary>
        [ReadOnly]
        [JsonProperty]
        public decimal? RoundOff { get; private set; }

        ///<summary> – </summary>
        [JsonProperty]
        public List<OfferRow> OfferRows { get; set; }

        ///<summary> If document is printed or e-mailed to customer </summary>
        [ReadOnly]
        [JsonProperty]
        public bool? Sent { get; private set; }

        ///<summary> Amount of Taxreduction </summary>
        [ReadOnly]
        [JsonProperty]
        public decimal? TaxReduction { get; private set; }

        ///<summary> Terms of delivery code </summary>
        [JsonProperty]
        public string TermsOfDelivery { get; set; }

        ///<summary> Terms of payment code </summary>
        [JsonProperty]
        public string TermsOfPayment { get; set; }

        ///<summary> Total amount </summary>
        [ReadOnly]
        [JsonProperty]
        public decimal? Total { get; private set; }

        ///<summary> Total vat amount </summary>
        [ReadOnly]
        [JsonProperty]
        public decimal? TotalVAT { get; private set; }

        ///<summary> If offer row price exclude or include vat </summary>
        [JsonProperty]
        public bool? VATIncluded { get; set; }

        ///<summary> Code of delivery </summary>
        [JsonProperty]
        public string WayOfDelivery { get; set; }

        ///<summary> Customer reference </summary>
        [JsonProperty]
        public string YourReference { get; set; }

        ///<summary> ReferenceNumber </summary>
        [JsonProperty]
        public string YourReferenceNumber { get; set; }

        ///<summary> Zip code </summary>
        [JsonProperty]
        public string ZipCode { get; set; }
    }
}