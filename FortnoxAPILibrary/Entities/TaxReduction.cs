using System;
using System.ComponentModel;
using FortnoxAPILibrary.Connectors;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>

	[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
	[Entity(SingularName = "TaxReduction", PluralName = "TaxReductions")]
	public class TaxReduction : TaxReductionSubset
	{
        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty]
		public string ApprovedAmount { get; private set; }

        /// <remarks/>
        [JsonProperty]
        public string AskedAmount { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty]
		public string BilledAmount { get; private set; }

        /// <remarks/>
        [JsonProperty]
        public string CustomerName { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty]
		public string Id { get; private set; }

        /// <remarks/>
        [JsonProperty]
        public string PropertyDesignation { get; set; }

        /// <remarks/>
        [JsonProperty]
        public TaxReductionConnector.ReferenceDocumentType ReferenceDocumentType { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string ReferenceNumber { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty]
		public string RequestSent { get; private set; }

        /// <remarks/>
        [JsonProperty]
        public string ResidenceAssociationOrganisationNumber { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string SocialSecurityNumber { get; set; }

        /// <remarks/>
        [JsonProperty]
        public TaxReductionConnector.TypeOfReduction TypeOfReduction { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty]
		public string VoucherNumber { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty]
		public string VoucherSeries { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty]
		public string VoucherYear { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty(PropertyName = "@url")]
		public string Url { get; private set; }
    }

    /// <remarks/>
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    [Entity(SingularName = "TaxReduction", PluralName = "TaxReductions")]
    public class TaxReductionSubset
    {
        /// <remarks/>
        [JsonProperty]
        public string ApprovedAmount { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string CustomerName { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Id { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string ReferenceDocumentType { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string ReferenceNumber { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string SocialSecurityNumber { get; set; }

        /// <remarks/>
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }
    }
}
