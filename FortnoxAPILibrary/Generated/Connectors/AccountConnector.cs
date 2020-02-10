using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class AccountConnector : EntityConnector<Account, EntityCollection<AccountSubset>, Sort.By.Account?>
	{
	    /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter("filter")]
		public Filter.Account FilterBy { get; set; }


        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string SRU { get; set; }

		/// <remarks/>
		public AccountConnector()
		{
			Resource = "accounts";
		}

		/// <summary>
		/// Find a account based on accountnumber
		/// </summary>
		/// <param name="accountNumber">The accountnumber to find</param>
		/// <returns>The found account</returns>
		public Account Get(string accountNumber)
		{
			return BaseGet(accountNumber);
		}

		/// <summary>
		/// Updates a account
		/// </summary>
		/// <param name="account">The account to update</param>
		/// <returns>The updated account</returns>
		public Account Update(Account account)
		{
			return BaseUpdate(account, account.AccountNumber);
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
		/// Deletes a account
		/// </summary>
		/// <param name="accountNumber">The accountnumber to delete</param>
		public void Delete(string accountNumber)
		{
			BaseDelete(accountNumber);
		}

		/// <summary>
		/// Gets a list of accounts
		/// </summary>
		/// <returns>A list of accounts</returns>
		public EntityCollection<AccountSubset> Find()
		{
			return BaseFind();
		}
	}
}
