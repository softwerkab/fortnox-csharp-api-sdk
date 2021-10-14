using System.Threading.Tasks;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Search;
using Fortnox.SDK.Utility;

// ReSharper disable UnusedMember.Global

namespace Fortnox.SDK.Connectors
{
    /// <remarks/>
    internal class SalaryTransactionConnector : SearchableEntityConnector<SalaryTransaction, SalaryTransactionSubset, SalaryTransactionSearch>, ISalaryTransactionConnector
    {

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
        public SalaryTransaction Get(long? id)
        {
            return GetAsync(id).GetResult();
        }

        /// <summary>
        /// Updates a salaryTransaction
        /// </summary>
        /// <param name="salaryTransaction">The salaryTransaction to update</param>
        /// <returns>The updated salaryTransaction</returns>
        public SalaryTransaction Update(SalaryTransaction salaryTransaction)
        {
            return UpdateAsync(salaryTransaction).GetResult();
        }

        /// <summary>
        /// Creates a new salaryTransaction
        /// </summary>
        /// <param name="salaryTransaction">The salaryTransaction to create</param>
        /// <returns>The created salaryTransaction</returns>
        public SalaryTransaction Create(SalaryTransaction salaryTransaction)
        {
            return CreateAsync(salaryTransaction).GetResult();
        }

        /// <summary>
        /// Deletes a salaryTransaction
        /// </summary>
        /// <param name="id">Identifier of the salaryTransaction to delete</param>
        public void Delete(long? id)
        {
            DeleteAsync(id).GetResult();
        }

        /// <summary>
        /// Gets a list of salaryTransactions
        /// </summary>
        /// <returns>A list of salaryTransactions</returns>
        public EntityCollection<SalaryTransactionSubset> Find(SalaryTransactionSearch searchSettings)
        {
            return FindAsync(searchSettings).GetResult();
        }

        public async Task<EntityCollection<SalaryTransactionSubset>> FindAsync(SalaryTransactionSearch searchSettings)
        {
            return await BaseFind(searchSettings).ConfigureAwait(false);
        }
        public async Task DeleteAsync(long? id)
        {
            await BaseDelete(id.ToString()).ConfigureAwait(false);
        }
        public async Task<SalaryTransaction> CreateAsync(SalaryTransaction salaryTransaction)
        {
            return await BaseCreate(salaryTransaction).ConfigureAwait(false);
        }
        public async Task<SalaryTransaction> UpdateAsync(SalaryTransaction salaryTransaction)
        {
            return await BaseUpdate(salaryTransaction, salaryTransaction.SalaryRow.ToString()).ConfigureAwait(false);
        }
        public async Task<SalaryTransaction> GetAsync(long? id)
        {
            return await BaseGet(id.ToString()).ConfigureAwait(false);
        }
    }
}
