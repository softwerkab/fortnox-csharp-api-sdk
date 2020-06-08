using FortnoxAPILibrary.Entities;

using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
	/// <remarks/>
	public class PredefinedAccountsConnector : EntityConnector<PredefinedAccount, EntityCollection<PredefinedAccount>, Sort.By.PredefinedAccounts?>, IPredefinedAccountsConnector
	{
		/// <summary>
		/// Use with Find() to limit the search result
		/// </summary>
		[SearchParameter("filter")]
		public Filter.PredefinedAccounts? FilterBy { get; set; }


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
			return GetAsync(id).Result;
		}

		/// <summary>
		/// Updates a predefinedAccounts
		/// </summary>
		/// <param name="predefinedAccount">The predefinedAccount to update</param>
		/// <returns>The updated predefinedAccount</returns>
		public PredefinedAccount Update(PredefinedAccount predefinedAccount)
		{
			return UpdateAsync(predefinedAccount).Result;
		}

        /// <summary>
		/// Gets a list of predefinedAccounts
		/// </summary>
		/// <returns>A list of predefinedAccounts</returns>
		public EntityCollection<PredefinedAccount> Find()
		{
			return FindAsync().Result;
		}

		public async Task<EntityCollection<PredefinedAccount>> FindAsync()
		{
			return await BaseFind();
		}
		public async Task<PredefinedAccount> UpdateAsync(PredefinedAccount predefinedAccount)
		{
			return await BaseUpdate(predefinedAccount, predefinedAccount.Name);
		}
		public async Task<PredefinedAccount> GetAsync(string id)
		{
			return await BaseGet(id);
		}
	}
}
