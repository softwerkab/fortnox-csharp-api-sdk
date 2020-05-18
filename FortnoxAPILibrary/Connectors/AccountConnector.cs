using FortnoxAPILibrary.Entities;

using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class AccountConnector : EntityConnector<Account, EntityCollection<AccountSubset>, Sort.By.Account?>, IAccountConnector
	{
	    /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter("filter")]
		public Filter.Account? FilterBy { get; set; }


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
		/// Find a account based on id
		/// </summary>
		/// <param name="id">Identifier of the account to find</param>
		/// <returns>The found account</returns>
		public Account Get(int? id)
		{
			return GetAsync(id).Result;
		}

		/// <summary>
		/// Updates a account
		/// </summary>
		/// <param name="account">The account to update</param>
		/// <returns>The updated account</returns>
		public Account Update(Account account)
		{
			return UpdateAsync(account).Result;
		}

		/// <summary>
		/// Creates a new account
		/// </summary>
		/// <param name="account">The account to create</param>
		/// <returns>The created account</returns>
		public Account Create(Account account)
		{
			return CreateAsync(account).Result;
		}

		/// <summary>
		/// Deletes a account
		/// </summary>
		/// <param name="id">Identifier of the account to delete</param>
		public void Delete(int? id)
		{
			DeleteAsync(id).Wait();
		}

		/// <summary>
		/// Gets a list of accounts
		/// </summary>
		/// <returns>A list of accounts</returns>
		public EntityCollection<AccountSubset> Find()
		{
			return FindAsync().Result;
		}

		public async Task<EntityCollection<AccountSubset>> FindAsync()
		{
			return await BaseFind();
		}
		public async Task DeleteAsync(int? id)
		{
			await BaseDelete(id.ToString());
		}
		public async Task<Account> CreateAsync(Account account)
		{
			return await BaseCreate(account);
		}
		public async Task<Account> UpdateAsync(Account account)
		{
			return await BaseUpdate(account, account.Number.ToString());
		}
		public async Task<Account> GetAsync(int? id)
		{
			return await BaseGet(id.ToString());
		}
	}
}
