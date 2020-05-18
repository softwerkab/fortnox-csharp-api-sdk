using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;

namespace FortnoxAPILibrary.Entities
{
    [Entity(SingularName = "Supplier", PluralName = "Suppliers")]
    public class Supplier
    {

        ///<summary> If active </summary>
        [JsonProperty]
        public bool? Active { get; set; }

        ///<summary> First address field </summary>
        [JsonProperty]
        public string Address1 { get; set; }

        ///<summary> Second address field </summary>
        [JsonProperty]
        public string Address2 { get; set; }

        ///<summary> Bank of the supplier </summary>
        [JsonProperty]
        public string Bank { get; set; }

        ///<summary> Bank account number of the supplier </summary>
        [JsonProperty]
        public string BankAccountNumber { get; set; }

        ///<summary> BG number for the supplier </summary>
        [JsonProperty]
        public string BG { get; set; }

        ///<summary> Bank Identifier Code </summary>
        [JsonProperty]
        public string BIC { get; set; }

        ///<summary> Branch Code(SNI) </summary>
        [JsonProperty]
        public string BranchCode { get; set; }

        ///<summary> City of the supplier address </summary>
        [JsonProperty]
        public string City { get; set; }

        ///<summary> Clearing number </summary>
        [JsonProperty]
        public string ClearingNumber { get; set; }

        ///<summary> Comments </summary>
        [JsonProperty]
        public string Comments { get; set; }

        ///<summary> Cost center code </summary>
        [JsonProperty]
        public string CostCenter { get; set; }

        ///<summary> Country of the supplier address </summary>
        [ReadOnly]
        [JsonProperty]
        public string Country { get; private set; }

        ///<summary> Country code of the supplier address </summary>
        [JsonProperty]
        public string CountryCode { get; set; }

        ///<summary> Currency of the supplier </summary>
        [JsonProperty]
        public string Currency { get; set; }

        ///<summary> Payment file disabled for the supplier </summary>
        [JsonProperty]
        public bool? DisablePaymentFile { get; set; }

        ///<summary> Email of the supplier </summary>
        [JsonProperty]
        public string Email { get; set; }

        ///<summary> Fax number </summary>
        [JsonProperty]
        public string Fax { get; set; }

        ///<summary> International Bank Account Number </summary>
        [JsonProperty]
        public string IBAN { get; set; }

        ///<summary> Name of the supplier </summary>
        [JsonProperty]
        public string Name { get; set; }

        ///<summary> Organisation number of the supplier </summary>
        [JsonProperty]
        public string OrganisationNumber { get; set; }

        ///<summary> Our reference for the supplier </summary>
        [JsonProperty]
        public string OurReference { get; set; }

        ///<summary> Our customer number for the supplier </summary>
        [JsonProperty]
        public string OurCustomerNumber { get; set; }

        ///<summary> PG number for the supplier </summary>
        [JsonProperty]
        public string PG { get; set; }

        ///<summary> Phone number for the supplier </summary>
        [JsonProperty]
        public string Phone1 { get; set; }

        ///<summary> Phone number for the supplier </summary>
        [JsonProperty]
        public string Phone2 { get; set; }

        ///<summary> Pre defined account of the supplier </summary>
        [JsonProperty]
        public string PreDefinedAccount { get; set; }

        ///<summary> Project number </summary>
        [JsonProperty]
        public string Project { get; set; }

        ///<summary> The supplier number. If not provided, the next supplier number in the series will be used. </summary>
        [JsonProperty]
        public string SupplierNumber { get; set; }

        ///<summary> The suppliers terms of payment </summary>
        [JsonProperty]
        public string TermsOfPayment { get; set; }

        ///<summary> VAT Number </summary>
        [JsonProperty]
        public string VATNumber { get; set; }

        ///<summary> VAT Type </summary>
        [JsonProperty]
        public SupplierVATType? VATType { get; set; }

        ///<summary> Visiting address </summary>
        [JsonProperty]
        public string VisitingAddress { get; set; }

        ///<summary> Visiting city </summary>
        [JsonProperty]
        public string VisitingCity { get; set; }

        ///<summary> Visiting country </summary>
        [JsonProperty]
        public string VisitingCountry { get; set; }

        ///<summary> Visiting country code </summary>
        [JsonProperty]
        public string VisitingCountryCode { get; set; }

        ///<summary> Visiting zip code </summary>
        [JsonProperty]
        public string VisitingZipCode { get; set; }

        ///<summary> Work place(CFAR) </summary>
        [JsonProperty]
        public string WorkPlace { get; set; }

        ///<summary> The suppliers website </summary>
        [JsonProperty]
        public string WWW { get; set; }

        ///<summary> Your reference for the supplier </summary>
        [JsonProperty]
        public string YourReference { get; set; }

        ///<summary> The zip code of the supplier address </summary>
        [JsonProperty]
        public string ZipCode { get; set; }
    }
}