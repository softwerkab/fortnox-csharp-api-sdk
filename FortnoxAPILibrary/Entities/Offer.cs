using System;
using System.Collections.Generic;
using System.ComponentModel;
using FortnoxAPILibrary.Connectors;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

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
		public string AdministrationFee { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [JsonProperty]
        public string AdministrationFeeVAT { get; private set; }

        /// <remarks/>
        [JsonProperty]
        public string Address1 { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Address2 { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty]
		public string BasisTaxReduction { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty]
		public string Cancelled { get; private set; }

        /// <remarks/>
        [JsonProperty]
        public string City { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Comments { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty]
		public string ContributionPercent { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty]
		public string ContributionValue { get; private set; }

        /// <remarks/>
        [JsonProperty]
        public string CopyRemarks { get; set; }

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
        public string CurrencyRate { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string CurrencyUnit { get; set; }

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
        public string Freight { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [JsonProperty]
        public string FreightVAT { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty]
		public string Gross { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty]
		public string HouseWork { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty]
		public string InvoiceReference { get; private set; }

        /// <remarks/>
        [JsonProperty]
        public string Language { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty]
		public string Net { get; private set; }

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
		[JsonProperty]
		public string RoundOff { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty]
		public string Sent { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty]
		public string TaxReduction { get; private set; }

        /// <remarks/>
        [JsonProperty]
        public string TermsOfDelivery { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string TermsOfPayment { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty]
		public string Total { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty]
		public string TotalToPay { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
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
		[JsonProperty(PropertyName = "@url")]
		public string Url { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
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
		[JsonProperty]
		public string ContributionPercent { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty]
		public string ContributionValue { get; private set; }

        /// <remarks/>
        [JsonProperty]
        public string CostCenter { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Description { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Discount { get; set; }

        /// <remarks/>
        [JsonProperty]
        public OfferConnector.DiscountType DiscountType { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string HouseWork { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Price { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Project { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Quantity { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty]
		public string Total { get; private set; }

        /// <remarks/>
        [JsonProperty]
        public string Unit { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string VAT { get; set; }
    }

    /// <remarks/>
    [Entity(SingularName = "Offer", PluralName = "Offers")]
    public class OfferSubset
    {
        /// <remarks/>
        [JsonProperty]
        public string Cancelled { get; set; }

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
        public string Sent { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Total { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; private set; }
    }
}
