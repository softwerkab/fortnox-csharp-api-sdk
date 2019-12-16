using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class FinancialYearConnector : EntityConnector<FinancialYear, EntityCollection<FinancialYearSubset>, Sort.By.FinancialYear?>
	{
		/// <summary>
		/// Use with Find() to limit the search result
		/// </summary>
        [SearchParameter]
		public string Date { get; set; }

		/// <remarks/>
		public FinancialYearConnector()
		{
			Resource = "financialyears";
		}

		/// <summary>
		/// Gets a financial year based on id
		/// </summary>
		/// <param name="id">The id of the financial year to find</param>
		/// <returns></returns>
		public FinancialYear Get(int id)
		{
			return BaseGet(id.ToString());
		}

		/// <summary>
		/// Creates a new financial year
		/// </summary>
		/// <param name="financialYear">The financial year to create</param>
		/// <returns>The created financial year</returns>
		public FinancialYear Create(FinancialYear financialYear)
		{
			return BaseCreate(financialYear);
		}

		/// <summary>
		/// Gets a list of financial years
		/// </summary>
		/// <returns>A list of financial years</returns>
		public EntityCollection<FinancialYearSubset> Find()
		{
			return BaseFind();
		}
    }
}
