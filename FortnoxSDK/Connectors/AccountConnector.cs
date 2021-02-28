using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Requests;
using Fortnox.SDK.Search;
using Fortnox.SDK.Utility;

// ReSharper disable UnusedMember.Global

namespace Fortnox.SDK.Connectors
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
        /// <param name="finYearID"></param>
        /// <returns>The found account</returns>
        public Account Get(long? id, long? finYearID = null)
		{
			return GetAsync(id, finYearID).GetResult();
		}

        /// <summary>
        /// Updates a account
        /// </summary>
        /// <param name="account">The account to update</param>
        /// <param name="finYearID"></param>
        /// <returns>The updated account</returns>
        public Account Update(Account account, long? finYearID = null)
		{
			return UpdateAsync(account, finYearID).GetResult();
		}

        /// <summary>
        /// Creates a new account
        /// </summary>
        /// <param name="account">The account to create</param>
        /// <param name="finYearID"></param>
        /// <returns>The created account</returns>
        public Account Create(Account account, long? finYearID = null)
		{
			return CreateAsync(account, finYearID).GetResult();
		}

        /// <summary>
        /// Deletes a account
        /// </summary>
        /// <param name="id">Identifier of the account to delete</param>
        /// <param name="finYearID"></param>
        public void Delete(long? id, long? finYearID = null)
		{
			DeleteAsync(id, finYearID).GetResult();
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

		public async Task DeleteAsync(long? id, long? finYearID = null)
		{
            var request = new BaseRequest()
            {
                Resource = Resource,
                Indices = new List<string>() { id.ToString() },
                Method = HttpMethod.Delete
            };

            if (finYearID != null)
                request.Parameters.Add("financialyear", finYearID.ToString());

			await SendAsync(request).ConfigureAwait(false);
		}

		public async Task<Account> CreateAsync(Account account, long? finYearID = null)
		{
            var request = new EntityRequest<Account>()
            {
                Resource = Resource,
                Method = HttpMethod.Post,
                Entity = account
            };

            if (finYearID != null)
                request.Parameters.Add("financialyear", finYearID.ToString());

			return await SendAsync(request).ConfigureAwait(false);
		}

		public async Task<Account> UpdateAsync(Account account, long? finYearID = null)
		{
            var request = new EntityRequest<Account>()
            {
                Resource = Resource,
                Indices = new List<string>() { account.Number.ToString() },
                Method = HttpMethod.Put,
                Entity = account
            };

            if (finYearID != null)
                request.Parameters.Add("financialyear", finYearID.ToString());

            return await SendAsync(request).ConfigureAwait(false);
	    }

		public async Task<Account> GetAsync(long? id, long? finYearID = null)
		{ 
            //return await BaseGet(id.ToString()).ConfigureAwait(false);
            var request = new EntityRequest<Account>()
            {
                Resource = Resource,
                Indices = new List<string>() { id.ToString() },
                Method = HttpMethod.Get,
            };
			if (finYearID != null)
				request.Parameters.Add("financialyear", finYearID.ToString());

            return await SendAsync(request).ConfigureAwait(false);
		}
	}
}
