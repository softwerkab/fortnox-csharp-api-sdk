using FortnoxAPILibrary.Entities;

using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class AccountChartConnector : EntityConnector<AccountChart, EntityCollection<AccountChart>, Sort.By.AccountChart?>, IAccountChartConnector
	{
	    /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter("filter")]
		public Filter.AccountChart? FilterBy { get; set; }

		/// <remarks/>
		public AccountChartConnector()
		{
			Resource = "accountcharts";
		}

		/// <summary>
		/// Gets a list of accountCharts
		/// </summary>
		/// <returns>A list of accountCharts</returns>
		public EntityCollection<AccountChart> Find()
		{
			return FindAsync().Result;
		}

		public async Task<EntityCollection<AccountChart>> FindAsync()
		{
			return await BaseFind();
		}
	}
}
