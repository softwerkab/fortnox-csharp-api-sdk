using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;

namespace FortnoxAPILibrary.Entities
{
    [Entity(SingularName = "CompanySettings", PluralName = "CompanySettings")]
    public class CompanySettings
    {

        ///<summary> Direct URL to the record </summary>
        [ReadOnly]
        [JsonProperty("@url")]
        public string Url { get; private set; }

        ///<summary> Address for the company </summary>
        [ReadOnly]
        [JsonProperty]
        public string Address { get; private set; }

        ///<summary> Bankgiro </summary>
        [ReadOnly]
        [JsonProperty]
        public string BG { get; private set; }

        ///<summary> BIC </summary>
        [ReadOnly]
        [JsonProperty]
        public string BIC { get; private set; }

        ///<summary> Branch code (SNI) </summary>
        [ReadOnly]
        [JsonProperty]
        public string BranchCode { get; private set; }

        ///<summary> City </summary>
        [ReadOnly]
        [JsonProperty]
        public string City { get; private set; }

        ///<summary> Contact person – First name </summary>
        [ReadOnly]
        [JsonProperty]
        public string ContactFirstName { get; private set; }

        ///<summary> Contact person – Last name </summary>
        [ReadOnly]
        [JsonProperty]
        public string ContactLastName { get; private set; }

        ///<summary> Country </summary>
        [ReadOnly]
        [JsonProperty]
        public string Country { get; private set; }

        ///<summary> CountryCode </summary>
        [ReadOnly]
        [JsonProperty]
        public string CountryCode { get; private set; }

        ///<summary> Database number </summary>
        [ReadOnly]
        [JsonProperty]
        public string DatabaseNumber { get; private set; }

        ///<summary> Domicile </summary>
        [ReadOnly]
        [JsonProperty]
        public string Domicile { get; private set; }

        ///<summary> Email </summary>
        [ReadOnly]
        [JsonProperty]
        public string Email { get; private set; }

        ///<summary> Fax </summary>
        [ReadOnly]
        [JsonProperty]
        public string Fax { get; private set; }

        ///<summary> IBAN </summary>
        [ReadOnly]
        [JsonProperty]
        public string IBAN { get; private set; }

        ///<summary> Company name </summary>
        [ReadOnly]
        [JsonProperty]
        public string Name { get; private set; }

        ///<summary> Organisation number </summary>
        [ReadOnly]
        [JsonProperty]
        public string OrganisationNumber { get; private set; }

        ///<summary> Plusgiro </summary>
        [ReadOnly]
        [JsonProperty]
        public string PG { get; private set; }

        ///<summary> Phone </summary>
        [ReadOnly]
        [JsonProperty]
        public string Phone1 { get; private set; }

        ///<summary> Phone </summary>
        [ReadOnly]
        [JsonProperty]
        public string Phone2 { get; private set; }

        ///<summary> Tax enabled </summary>
        [ReadOnly]
        [JsonProperty]
        public bool? TaxEnabled { get; private set; }

        ///<summary> VAT number </summary>
        [ReadOnly]
        [JsonProperty]
        public string VATNumber { get; private set; }

        ///<summary> Visit address </summary>
        [ReadOnly]
        [JsonProperty]
        public string VisitAddress { get; private set; }

        ///<summary> Visit city </summary>
        [ReadOnly]
        [JsonProperty]
        public string VisitCity { get; private set; }

        ///<summary> Visit country </summary>
        [ReadOnly]
        [JsonProperty]
        public string VisitCountry { get; private set; }

        ///<summary> Visit country code </summary>
        [ReadOnly]
        [JsonProperty]
        public string VisitCountryCode { get; private set; }

        ///<summary> Visit name </summary>
        [ReadOnly]
        [JsonProperty]
        public string VisitName { get; private set; }

        ///<summary> Visit zip code </summary>
        [ReadOnly]
        [JsonProperty]
        public string VisitZipCode { get; private set; }

        ///<summary> Website </summary>
        [ReadOnly]
        [JsonProperty]
        public string WWW { get; private set; }

        ///<summary> Zip code </summary>
        [ReadOnly]
        [JsonProperty]
        public string ZipCode { get; private set; }
    }
}