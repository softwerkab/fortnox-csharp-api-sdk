using System;
using System.ComponentModel;
using FortnoxAPILibrary.Connectors;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>

	public class TaxReduction
	{
        /// <summary>This field is Read-Only in Fortnox</summary>
		public string ApprovedAmount { get; private set; }

        /// <remarks/>
        public string AskedAmount { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		public string BilledAmount { get; private set; }

        /// <remarks/>
        public string CustomerName { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		public string Id { get; private set; }

        /// <remarks/>
        public string PropertyDesignation { get; set; }

        /// <remarks/>
        public TaxReductionConnector.ReferenceDocumentType ReferenceDocumentType { get; set; }

        /// <remarks/>
        public string ReferenceNumber { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		public string RequestSent { get; private set; }

        /// <remarks/>
        public string ResidenceAssociationOrganisationNumber { get; set; }

        /// <remarks/>
        public string SocialSecurityNumber { get; set; }

        /// <remarks/>
        public TaxReductionConnector.TypeOfReduction TypeOfReduction { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		public string VoucherNumber { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		public string VoucherSeries { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		public string VoucherYear { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		public string url { get; private set; }
    }
}
