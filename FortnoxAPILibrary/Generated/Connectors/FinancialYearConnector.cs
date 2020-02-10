using FortnoxAPILibrary;
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
        [SearchParameter("filter")]
		public Filter.FinancialYear FilterBy { get; set; }


        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string FromDate { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string ToDate { get; set; }

		/// <remarks/>
		public FinancialYearConnector()
		{
			Resource = "financialyears";
		}

		/// <summary>
		/// Find a financialYear based on financialYearnumber
		/// </summary>
		/// <param name="financialYearNumber">The financialYearnumber to find</param>
		/// <returns>The found financialYear</returns>
		public FinancialYear Get(string financialYearNumber)
		{
			return BaseGet(financialYearNumber);
		}

		/// <summary>
		/// Updates a financialYear
		/// </summary>
		/// <param name="financialYear">The financialYear to update</param>
		/// <returns>The updated financialYear</returns>
		public FinancialYear Update(FinancialYear financialYear)
		{
			return BaseUpdate(financialYear, financialYear.FinancialYearNumber);
		}

		/// <summary>
		/// Create a new financialYear
		/// </summary>
		/// <param name="financialYear">The financialYear to create</param>
		/// <returns>The created financialYear</returns>
		public FinancialYear Create(FinancialYear financialYear)
		{
			return BaseCreate(financialYear);
		}

		/// <summary>
		/// Deletes a financialYear
		/// </summary>
		/// <param name="financialYearNumber">The financialYearnumber to delete</param>
		public void Delete(string financialYearNumber)
		{
			BaseDelete(financialYearNumber);
		}

		/// <summary>
		/// Gets a list of financialYears
		/// </summary>
		/// <returns>A list of financialYears</returns>
		public EntityCollection<FinancialYearSubset> Find()
		{
			return BaseFind();
		}
	}
}
