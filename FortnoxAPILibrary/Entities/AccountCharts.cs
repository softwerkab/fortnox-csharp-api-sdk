using System;
using System.Collections.Generic;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
    [Serializable]
	public class AccountCharts
	{
        /// <remarks/>
		public List<AccountChartSubset> AccountChartSubset { get; set; }
    }

	/// <remarks/>
    [Serializable]
	public class AccountChartSubset
	{
		/// <remarks/>
		public string Name { get; set; }
    }
}
