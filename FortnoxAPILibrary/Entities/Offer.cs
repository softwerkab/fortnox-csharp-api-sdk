using System.Collections.Generic;
using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
	[Entity(SingularName = "Offer", PluralName = "Offers")]
	public class Offer 
	{
        /// <remarks/>
        public Offer()
        {
            OfferRows = new List<OfferRow>();
            Labels = new List<Label>();
        }

		/// <remarks/>
		[JsonProperty]
		public decimal? AdministrationFee { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly]
        [JsonProperty]
        public decimal? AdministrationFeeVAT { get; private set; }

        /// <remarks/>
        [JsonProperty]
        public string Address1 { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Address2 { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[ReadOnly]
		[JsonProperty]
		public decimal? BasisTaxReduction { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[ReadOnly]
		[JsonProperty]
		public bool? Cancelled { get; private set; }

        /// <remarks/>
        [JsonProperty]
        public string City { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Comments { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[ReadOnly]
		[JsonProperty]
		public decimal? ContributionPercent { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[ReadOnly]
		[JsonProperty]
		public decimal? ContributionValue { get; private set; }

        /// <remarks/>
        [JsonProperty]
        public bool? CopyRemarks { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Country { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string CostCenter { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Currency { get; set; }

        /// <remarks/>
        [JsonProperty]
        public decimal? CurrencyRate { get; set; }

        /// <remarks/>
        [JsonProperty]
        public decimal? CurrencyUnit { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string CustomerName { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string CustomerNumber { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string DeliveryAddress1 { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string DeliveryAddress2 { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string DeliveryCity { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string DeliveryCountry { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string DeliveryDate { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string DeliveryName { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string DeliveryZipCode { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string DocumentNumber { get; set; }

        /// <remarks/>
        [JsonProperty]
        public OfferEmailInformation EmailInformation { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string ExpireDate { get; set; }

        /// <remarks/>
        [JsonProperty]
        public decimal? Freight { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly]
        [JsonProperty]
        public decimal? FreightVAT { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[ReadOnly]
		[JsonProperty]
		public decimal? Gross { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[ReadOnly]
		[JsonProperty]
		public bool? HouseWork { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[ReadOnly]
		[JsonProperty]
		public string InvoiceReference { get; private set; }

        /// <remarks/>
        [JsonProperty]
        public string Language { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[ReadOnly]
		[JsonProperty]
		public decimal? Net { get; private set; }

        /// <remarks/>
        [JsonProperty]
        public string NotCompleted { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string OfferDate { get; set; }

        /// <remarks/>
        [JsonProperty]
        public List<OfferRow> OfferRows { get; set; }

        /// <remarks/>
        [JsonProperty]
        public List<Label> Labels { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[ReadOnly]
		[JsonProperty]
		public string OrderReference { get; private set; }

        /// <remarks/>
        [JsonProperty]
        public string OrganisationNumber { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string OurReference { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Phone1 { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Phone2 { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string PriceList { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string PrintTemplate { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Project { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Remarks { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[ReadOnly]
		[JsonProperty]
		public decimal? RoundOff { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[ReadOnly]
		[JsonProperty]
		public bool? Sent { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[ReadOnly]
		[JsonProperty]
		public decimal? TaxReduction { get; private set; }

        /// <remarks/>
        [JsonProperty]
        public string TermsOfDelivery { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string TermsOfPayment { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[ReadOnly]
		[JsonProperty]
		public decimal? Total { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[ReadOnly]
		[JsonProperty]
		public string TotalToPay { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[ReadOnly]
		[JsonProperty]
		public string TotalVAT { get; private set; }

        /// <remarks/>
        [JsonProperty]
        public string VATIncluded { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string WayOfDelivery { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string YourReference { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string ZipCode { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[ReadOnly]
		[JsonProperty(PropertyName = "@url")]
		public string Url { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[ReadOnly]
		[JsonProperty(PropertyName = "@urlTaxReductionList")]
		public string UrlTaxReductionList { get; private set; }
    }

	/// <remarks/>
	public class OfferEmailInformation
	{
        /// <remarks/>
		[JsonProperty]
		public string EmailAddressFrom { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string EmailAddressTo { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string EmailAddressCC { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string EmailAddressBCC { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string EmailSubject { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string EmailBody { get; set; }
    }

	/// <remarks/>
    public class OfferRow
	{
        /// <remarks/>
		[JsonProperty]
		public string AccountNumber { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string ArticleNumber { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[ReadOnly]
		[JsonProperty]
		public decimal? ContributionPercent { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[ReadOnly]
		[JsonProperty]
		public decimal? ContributionValue { get; private set; }

        /// <remarks/>
        [JsonProperty]
        public string CostCenter { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Description { get; set; }

        /// <remarks/>
        [JsonProperty]
        public decimal? Discount { get; set; }

        /// <remarks/>
        [JsonProperty]
        public DiscountType? DiscountType { get; set; }

        /// <remarks/>
        [JsonProperty]
        public bool? HouseWork { get; set; }

        /// <remarks/>
        [JsonProperty]
        public decimal? Price { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Project { get; set; }

        /// <remarks/>
        [JsonProperty]
        public decimal? Quantity { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[ReadOnly]
		[JsonProperty]
		public decimal? Total { get; private set; }

        /// <remarks/>
        [JsonProperty]
        public string Unit { get; set; }

        /// <remarks/>
        [JsonProperty]
        public decimal? VAT { get; set; }
    }

    /// <remarks/>
    [Entity(SingularName = "Offer", PluralName = "Offers")]
    public class OfferSubset
    {
        /// <remarks/>
        [JsonProperty]
        public bool? Cancelled { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Currency { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string CustomerName { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string CustomerNumber { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string DocumentNumber { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string OfferDate { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Project { get; set; }

        /// <remarks/>
        [JsonProperty]
        public bool? Sent { get; set; }

        /// <remarks/>
        [JsonProperty]
        public decimal? Total { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly]
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; private set; }
    }
}
