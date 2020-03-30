using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
    [Entity(SingularName = "Supplier", PluralName = "Suppliers")]
    public class SupplierSubset
    {
        ///<summary> First address field </summary>
        [JsonProperty]
        public string Address1 { get; set; }

        ///<summary> Second address field </summary>
        [JsonProperty]
        public string Address2 { get; set; }

        ///<summary> Bank account number of the supplier </summary>
        [JsonProperty]
        public string BankAccountNumber { get; set; }

        ///<summary> BG number for the supplier </summary>
        [JsonProperty]
        public string BG { get; set; }

        ///<summary> Bank Identifier Code </summary>
        [JsonProperty]
        public string BIC { get; set; }

        ///<summary> City of the supplier address </summary>
        [JsonProperty]
        public string City { get; set; }
        
        ///<summary> Cost center code </summary>
        [JsonProperty]
        public string CostCenter { get; set; }

        ///<summary> Country of the supplier address </summary>
        [ReadOnly]
        [JsonProperty]
        public string Country { get; private set; }

        ///<summary> Currency of the supplier </summary>
        [JsonProperty]
        public string Currency { get; set; }

        ///<summary> Payment file disabled for the supplier </summary>
        [JsonProperty]
        public bool? DisablePaymentFile { get; set; }

        ///<summary> Email of the supplier </summary>
        [JsonProperty]
        public string Email { get; set; }

        ///<summary> International Bank Account Number </summary>
        [JsonProperty]
        public string IBAN { get; set; }

        ///<summary> Name of the supplier </summary>
        [JsonProperty]
        public string Name { get; set; }

        ///<summary> Organisation number of the supplier </summary>
        [JsonProperty]
        public string OrganisationNumber { get; set; }

        ///<summary> PG number for the supplier </summary>
        [JsonProperty]
        public string PG { get; set; }

        ///<summary> Phone number for the supplier </summary>
        [JsonProperty]
        public string Phone { get; set; }
        
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

        ///<summary> The zip code of the supplier address </summary>
        [JsonProperty]
        public string ZipCode { get; set; }
    }
}
