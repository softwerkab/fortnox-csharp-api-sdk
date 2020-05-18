using FortnoxAPILibrary.Entities;

using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class SalaryTransactionConnector : EntityConnector<SalaryTransaction, EntityCollection<SalaryTransactionSubset>, Sort.By.SalaryTransaction?>, ISalaryTransactionConnector
	{
	    /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter("filter")]
		public Filter.SalaryTransaction? FilterBy { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
        public string EmployeeId { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
        public string Date { get; set; }

		/// <remarks/>
		public SalaryTransactionConnector()
		{
			Resource = "salarytransactions";
		}
		/// <summary>
		/// Find a salaryTransaction based on id
		/// </summary>
		/// <param name="id">Identifier of the salaryTransaction to find</param>
		/// <returns>The found salaryTransaction</returns>
		public SalaryTransaction Get(int? id)
		{
			return GetAsync(id).Result;
		}

		/// <summary>
		/// Updates a salaryTransaction
		/// </summary>
		/// <param name="salaryTransaction">The salaryTransaction to update</param>
		/// <returns>The updated salaryTransaction</returns>
		public SalaryTransaction Update(SalaryTransaction salaryTransaction)
		{
			return UpdateAsync(salaryTransaction).Result;
		}

		/// <summary>
		/// Creates a new salaryTransaction
		/// </summary>
		/// <param name="salaryTransaction">The salaryTransaction to create</param>
		/// <returns>The created salaryTransaction</returns>
		public SalaryTransaction Create(SalaryTransaction salaryTransaction)
		{
			return CreateAsync(salaryTransaction).Result;
		}

		/// <summary>
		/// Deletes a salaryTransaction
		/// </summary>
		/// <param name="id">Identifier of the salaryTransaction to delete</param>
		public void Delete(int? id)
		{
			DeleteAsync(id).Wait();
		}

		/// <summary>
		/// Gets a list of salaryTransactions
		/// </summary>
		/// <returns>A list of salaryTransactions</returns>
		public EntityCollection<SalaryTransactionSubset> Find()
		{
			return FindAsync().Result;
		}

		public async Task<EntityCollection<SalaryTransactionSubset>> FindAsync()
		{
			return await BaseFind();
		}
		public async Task DeleteAsync(int? id)
		{
			await BaseDelete(id.ToString());
		}
		public async Task<SalaryTransaction> CreateAsync(SalaryTransaction salaryTransaction)
		{
			return await BaseCreate(salaryTransaction);
		}
		public async Task<SalaryTransaction> UpdateAsync(SalaryTransaction salaryTransaction)
		{
			return await BaseUpdate(salaryTransaction, salaryTransaction.SalaryRow.ToString());
		}
		public async Task<SalaryTransaction> GetAsync(int? id)
		{
			return await BaseGet(id.ToString());
		}
	}
}
