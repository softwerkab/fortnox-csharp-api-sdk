using System;
using System.ComponentModel;
using System.Xml.Serialization;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>

    [Serializable]
	
	
	[XmlType(AnonymousType = true)]
	[XmlRoot(Namespace = "", IsNullable = false)]
	public class Supplier
	{
        /// <remarks/>
		public string Address1 { get; set; }

        /// <remarks/>
        public string Active { get; set; }

        /// <remarks/>
        public string Address2 { get; set; }

        /// <remarks/>
        public string Bank { get; set; }

        /// <remarks/>
        public string BankAccountNumber { get; set; }

        /// <remarks/>
        public string BG { get; set; }

        /// <remarks/>
        public string BIC { get; set; }

        /// <remarks/>
        public string BranchCode { get; set; }

        /// <remarks/>
        public string City { get; set; }

        /// <remarks/>
        public string ClearingNumber { get; set; }

        /// <remarks/>
        public string Comments { get; set; }

        /// <remarks/>
        public string CostCenter { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
		public string Country { get; set; }

        /// <remarks/>
        public string CountryCode { get; set; }

        /// <remarks/>
        public string Currency { get; set; }

        /// <remarks/>
        public string DisablePaymentFile { get; set; }

        /// <remarks/>
        public string Email { get; set; }

        /// <remarks/>
        public string Fax { get; set; }

        /// <remarks/>
        public string IBAN { get; set; }

        /// <remarks/>
        public string Name { get; set; }

        /// <remarks/>
        public string OrganisationNumber { get; set; }

        /// <remarks/>
        public string OurReference { get; set; }

        /// <remarks/>
        public string OurCustomerNumber { get; set; }

        /// <remarks/>
        public string PG { get; set; }

        /// <remarks/>
        public string Phone1 { get; set; }

        /// <remarks/>
        public string Phone2 { get; set; }

        /// <remarks/>
        public string PreDefinedAccount { get; set; }

        /// <remarks/>
        public string Project { get; set; }

        /// <remarks/>
        public string SupplierNumber { get; set; }

        /// <remarks/>
        public string TermsOfPayment { get; set; }

        /// <remarks/>
        public string VATNumber { get; set; }

        /// <remarks/>
        public string VisitingAddress { get; set; }

        /// <remarks/>
        public string VisitingCity { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
		public string VisitingCountry { get; set; }

        /// <remarks/>
        public string VisitingCountryCode { get; set; }

        /// <remarks/>
        public string VisitingZipCode { get; set; }

        /// <remarks/>
        public string WorkPlace { get; set; }

        /// <remarks/>
        public string WWW { get; set; }

        /// <remarks/>
        public string YourReference { get; set; }

        /// <remarks/>
        public string ZipCode { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
		[XmlAttribute]
		public string url { get; set; }
    }
}
