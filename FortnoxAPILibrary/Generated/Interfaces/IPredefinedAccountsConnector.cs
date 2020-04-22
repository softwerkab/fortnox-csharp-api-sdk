using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface IPredefinedAccountsConnector : IConnector
	{
		Sort.Order? SortOrder { get; set; }
		Sort.By.PredefinedAccounts? SortBy { get; set; }

        [SearchParameter("filter")]
		Filter.PredefinedAccounts? FilterBy { get; set; }

		PredefinedAccount Update(PredefinedAccount predefinedAccounts);

        PredefinedAccount Get(string id);

		EntityCollection<PredefinedAccount> Find();

	}
}
