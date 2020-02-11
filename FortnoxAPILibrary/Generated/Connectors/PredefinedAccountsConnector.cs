using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
	/// <remarks/>
	public class PredefinedAccountsConnector : EntityConnector<PredefinedAccounts, EntityCollection<PredefinedAccountsSubset>, Sort.By.PredefinedAccounts?>
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
		/// Find a predefinedAccounts based on id
		/// </summary>
		/// <param name="id">Identifier of the predefinedAccounts to find</param>
		/// <returns>The found predefinedAccounts</returns>
		public PredefinedAccounts Get(string id)
		{
			return BaseGet(id.ToString());
		}

		/// <summary>
		/// Updates a predefinedAccounts
		/// </summary>
		/// <param name="predefinedAccounts">The predefinedAccounts to update</param>
		/// <returns>The updated predefinedAccounts</returns>
		public PredefinedAccounts Update(PredefinedAccounts predefinedAccounts)
		{
			return BaseUpdate(predefinedAccounts, predefinedAccounts.Name.ToString());
		}

		/// <summary>
		/// Creates a new predefinedAccounts
		/// </summary>
		/// <param name="predefinedAccounts">The predefinedAccounts to create</param>
		/// <returns>The created predefinedAccounts</returns>
		public PredefinedAccounts Create(PredefinedAccounts predefinedAccounts)
		{
			return BaseCreate(predefinedAccounts);
		}

		/// <summary>
		/// Deletes a predefinedAccounts
		/// </summary>
		/// <param name="id">Identifier of the predefinedAccounts to delete</param>
		public void Delete(string id)
		{
			BaseDelete(id.ToString());
		}

		/// <summary>
		/// Gets a list of predefinedAccountss
		/// </summary>
		/// <returns>A list of predefinedAccountss</returns>
		public EntityCollection<PredefinedAccountsSubset> Find()
		{
			return BaseFind();
		}
	}
}
