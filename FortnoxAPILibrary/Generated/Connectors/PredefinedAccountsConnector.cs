using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
	/// <remarks/>
	public class PredefinedAccountsConnector : EntityConnector<PredefinedAccount, EntityCollection<PredefinedAccount>, Sort.By.PredefinedAccounts?>
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
			return BaseGet(id.ToString());
		}

		/// <summary>
		/// Updates a predefinedAccounts
		/// </summary>
		/// <param name="predefinedAccounts">The predefinedAccount to update</param>
		/// <returns>The updated predefinedAccount</returns>
		public PredefinedAccount Update(PredefinedAccount predefinedAccount)
		{
			return BaseUpdate(predefinedAccount, predefinedAccount.Name.ToString());
		}

        /// <summary>
		/// Gets a list of predefinedAccounts
		/// </summary>
		/// <returns>A list of predefinedAccounts</returns>
		public EntityCollection<PredefinedAccount> Find()
		{
			return BaseFind();
		}
	}
}
