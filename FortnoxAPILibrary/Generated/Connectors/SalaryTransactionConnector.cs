using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class SalaryTransactionConnector : EntityConnector<SalaryTransaction, EntityCollection<SalaryTransactionSubset>, Sort.By.SalaryTransaction?>
	{
	    /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter("filter")]
		public Filter.SalaryTransaction FilterBy { get; set; }


		/// <remarks/>
		public SalaryTransactionConnector()
		{
			Resource = "salarytransactions";
		}

		/// <summary>
		/// Find a salaryTransaction based on salaryTransactionnumber
		/// </summary>
		/// <param name="salaryTransactionNumber">The salaryTransactionnumber to find</param>
		/// <returns>The found salaryTransaction</returns>
		public SalaryTransaction Get(string salaryTransactionNumber)
		{
			return BaseGet(salaryTransactionNumber);
		}

		/// <summary>
		/// Updates a salaryTransaction
		/// </summary>
		/// <param name="salaryTransaction">The salaryTransaction to update</param>
		/// <returns>The updated salaryTransaction</returns>
		public SalaryTransaction Update(SalaryTransaction salaryTransaction)
		{
			return BaseUpdate(salaryTransaction, salaryTransaction.SalaryTransactionNumber);
		}

		/// <summary>
		/// Create a new salaryTransaction
		/// </summary>
		/// <param name="salaryTransaction">The salaryTransaction to create</param>
		/// <returns>The created salaryTransaction</returns>
		public SalaryTransaction Create(SalaryTransaction salaryTransaction)
		{
			return BaseCreate(salaryTransaction);
		}

		/// <summary>
		/// Deletes a salaryTransaction
		/// </summary>
		/// <param name="salaryTransactionNumber">The salaryTransactionnumber to delete</param>
		public void Delete(string salaryTransactionNumber)
		{
			BaseDelete(salaryTransactionNumber);
		}

		/// <summary>
		/// Gets a list of salaryTransactions
		/// </summary>
		/// <returns>A list of salaryTransactions</returns>
		public EntityCollection<SalaryTransactionSubset> Find()
		{
			return BaseFind();
		}
	}
}
