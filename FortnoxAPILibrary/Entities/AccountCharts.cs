using System;
using System.Collections.Generic;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
	[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
	public class AccountCharts
	{
        /// <remarks/>
		[JsonProperty]
		public List<AccountChartSubset> AccountChartSubset { get; set; }
    }

	/// <remarks/>
	[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
	public class AccountChartSubset
	{
		/// <remarks/>
		[JsonProperty]
		public string Name { get; set; }
    }
}
