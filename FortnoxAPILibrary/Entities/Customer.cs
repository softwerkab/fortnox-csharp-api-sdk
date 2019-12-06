using System;
using System.ComponentModel;
using FortnoxAPILibrary.Connectors;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
	[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
	public class Customer
	{
		/// <remarks/>
		[JsonProperty]
		public string Active { get; set; }

		/// <remarks/>
		[JsonProperty]
		public string Address1 { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Address2 { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string City { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty]
		public string Country { get; private set; }

        /// <remarks/>
        [JsonProperty]
        public string Comments { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Currency { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string CostCenter { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string CountryCode { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string CustomerNumber { get; set; }

        /// <remarks/>
        [JsonProperty]
        public InvoiceDefaultDeliveryTypes DefaultDeliveryTypes { get; set; }

        /// <remarks/>
        [JsonProperty]
        public InvoiceDefaultTemplates DefaultTemplates { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string DeliveryAddress1 { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string DeliveryAddress2 { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string DeliveryCity { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty]
		public string DeliveryCountry { get; private set; }

        /// <remarks/>
        [JsonProperty]
        public string DeliveryCountryCode { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string DeliveryFax { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string DeliveryName { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string DeliveryPhone1 { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string DeliveryPhone2 { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string DeliveryZipCode { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Email { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string EmailInvoice { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string EmailInvoiceBCC { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string EmailInvoiceCC { get; set; }
        /// <remarks/>
        [JsonProperty]
        public string EmailOffer { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string EmailOfferBCC { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string EmailOfferCC { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string EmailOrder { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string EmailOrderBCC { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string EmailOrderCC { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Fax { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string GLN { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string GLNDelivery { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string InvoiceAdministrationFee { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string InvoiceDiscount { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string InvoiceFreight { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string InvoiceRemark { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Name { get; set; }

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
        public string Project { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string SalesAccount { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string ShowPriceVATIncluded { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string TermsOfDelivery { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string TermsOfPayment { get; set; }

        /// <remarks/>
        [JsonProperty]
        public CustomerConnector.Type? Type { get; set; }
        public bool TypeSpecified => Type != null;

		/// <remarks/>
		[JsonProperty]
		public string VATNumber { get; set; }

        /// <remarks/>
        [JsonProperty]
        public CustomerConnector.VATType? VATType { get; set; }
        public bool VATTypeSpecified => VATType != null;

        /// <remarks/>
        [JsonProperty]
        public string VisitingAddress { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string VisitingCity { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty]
		public string VisitingCountry { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [JsonProperty]
        public string VisitingCountryCode { get; private set; }

        /// <remarks/>
        [JsonProperty]
        public string VisitingZipCode { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string WayOfDelivery { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string WWW { get; set; }

		/// <remarks/>
		[JsonProperty]
		public string YourReference { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string ZipCode { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty]
		public string url { get; private set; }
    }

	/// <remarks/>
	[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
	public class InvoiceDefaultDeliveryTypes
	{
		/// <remarks/>
		[JsonProperty]
		public CustomerConnector.DefaultInvoiceDeliveryType? Invoice { get; set; }
        public bool InvoiceSpecified => Invoice != null;

        /// <remarks/>
        [JsonProperty]
        public CustomerConnector.DefaultOfferDeliveryType? Offer { get; set; }
        public bool OfferSpecified => Offer != null;

        /// <remarks/>
        [JsonProperty]
        public CustomerConnector.DefaultOrderDeliveryType? Order { get; set; }
        public bool OrderSpecified => Order != null;
    }

	/// <remarks/>
	[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
	public class InvoiceDefaultTemplates
	{
        /// <remarks/>
		[JsonProperty]
		public string CashInvoice { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Invoice { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Offer { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Order { get; set; }
    }
}
