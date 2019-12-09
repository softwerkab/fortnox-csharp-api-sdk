using System;
using System.ComponentModel;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
	[Entity(SingularName = "Supplier", PluralName = "Suppliers")]
	public class Supplier : SupplierSubset
	{
        /// <remarks/>
		[JsonProperty]
		public string Address1 { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Active { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Address2 { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Bank { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string BankAccountNumber { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string BG { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string BIC { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string BranchCode { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string City { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string ClearingNumber { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Comments { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string CostCenter { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty]
		public string Country { get; private set; }

        /// <remarks/>
        [JsonProperty]
        public string CountryCode { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Currency { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string DisablePaymentFile { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Email { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Fax { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string IBAN { get; set; }

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
        public string OurCustomerNumber { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string PG { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Phone1 { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Phone2 { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string PreDefinedAccount { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Project { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string SupplierNumber { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string TermsOfPayment { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string VATNumber { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string VisitingAddress { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string VisitingCity { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty]
		public string VisitingCountry { get; private set; }

        /// <remarks/>
        [JsonProperty]
        public string VisitingCountryCode { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string VisitingZipCode { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string WorkPlace { get; set; }

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
		[JsonProperty(PropertyName = "@url")]
		public string Url { get; private set; }
    }

    /// <remarks/>
    [Entity(SingularName = "Supplier", PluralName = "Suppliers")]
    public class SupplierSubset
    {
        /// <remarks/>
        [JsonProperty]
        public string City { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Email { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Name { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string OrganisationNumber { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Phone { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string SupplierNumber { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string ZipCode { get; set; }

        /// <remarks/>
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }
    }
}
