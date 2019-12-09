using System;
using System.ComponentModel;
using FortnoxAPILibrary.Connectors;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>

	[Entity(SingularName = "FinancialYear", PluralName = "FinancialYears")]
	public class FinancialYear : FinancialYearSubset
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
		[JsonProperty(PropertyName = "@url")]
		public string Url { get; private set; }
    }

    /// <remarks/>
    [Entity(SingularName = "FinancialYear", PluralName = "FinancialYears")]
    public class FinancialYearSubset
    {
        /// <remarks/>
        [JsonProperty]
        public string Id { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string FromDate { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string ToDate { get; set; }

        /// <remarks/>
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }
    }
}
