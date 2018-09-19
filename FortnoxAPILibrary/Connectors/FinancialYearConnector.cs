using System.Collections.Generic;

namespace FortnoxAPILibrary.Connectors
{
    public interface IFinancialYearConnector : IEntityConnector<Sort.By.FinancialYear>
    {
        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        string Date { get; set; }

        /// <summary>
        /// Gets a financial year based on id
        /// </summary>
        /// <param name="id">The id of the financial year to find</param>
        /// <returns></returns>
        FinancialYear Get(int id);

        /// <summary>
        /// Creates a new financial year
        /// </summary>
        /// <param name="financialYear">The financial year to create</param>
        /// <returns>The created financial year</returns>
        FinancialYear Create(FinancialYear financialYear);

        /// <summary>
        /// Gets a list of financial years
        /// </summary>
        /// <returns>A list of financial years</returns>
        FinancialYears Find();
    }

    /// <remarks/>
	public class FinancialYearConnector : EntityConnector<FinancialYear, FinancialYears, Sort.By.FinancialYear>, IFinancialYearConnector
    {
		/// <summary>
		/// Use with Find() to limit the search result
		/// </summary>
        [FilterProperty]
		public string Date { get; set; }

		/// <remarks/>
		public FinancialYearConnector()
		{
			base.Resource = "financialyears";
		}

		/// <summary>
		/// Gets a financial year based on id
		/// </summary>
		/// <param name="id">The id of the financial year to find</param>
		/// <returns></returns>
		public FinancialYear Get(int id)
		{
			return base.BaseGet(id.ToString());
		}

		/// <summary>
		/// Creates a new financial year
		/// </summary>
		/// <param name="financialYear">The financial year to create</param>
		/// <returns>The created financial year</returns>
		public FinancialYear Create(FinancialYear financialYear)
		{
			return base.BaseCreate(financialYear);
		}

		/// <summary>
		/// Gets a list of financial years
		/// </summary>
		/// <returns>A list of financial years</returns>
		public FinancialYears Find()
		{
			return base.BaseFind();
		}

		/// <remarks/>
		public enum AccountingMethod
		{
			/// <remarks/>
			ACCRUAL,
			/// <remarks/>
			CASH
		}
	}
}
