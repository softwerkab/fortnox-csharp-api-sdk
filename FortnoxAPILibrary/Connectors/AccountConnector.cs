using System.Collections.Generic;
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
		public Account Get(long? id, long? financialYearId = null)
		{
			return GetAsync(id, financialYearId).Result;
		}

        /// <summary>
        /// Updates a account
        /// </summary>
        /// <param name="account">The account to update</param>
        /// <param name="financialYearId"></param>
        /// <returns>The updated account</returns>
        public Account Update(Account account, long? financialYearId = null)
		{
			return UpdateAsync(account, financialYearId).Result;
		}

        /// <summary>
        /// Creates a new account
        /// </summary>
        /// <param name="account">The account to create</param>
        /// <param name="financialYearId">Financial year for account to be created in</param>
        /// <returns>The created account</returns>
        public Account Create(Account account, long? financialYearId = null)
		{
			return CreateAsync(account, financialYearId).Result;
		}

        /// <summary>
        /// Deletes a account
        /// </summary>
        /// <param name="id">Identifier of the account to delete</param>
        /// <param name="financialYearId"></param>
        public void Delete(long? id, long? financialYearId = null)
		{
            DeleteAsync(id, financialYearId).Wait();
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
			return await BaseFind().ConfigureAwait(false);
		}
		public async Task DeleteAsync(long? id, long? financialYearId = null)
		{
            if (financialYearId != null)
            {
                ParametersInjection = new Dictionary<string, string>();
                ParametersInjection.Add("financialyear", financialYearId.ToString());
            }

			await BaseDelete(id.ToString()).ConfigureAwait(false);
		}
		public async Task<Account> CreateAsync(Account account, long? financialYearId = null)
		{
            if (financialYearId != null)
            {
                ParametersInjection = new Dictionary<string, string>();
                ParametersInjection.Add("financialyear", financialYearId.ToString());
            }

            return await BaseCreate(account).ConfigureAwait(false);
		}
		public async Task<Account> UpdateAsync(Account account, long? financialYearId = null)
		{
            if (financialYearId != null)
            {
                ParametersInjection = new Dictionary<string, string>();
                ParametersInjection.Add("financialyear", financialYearId.ToString());
            }

			return await BaseUpdate(account, account.Number.ToString()).ConfigureAwait(false);
		}
		public async Task<Account> GetAsync(long? id, long? financialYearId = null)
		{
            if (financialYearId != null)
            {
                ParametersInjection = new Dictionary<string, string>();
                ParametersInjection.Add("financialyear", financialYearId.ToString());
            }

			return await BaseGet(id.ToString()).ConfigureAwait(false);
		}
	}
}
