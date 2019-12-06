using System;
using System.ComponentModel;
using FortnoxAPILibrary.Connectors;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>

    [Serializable]
	public class TaxReduction
	{
        /// <summary>This field is Read-Only in Fortnox</summary>
		[ReadOnly(true)]
		public string ApprovedAmount { get; set; }

        /// <remarks/>
        public string AskedAmount { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
		public string BilledAmount { get; set; }

        /// <remarks/>
        public string CustomerName { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
		public string Id { get; set; }

        /// <remarks/>
        public string PropertyDesignation { get; set; }

        /// <remarks/>
        public TaxReductionConnector.ReferenceDocumentType ReferenceDocumentType { get; set; }

        /// <remarks/>
        public string ReferenceNumber { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
		public string RequestSent { get; set; }

        /// <remarks/>
        public string ResidenceAssociationOrganisationNumber { get; set; }

        /// <remarks/>
        public string SocialSecurityNumber { get; set; }

        /// <remarks/>
        public TaxReductionConnector.TypeOfReduction TypeOfReduction { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
		public string VoucherNumber { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
		public string VoucherSeries { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
		public string VoucherYear { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
		public string url { get; set; }
    }
}
