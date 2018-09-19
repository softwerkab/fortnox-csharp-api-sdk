
namespace FortnoxAPILibrary.Connectors
{
    public interface IPreDefinedAccountConnector : IFinancialYearBasedEntityConnector<PreDefinedAccount, PreDefinedAccounts, Sort.By.PreDefinedAccount>
    {
        /// <summary>
        /// Gets a predefined account
        /// </summary>
        /// <param name="name">The name of the predefined account to get</param>
        /// <returns>a predefined account</returns>
        PreDefinedAccount Get(string name);

        /// <summary>
        /// Updates a predefined account
        /// </summary>
        /// <param name="preDefinedAccount">The predefined account to update</param>
        /// <returns>The updated predefined account</returns>
        PreDefinedAccount Update(PreDefinedAccount preDefinedAccount);

        /// <summary>
        /// Gets a list of predefined accounts
        /// </summary>
        /// <returns>A list of predefined accounts</returns>
        PreDefinedAccounts Find();
    }

    /// <remarks/>
	public class PreDefinedAccountConnector : FinancialYearBasedEntityConnector<PreDefinedAccount, PreDefinedAccounts, Sort.By.PreDefinedAccount>, IPreDefinedAccountConnector
    {
		/// <remarks/>
		public PreDefinedAccountConnector()
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
