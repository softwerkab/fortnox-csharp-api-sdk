using System.ComponentModel;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks />
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class CompanySettings
    {
        /// <remarks />
        [JsonProperty]
        public string Address { get; private set; }

        /// <remarks />
        [JsonProperty]
        public string BG { get; private set; }

        /// <remarks />
        [JsonProperty]
        public string BIC { get; private set; }

        /// <remarks />
        [JsonProperty]
        public string BranchCode { get; private set; }

        /// <remarks />
        [JsonProperty]
        public string City { get; private set; }

        /// <remarks />
        [JsonProperty]
        public string ContactFirstName { get; private set; }

        /// <remarks />
        [JsonProperty]
        public string ContactLastName { get; private set; }

        /// <remarks />
        [JsonProperty]
        public string Country { get; private set; }

        /// <remarks />
        [JsonProperty]
        public string CountryCode { get; private set; }

        /// <remarks />
        [JsonProperty]
        public string DatabaseNumber { get; private set; }

        /// <remarks />
        [JsonProperty]
        public string Domicile { get; private set; }

        /// <remarks />
        [JsonProperty]
        public string Email { get; private set; }

        /// <remarks />
        [JsonProperty]
        public string Fax { get; private set; }

        /// <remarks />
        [JsonProperty]
        public string IBAN { get; private set; }

        /// <remarks />
        [JsonProperty]
        public string Name { get; private set; }

        /// <remarks />
        [JsonProperty]
        public string OrganizationNumber { get; private set; }

        /// <remarks />
        [JsonProperty]
        public string PG { get; private set; }

        /// <remarks />
        [JsonProperty]
        public string Phone1 { get; private set; }

        /// <remarks />
        [JsonProperty]
        public string Phone2 { get; private set; }

        /// <remarks />
        [JsonProperty]
        public string TaxEnabled { get; private set; }

        /// <remarks />
        [JsonProperty]
        public string VATNumber { get; private set; }

        /// <remarks />
        [JsonProperty]
        public string VisitAddress { get; private set; }

        /// <remarks />
        [JsonProperty]
        public string VisitCity { get; private set; }

        /// <remarks />
        [JsonProperty]
        public string VisitCountry { get; private set; }

        /// <remarks />
        [JsonProperty]
        public string VisitCountryCode { get; private set; }

        /// <remarks />
        [JsonProperty]
        public string VisitName { get; private set; }

        /// <remarks />
        [JsonProperty]
        public string VisitZipCode { get; private set; }

        /// <remarks />
        [JsonProperty]
        public string WWW { get; private set; }

        /// <remarks />
        [JsonProperty]
        public string ZipCode { get; private set; }

    }
}
