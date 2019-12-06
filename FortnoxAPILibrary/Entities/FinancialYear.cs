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
	public class FinancialYear
	{
		/// <remarks/>
		[JsonProperty]
		public string AccountChartType { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty]
		public string Id { get; private set; }

        /// <remarks/>
        [JsonProperty]
        public FinancialYearConnector.AccountingMethod AccountingMethod { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string FromDate { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string ToDate { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[JsonProperty]
		public string url { get; private set; }
    }
}
