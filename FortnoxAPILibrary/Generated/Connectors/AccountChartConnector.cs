using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class AccountChartConnector : EntityConnector<AccountChart, EntityCollection<AccountChartSubset>, Sort.By.AccountChart?>
	{
	    /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter("filter")]
		public Filter.AccountChart FilterBy { get; set; }


		/// <remarks/>
		public AccountChartConnector()
		{
			Resource = "accountcharts";
		}

		/// <summary>
		/// Find a accountChart based on accountChartnumber
		/// </summary>
		/// <param name="accountChartNumber">The accountChartnumber to find</param>
		/// <returns>The found accountChart</returns>
		public AccountChart Get(string accountChartNumber)
		{
			return BaseGet(accountChartNumber);
		}

		/// <summary>
		/// Updates a accountChart
		/// </summary>
		/// <param name="accountChart">The accountChart to update</param>
		/// <returns>The updated accountChart</returns>
		public AccountChart Update(AccountChart accountChart)
		{
			return BaseUpdate(accountChart, accountChart.AccountChartNumber);
		}

		/// <summary>
		/// Create a new accountChart
		/// </summary>
		/// <param name="accountChart">The accountChart to create</param>
		/// <returns>The created accountChart</returns>
		public AccountChart Create(AccountChart accountChart)
		{
			return BaseCreate(accountChart);
		}

		/// <summary>
		/// Deletes a accountChart
		/// </summary>
		/// <param name="accountChartNumber">The accountChartnumber to delete</param>
		public void Delete(string accountChartNumber)
		{
			BaseDelete(accountChartNumber);
		}

		/// <summary>
		/// Gets a list of accountCharts
		/// </summary>
		/// <returns>A list of accountCharts</returns>
		public EntityCollection<AccountChartSubset> Find()
		{
			return BaseFind();
		}
	}
}
