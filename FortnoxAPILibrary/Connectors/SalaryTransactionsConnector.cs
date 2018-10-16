using System;
using System.Globalization;
using FortnoxAPILibrary.Entities;

namespace FortnoxAPILibrary.Connectors
{
    /// <summary>
    /// Interface of connector to salary transactions endpoint
    /// </summary>
    public interface ISalaryTransactionsConnector : IEntityConnector<Sort.By.SalaryTransaction>
    {
        /// <summary>
        /// Gets a salary transaction
        /// </summary>
        /// <param name="salaryRow">The salary row id of the salary transaction to find</param>
        /// <returns>A salary transaction</returns>
        SalaryTransaction Get(int salaryRow);

        /// <summary>
        /// Updates a salary transaction
        /// </summary>
        /// <param name="salaryTransaction">The salary transaction to update</param>
        /// <returns>The updated salary transaction</returns>
        SalaryTransaction Update(SalaryTransaction salaryTransaction);

        /// <summary>
        /// Creates a new salary transaction
        /// </summary>
        /// <param name="salaryTransaction">The salary transaction to create</param>
        /// <returns>The created salary transaction</returns>
        SalaryTransaction Create(SalaryTransaction salaryTransaction);

        /// <summary>
        /// Gets a list of salary transactions
        /// </summary>
        /// <returns>A list of salary transactions</returns>
        SalaryTransactions Find();

        /// <summary>
        /// Deletes a salary transaction
        /// </summary>
        /// <param name="salaryRow">The salary row id to delete</param>
        void Delete(int salaryRow);
    }

    /// <summary>
    /// Implementation of connector to salary transactions endpoint
    /// </summary>
    public class SalaryTransactionsConnector : EntityConnector<SalaryTransaction, SalaryTransactions, Sort.By.SalaryTransaction>, ISalaryTransactionsConnector
    {
        /// <inheritdoc />
        /// <summary>
        /// Implementation of connector to salary transactions endpoint
        /// </summary>
        public SalaryTransactionsConnector()
        {
            Resource = "salarytransactions";
        }

        /// <inheritdoc />
        public SalaryTransaction Get(int salaryRow)
        {
            return BaseGet(salaryRow.ToString(CultureInfo.InvariantCulture));
        }

        /// <inheritdoc />
        public SalaryTransaction Update(SalaryTransaction salaryTransaction)
        {
            if(!salaryTransaction.SalaryRow.HasValue)
                throw new ArgumentException("Salary transaction must have a SalaryRow to be able to update", nameof(salaryTransaction.SalaryRow));

            return BaseUpdate(salaryTransaction, salaryTransaction.SalaryRow.Value.ToString(CultureInfo.InvariantCulture));
        }

        /// <inheritdoc />
        public SalaryTransaction Create(SalaryTransaction salaryTransaction)
        {
            return BaseCreate(salaryTransaction);
        }

        /// <inheritdoc />
        public SalaryTransactions Find()
        {
            return BaseFind();
        }

        /// <inheritdoc />
        public void Delete(int salaryRow)
        {
            BaseDelete(salaryRow.ToString(CultureInfo.InvariantCulture));
        }
    }
}