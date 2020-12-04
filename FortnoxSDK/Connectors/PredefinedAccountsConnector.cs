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
	public class PredefinedAccountsConnector : SearchableEntityConnector<PredefinedAccount, PredefinedAccount, PredefinedAccountsSearch>, IPredefinedAccountsConnector
	{


		/// <remarks/>
		public PredefinedAccountsConnector()
		{
			Resource = "predefinedaccounts";
		}

		/// <summary>
		/// Find a predefinedAccount based on id
		/// </summary>
		/// <param name="id">Identifier of the predefinedAccount to find</param>
		/// <returns>The found predefinedAccount</returns>
		public PredefinedAccount Get(string id)
		{
			return GetAsync(id).GetResult();
		}

		/// <summary>
		/// Updates a predefinedAccounts
		/// </summary>
		/// <param name="predefinedAccount">The predefinedAccount to update</param>
		/// <returns>The updated predefinedAccount</returns>
		public PredefinedAccount Update(PredefinedAccount predefinedAccount)
		{
			return UpdateAsync(predefinedAccount).GetResult();
		}

        /// <summary>
		/// Gets a list of predefinedAccounts
		/// </summary>
		/// <returns>A list of predefinedAccounts</returns>
		public EntityCollection<PredefinedAccount> Find(PredefinedAccountsSearch searchSettings)
		{
			return FindAsync(searchSettings).GetResult();
		}

		public async Task<EntityCollection<PredefinedAccount>> FindAsync(PredefinedAccountsSearch searchSettings)
		{
			return await BaseFind(searchSettings).ConfigureAwait(false);
		}
		public async Task<PredefinedAccount> UpdateAsync(PredefinedAccount predefinedAccount)
		{
			return await BaseUpdate(predefinedAccount, predefinedAccount.Name).ConfigureAwait(false);
		}
		public async Task<PredefinedAccount> GetAsync(string id)
		{
			return await BaseGet(id).ConfigureAwait(false);
		}
	}
}
