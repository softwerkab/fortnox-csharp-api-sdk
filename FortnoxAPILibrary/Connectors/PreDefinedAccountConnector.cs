
namespace FortnoxAPILibrary.Connectors
{
	/// <remarks/>
	public class PreDefinedAccountConnector : FinancialYearBasedEntityConnector<PreDefinedAccount, PreDefinedAccounts, Sort.By.PreDefinedAccount>
	{
		/// <remarks/>
		public PreDefinedAccountConnector(string accessToken, string clientSecret) : base(accessToken, clientSecret)
        {
			base.Resource = "predefinedaccounts";
		}

		/// <summary>
		/// Gets a predefined account
		/// </summary>
		/// <param name="name">The name of the predefined account to get</param>
		/// <returns>a predefined account</returns>
		public PreDefinedAccount Get(string name)
		{
			return base.BaseGet(name);
		}

		/// <summary>
		/// Updates a predefined account
		/// </summary>
		/// <param name="preDefinedAccount">The predefined account to update</param>
		/// <returns>The updated predefined account</returns>
		public PreDefinedAccount Update(PreDefinedAccount preDefinedAccount)
		{
			return base.BaseUpdate(preDefinedAccount, preDefinedAccount.Name);
		}

		/// <summary>
		/// Gets a list of predefined accounts
		/// </summary>
		/// <returns>A list of predefined accounts</returns>
		public PreDefinedAccounts Find()
		{
			return base.BaseFind();
		}
	}
}
