using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
	[Entity(SingularName = "AccountChart", PluralName = "AccountCharts")]
	public class AccountChart 
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
