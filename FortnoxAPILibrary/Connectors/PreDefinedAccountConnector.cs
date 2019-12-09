
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
	/// <remarks/>
	public class PreDefinedAccountConnector : FinancialYearBasedEntityConnector<PreDefinedAccount, EntityCollection<PreDefinedAccountSubset>, Sort.By.PreDefinedAccount?>
	{
		/// <remarks/>
		public PreDefinedAccountConnector()
		{
			Resource = "predefinedaccounts";
		}

		/// <summary>
		/// Gets a predefined account
		/// </summary>
		/// <param name="name">The name of the predefined account to get</param>
		/// <returns>a predefined account</returns>
		public PreDefinedAccount Get(string name)
		{
			return BaseGet(name);
		}

		/// <summary>
		/// Updates a predefined account
		/// </summary>
		/// <param name="preDefinedAccount">The predefined account to update</param>
		/// <returns>The updated predefined account</returns>
		public PreDefinedAccount Update(PreDefinedAccount preDefinedAccount)
		{
			return BaseUpdate(preDefinedAccount, preDefinedAccount.Name);
		}

		/// <summary>
		/// Gets a list of predefined accounts
		/// </summary>
		/// <returns>A list of predefined accounts</returns>
		public EntityCollection<PreDefinedAccountSubset> Find()
		{
			return BaseFind();
		}
	}
}
