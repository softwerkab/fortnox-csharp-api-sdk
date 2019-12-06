using System;
using System.Collections.Generic;
using System.ComponentModel;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
	public class Currencies
	{
		/// <remarks/>
		public List<CurrencySubset> CurrencySubset { get; set; }
    }

	/// <remarks/>
	public class CurrencySubset
	{
        /// <remarks/>
		public string BuyRate { get; set; }

        /// <remarks/>
        public string Code { get; set; }

        /// <remarks/>
        public string Date { get; set; }

        /// <remarks/>
        public string Description { get; set; }

        /// <remarks/>
        public string SellRate { get; set; }

        /// <remarks/>
        public string Unit { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
		[ReadOnly(true)]
		public string url { get; set; }
    }
}
