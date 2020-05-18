using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;

namespace FortnoxAPILibrary.Entities
{
    [Entity(SingularName = "CompanyInformation", PluralName = "CompanyInformation")]
    public class CompanyInformation
    {

        ///<summary> Address for the company </summary>
        [ReadOnly]
        [JsonProperty]
        public string Address { get; private set; }

        ///<summary> City </summary>
        [ReadOnly]
        [JsonProperty]
        public string City { get; private set; }

        ///<summary> Country Code </summary>
        [ReadOnly]
        [JsonProperty]
        public string CountryCode { get; private set; }

        ///<summary> Database number </summary>
        [ReadOnly]
        [JsonProperty]
        public string DatabaseNumber { get; private set; }

        ///<summary> Company name </summary>
        [ReadOnly]
        [JsonProperty]
        public string CompanyName { get; private set; }

        ///<summary> Organisation number </summary>
        [ReadOnly]
        [JsonProperty]
        public string OrganisationNumber { get; private set; }

        ///<summary> Visit address </summary>
        [ReadOnly]
        [JsonProperty]
        public string VisitAddress { get; private set; }

        ///<summary> Visit city </summary>
        [ReadOnly]
        [JsonProperty]
        public string VisitCity { get; private set; }

        ///<summary> Visit country code </summary>
        [ReadOnly]
        [JsonProperty]
        public string VisitCountryCode { get; private set; }

        ///<summary> Visit zip code </summary>
        [ReadOnly]
        [JsonProperty]
        public string VisitZipCode { get; private set; }

        ///<summary> Zip code </summary>
        [ReadOnly]
        [JsonProperty]
        public string ZipCode { get; private set; }
    }
}