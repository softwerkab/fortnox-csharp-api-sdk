using System;
using System.ComponentModel;
using FortnoxAPILibrary.Connectors;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>

    [Serializable]
	public class FinancialYear
	{
		/// <remarks/>
		public string AccountChartType { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
		public string Id { get; set; }

        /// <remarks/>
        public FinancialYearConnector.AccountingMethod AccountingMethod { get; set; }

        /// <remarks/>
        public string FromDate { get; set; }

        /// <remarks/>
        public string ToDate { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
		public string url { get; set; }
    }
}
