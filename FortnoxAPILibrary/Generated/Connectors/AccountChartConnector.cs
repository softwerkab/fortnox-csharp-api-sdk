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
		public Filter.AccountChart? FilterBy { get; set; }


		/// <remarks/>
		public AccountChartConnector()
		{
			Resource = "accountcharts";
		}

		/// <summary>
		/// Find a accountChart based on id
		/// </summary>
		/// <param name="id">Identifier of the accountChart to find</param>
		/// <returns>The found accountChart</returns>
		public AccountChart Get(string id)
		{
			return BaseGet(id);
		}

		/// <summary>
		/// Updates a accountChart
		/// </summary>
		/// <param name="accountChart">The accountChart to update</param>
		/// <returns>The updated accountChart</returns>
		public AccountChart Update(AccountChart accountChart)
		{
			return BaseUpdate(accountChart, accountChart.Name.ToString());
		}

		/// <summary>
		/// Creates a new accountChart
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
		/// <param name="id">Identifier of the accountChart to delete</param>
		public void Delete(string id)
		{
			BaseDelete(id);
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
