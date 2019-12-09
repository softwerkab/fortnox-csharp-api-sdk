using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
	[Entity(SingularName = "AccountChart", PluralName = "AccountCharts")]
	public class AccountChart : AccountChartSubset
	{
        /// <remarks/>
        [JsonProperty]
        public string Name { get; set; }
    }

	/// <remarks/>
    [Entity(SingularName = "AccountChart", PluralName = "AccountCharts")]
    public class AccountChartSubset
	{
		/// <remarks/>
		[JsonProperty]
		public string Name { get; set; }
    }
}
