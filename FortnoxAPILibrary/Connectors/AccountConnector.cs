using System;
using System.Collections.Generic;

namespace FortnoxAPILibrary.Connectors
{
    public interface IAccountConnector : IEntityConnector<Sort.By.Account>
    {
        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        string SRU { get; set; }

        /// <summary>
        /// Find an account based on account number
        /// </summary>
        /// <param name="accountNumber">Tha account number to find</param>
        /// <returns>The found account</returns>
        Account Get(string accountNumber);

        /// <summary>
        /// Updates an account
        /// </summary>
        /// <param name="account">Account to update</param>
        /// <returns>The updated account</returns>
        Account Update(Account account);

        /// <summary>
        /// Create a new account
        /// </summary>
        /// <param name="account">The account to create</param>
        /// <returns>The created account</returns>
        Account Create(Account account);

        /// <summary>
        /// Deletes an account
        /// </summary>
        /// <param name="accountNumber">The account number to delete</param>
        /// <returns>If the account was deleted or not</returns>
        void Delete(string accountNumber);

        /// <summary>
        /// Gets at list of accounts
        /// </summary>
        /// <returns>A list of accounts</returns>
        Accounts Find();
    }

    /// <remarks/>
	public class AccountConnector : FinancialYearBasedEntityConnector<Account, Accounts, Sort.By.Account>, IAccountConnector
    {
		/// <remarks/>
		public enum CostCenterSettingsValue
		{
			/// <remarks/>
			ALLOWED,
			/// <remarks/>
			NOTALLOWED,
			/// <remarks/>
			MANDATORY
		}

		/// <remarks/>
		public enum ProjectSettingsValue
		{
			/// <remarks/>
			ALLOWED,
			/// <remarks/>
			NOTALLOWED,
			/// <remarks/>
			MANDATORY
		}

		/// <remarks/>
		public enum TransactionInfoSettingsValue
		{
			/// <remarks/>
			ALLOWED,
			/// <remarks/>
			NOTALLOWED,
			/// <remarks/>
			MANDATORY
		}

		/// <summary>
		/// Use with Find() to limit the search result
		/// </summary>
        [FilterProperty]
		public string SRU { get; set; }

		/// <remarks/>
		public AccountConnector()
		{
			base.Resource = "accounts";
		}

		/// <summary>
		/// Find an account based on account number
		/// </summary>
		/// <param name="accountNumber">Tha account number to find</param>
		/// <returns>The found account</returns>
		public Account Get(string accountNumber)
		{
			return base.BaseGet(accountNumber);
		}

		/// <summary>
		/// Updates an account
		/// </summary>
		/// <param name="account">Account to update</param>
		/// <returns>The updated account</returns>
		public Account Update(Account account)
		{
			return base.BaseUpdate(account, account.Number.ToString());
		}

		/// <summary>
		/// Create a new account
		/// </summary>
		/// <param name="account">The account to create</param>
		/// <returns>The created account</returns>
		public Account Create(Account account)
		{
			return base.BaseCreate(account);
		}

		/// <summary>
		/// Deletes an account
		/// </summary>
		/// <param name="accountNumber">The account number to delete</param>
		/// <returns>If the account was deleted or not</returns>
		public void Delete(string accountNumber)
		{
			base.BaseDelete(accountNumber);
		}

		/// <summary>
		/// Gets at list of accounts
		/// </summary>
		/// <returns>A list of accounts</returns>
		public Accounts Find()
		{
			return base.BaseFind();
		}
	}
}
