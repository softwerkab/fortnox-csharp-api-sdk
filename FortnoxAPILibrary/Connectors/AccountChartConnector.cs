using FortnoxAPILibrary.Entities;

using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class AccountChartConnector : SearchableEntityConnector<AccountChart, AccountChart, AccountChartSearch>, IAccountChartConnector
	{

		/// <remarks/>
		public AccountChartConnector()
		{
			Resource = "accountcharts";
		}

		/// <summary>
		/// Gets a list of accountCharts
		/// </summary>
		/// <returns>A list of accountCharts</returns>
		public EntityCollection<AccountChart> Find(AccountChartSearch searchSettings)
		{
			return FindAsync(searchSettings).GetResult();
		}

		public async Task<EntityCollection<AccountChart>> FindAsync(AccountChartSearch searchSettings)
		{
			return await BaseFind(searchSettings).ConfigureAwait(false);
		}
	}
}
