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
		/// Gets a list of predefinedAccountss
		/// </summary>
		/// <returns>A list of predefinedAccountss</returns>
		public EntityCollection<PredefinedAccountsSubset> Find()
		{
			return BaseFind();
		}
	}
}
