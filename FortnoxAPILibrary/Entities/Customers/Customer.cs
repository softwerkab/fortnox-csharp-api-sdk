using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;

namespace FortnoxAPILibrary.Entities
{
    [Entity(SingularName = "Customer", PluralName = "Customers")]
    public class Customer
    {

        ///<summary> Direct URL to the record. </summary>
        [ReadOnly]
        [JsonProperty("@url")]
        public string Url { get; private set; }

        ///<summary> If the customer is active or not </summary>
        [JsonProperty]
        public bool? Active { get; set; }

        ///<summary> Address 1 of the customer. </summary>
        [JsonProperty]
        public string Address1 { get; set; }

        ///<summary> Address 2 of the customer. </summary>
        [JsonProperty]
        public string Address2 { get; set; }

        ///<summary> City of the customer. </summary>
        [JsonProperty]
        public string City { get; set; }

        ///<summary> Country name for the customer. </summary>
        [ReadOnly]
        [JsonProperty]
        public string Country { get; private set; }

        ///<summary> Comments of the customer. </summary>
        [JsonProperty]
        public string Comments { get; set; }

        ///<summary> Code of the currency for the customer. This will be used as the predefined currency for documents for the customer. The code must be of an existing currency. </summary>
        [JsonProperty]
        public string Currency { get; set; }

        ///<summary> Code of the cost center for the customer. The code must be of a an existing currency. </summary>
        [JsonProperty]
        public string CostCenter { get; set; }

        ///<summary> Code of the country for the customer. The code must be of an existing country according to ISO 3166-1 Alpha-2. </summary>
        [JsonProperty]
        public string CountryCode { get; set; }

        ///<summary> Customer number of the customer. If no customer number is provided, the next number in the series will be used. Only alpha numeric characters, with the addition of – + / and _, are allowed. </summary>
        [JsonProperty]
        public string CustomerNumber { get; set; }

        ///<summary> The properties for this object is listed in the table for “Default Delivery Types”. </summary>
        [JsonProperty]
        public DefaultDeliveryTypes DefaultDeliveryTypes { get; set; }

        ///<summary> The properties for this object is listed in the table for “Default Templates”. </summary>
        [JsonProperty]
        public DefaultTemplates DefaultTemplates { get; set; }

        ///<summary> Delivery address 1 for the customer. </summary>
        [JsonProperty]
        public string DeliveryAddress1 { get; set; }

        ///<summary> DeliveryAddress 2 for the customer. </summary>
        [JsonProperty]
        public string DeliveryAddress2 { get; set; }

        ///<summary> Delivery city for the customer. </summary>
        [JsonProperty]
        public string DeliveryCity { get; set; }

        ///<summary> Delivery country for the customer. </summary>
        [ReadOnly]
        [JsonProperty]
        public string DeliveryCountry { get; private set; }

        ///<summary> Code of the delivery country for the customer. The code must be of an existing country according to ISO 3166-1 Alpha-2. </summary>
        [JsonProperty]
        public string DeliveryCountryCode { get; set; }

        ///<summary> Delivery fax number of the customer. </summary>
        [JsonProperty]
        public string DeliveryFax { get; set; }

        ///<summary> Delivery name for the customer. </summary>
        [JsonProperty]
        public string DeliveryName { get; set; }

        ///<summary> Delivery phone number 1 for the customer. </summary>
        [JsonProperty]
        public string DeliveryPhone1 { get; set; }

        ///<summary> Delivery phone number 2 for the customer. </summary>
        [JsonProperty]
        public string DeliveryPhone2 { get; set; }

        ///<summary> Delivery zip code for the customer. </summary>
        [JsonProperty]
        public string DeliveryZipCode { get; set; }

        ///<summary> Email address for the customer. This must be a valid email address. </summary>
        [JsonProperty]
        public string Email { get; set; }

        ///<summary> Specific email address used for invoices sent to the customer. This must be a valid email address. </summary>
        [JsonProperty]
        public string EmailInvoice { get; set; }

        ///<summary> Specific blind carbon copy email address used for invoices sent to the customer. This must be a valid email address. </summary>
        [JsonProperty]
        public string EmailInvoiceBCC { get; set; }

        ///<summary> Specific carbon copy email address used for invoices sent to the customer. This must be a valid email address. </summary>
        [JsonProperty]
        public string EmailInvoiceCC { get; set; }

        ///<summary> Specific email address used for offers sent to the customer. This must be a valid email address. </summary>
        [JsonProperty]
        public string EmailOffer { get; set; }

        ///<summary> Specific blind carbon copy email address used for offers sent to the customer. This must be a valid email address. </summary>
        [JsonProperty]
        public string EmailOfferBCC { get; set; }

        ///<summary> Specific carbon copy email address used for offers sent to the customer. This must be a valid email address. </summary>
        [JsonProperty]
        public string EmailOfferCC { get; set; }

        ///<summary> Specific email address used for orders sent to the customer. This must be a valid email address. </summary>
        [JsonProperty]
        public string EmailOrder { get; set; }

        ///<summary> Specific blind carbon copy email address used for orders sent to the customer. This must be a valid email address. </summary>
        [JsonProperty]
        public string EmailOrderBCC { get; set; }

        ///<summary> Specific carbon copy email address used for orders sent to the customer. This must be a valid email address. </summary>
        [JsonProperty]
        public string EmailOrderCC { get; set; }

        ///<summary> Fax number for the customer. </summary>
        [JsonProperty]
        public string Fax { get; set; }

        ///<summary> Global Location Number of the customer </summary>
        [JsonProperty]
        public string GLN { get; set; }

        ///<summary> Global Location Delivery Number </summary>
        [JsonProperty]
        public string GLNDelivery { get; set; }

        ///<summary> Predefined invoice administration fee for the customer. </summary>
        [JsonProperty]
        public decimal? InvoiceAdministrationFee { get; set; }

        ///<summary> Predefined invoice discount for the customer. </summary>
        [JsonProperty]
        public decimal? InvoiceDiscount { get; set; }

        ///<summary> Predefined invoice freight fee for the customer. </summary>
        [JsonProperty]
        public decimal? InvoiceFreight { get; set; }

        ///<summary> Predefined invoice remark for the customer. </summary>
        [JsonProperty]
        public string InvoiceRemark { get; set; }

        ///<summary> Name of the customer. </summary>
        [JsonProperty]
        public string Name { get; set; }

        ///<summary> Organisation number of the customer. It needs to be a valid organisation numer. </summary>
        [JsonProperty]
        public string OrganisationNumber { get; set; }

        ///<summary> Our reference of the customer. </summary>
        [JsonProperty]
        public string OurReference { get; set; }

        ///<summary> Phone number 1 of the customer. </summary>
        [JsonProperty]
        public string Phone1 { get; set; }

        ///<summary> Phone number 2 of the customer. </summary>
        [JsonProperty]
        public string Phone2 { get; set; }

        ///<summary> Code of the price list for the customer. The code must be of a an existing price list. </summary>
        [JsonProperty]
        public string PriceList { get; set; }

        ///<summary> Number of the project for the customer. The number must be of a an existing project. </summary>
        [JsonProperty]
        public string Project { get; set; }

        ///<summary> Predefined sales account of the customer. </summary>
        [JsonProperty]
        public string SalesAccount { get; set; }

        ///<summary> If prices should be displayed with VAT included. </summary>
        [JsonProperty]
        public bool? ShowPriceVATIncluded { get; set; }

        ///<summary> Code of the terms of delivery for the customer. The code must be of a an existing terms of delivery. </summary>
        [JsonProperty]
        public string TermsOfDelivery { get; set; }

        ///<summary> Code of the terms of payment for the customer. The code must be of a an existing terms of payment. </summary>
        [JsonProperty]
        public string TermsOfPayment { get; set; }

        ///<summary> Type of the customer. Can be PRIVATE or COMPANY. </summary>
        [JsonProperty]
        public CustomerType? Type { get; set; }

        ///<summary> VAT number for the customer. </summary>
        [JsonProperty]
        public string VATNumber { get; set; }

        ///<summary> VAT type of the customer. Can be SEVAT SEREVERSEDVAT EUREVERSEDVAT EUVAT or EXPORT. </summary>
        [JsonProperty]
        public CustomerVATType? VATType { get; set; }

        ///<summary> Visiting address of the customer. </summary>
        [JsonProperty]
        public string VisitingAddress { get; set; }

        ///<summary> Visiting city of the customer. </summary>
        [JsonProperty]
        public string VisitingCity { get; set; }

        ///<summary> Visiting country of the customer. </summary>
        [ReadOnly]
        [JsonProperty]
        public string VisitingCountry { get; private set; }

        ///<summary> Code of the visiting country for the customer. The code must be of an existing country according to ISO 3166-1 Alpha-2. </summary>
        [JsonProperty]
        public string VisitingCountryCode { get; set; }

        ///<summary> Visiting zip code of the customer. </summary>
        [JsonProperty]
        public string VisitingZipCode { get; set; }

        ///<summary> Website of the customer. </summary>
        [JsonProperty]
        public string WWW { get; set; }

        ///<summary> Code of the way of delivery for the customer. The code must be of a an existing way of delivery. </summary>
        [JsonProperty]
        public string WayOfDelivery { get; set; }

        ///<summary> Your reference of the customer. </summary>
        [JsonProperty]
        public string YourReference { get; set; }

        ///<summary> Zip code of the customers. </summary>
        [JsonProperty]
        public string ZipCode { get; set; }
    }
}