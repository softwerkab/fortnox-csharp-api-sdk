using FortnoxAPILibrary.Entities;

using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class AccountConnector : SearchableEntityConnector<Account, AccountSubset, AccountSearch>, IAccountConnector
	{


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
		public Account Get(long? id)
		{
			return GetAsync(id).GetResult();
		}

		/// <summary>
		/// Updates a account
		/// </summary>
		/// <param name="account">The account to update</param>
		/// <returns>The updated account</returns>
		public Account Update(Account account)
		{
			return UpdateAsync(account).GetResult();
		}

		/// <summary>
		/// Creates a new account
		/// </summary>
		/// <param name="account">The account to create</param>
		/// <returns>The created account</returns>
		public Account Create(Account account)
		{
			return CreateAsync(account).GetResult();
		}

		/// <summary>
		/// Deletes a account
		/// </summary>
		/// <param name="id">Identifier of the account to delete</param>
		public void Delete(long? id)
		{
			DeleteAsync(id).GetResult();
		}

		/// <summary>
		/// Gets a list of accounts
		/// </summary>
		/// <returns>A list of accounts</returns>
		public EntityCollection<AccountSubset> Find(AccountSearch searchSettings)
		{
			return FindAsync(searchSettings).GetResult();
		}

		public async Task<EntityCollection<AccountSubset>> FindAsync(AccountSearch searchSettings)
		{
			return await BaseFind(searchSettings).ConfigureAwait(false);
		}
		public async Task DeleteAsync(long? id)
		{
			await BaseDelete(id.ToString()).ConfigureAwait(false);
		}
		public async Task<Account> CreateAsync(Account account)
		{
			return await BaseCreate(account).ConfigureAwait(false);
		}
		public async Task<Account> UpdateAsync(Account account)
		{
			return await BaseUpdate(account, account.Number.ToString()).ConfigureAwait(false);
		}
		public async Task<Account> GetAsync(long? id)
		{
			return await BaseGet(id.ToString()).ConfigureAwait(false);
		}
	}
}
