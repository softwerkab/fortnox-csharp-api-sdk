using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class AccountConnector : FinancialYearBasedEntityConnector<Account, EntityCollection<AccountSubset>, Sort.By.Account?>
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
			Resource = "accounts";
		}

		/// <summary>
		/// Find an account based on account number
		/// </summary>
		/// <param name="accountNumber">Tha account number to find</param>
		/// <returns>The found account</returns>
		public Account Get(string accountNumber)
		{
			return BaseGet(accountNumber);
		}

		/// <summary>
		/// Updates an account
		/// </summary>
		/// <param name="account">Account to update</param>
		/// <returns>The updated account</returns>
		public Account Update(Account account)
		{
			return BaseUpdate(account, account.Number);
		}

		/// <summary>
		/// Create a new account
		/// </summary>
		/// <param name="account">The account to create</param>
		/// <returns>The created account</returns>
		public Account Create(Account account)
		{
			return BaseCreate(account);
		}

		/// <summary>
		/// Deletes an account
		/// </summary>
		/// <param name="accountNumber">The account number to delete</param>
		/// <returns>If the account was deleted or not</returns>
		public void Delete(string accountNumber)
		{
			BaseDelete(accountNumber);
		}

		/// <summary>
		/// Gets at list of accounts
		/// </summary>
		/// <returns>A list of accounts</returns>
		public EntityCollection<AccountSubset> Find()
		{
			return BaseFind();
		}
	}
}
