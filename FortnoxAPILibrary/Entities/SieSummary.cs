using System.Collections.Generic;
using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
	[Entity(SingularName = "SieSummary")]
	public class SieSummary
	{
        /// <remarks/>
		[JsonProperty]
		public string Accounts { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string ContactName { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string ContactDeliveryAddress { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string ContactMailingAddress { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string ContactPhone { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string CostCenters { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string DateOfGeneration { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Extent { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string IncomingBalances { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Projects { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string TermBudgets { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string TypeOfSie { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string UsedAccounts { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string UsedCostCenters { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string UsedProjects { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Verifications { get; set; }

        /// <remarks/>
		[JsonProperty]
		public List<VerificationInterval> VerificationsIntervals { get; set; }
    }

	/// <remarks/>
	public class VerificationInterval
	{
        /// <remarks/>
		[JsonProperty]
		public string First { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Last { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Series { get; set; }
    }
}
