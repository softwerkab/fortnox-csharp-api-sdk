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
    public class Account
	{
        /// <remarks/>
		[JsonProperty]
		public string Active { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string BalanceBroughtForward { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty]
		public string BalanceCarriedForward { get; private set; }

        /// <remarks/>
        [JsonProperty]
        public string CostCenter { get; set; }

        /// <remarks/>
        [JsonProperty]
        public AccountConnector.CostCenterSettingsValue? CostCenterSettings { get; set; }
        public bool ConstCenterSettingsSpecified => CostCenterSettings != null;

		/// <remarks/>
		[JsonProperty]
		public string Description { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Number { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Project { get; set; }

        /// <remarks/>
        [JsonProperty]
        public AccountConnector.ProjectSettingsValue? ProjectSettings { get; set; }
        public bool ProjectSettingsSpecified => ProjectSettings != null;

        /// <remarks/>
        [JsonProperty]
        public string SRU { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string TransactionInformation { get; set; }

        /// <remarks/>
        [JsonProperty]
        public AccountConnector.TransactionInfoSettingsValue? TransactionInformationSettings { get; set; }
        public bool TransactionInformationSettingsSpecified => TransactionInformationSettings != null;

        /// <remarks/>
        [JsonProperty]
        public string VATCode { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty]
		public string Year { get; private set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty]
		public string url { get; private set; }
    }
}
