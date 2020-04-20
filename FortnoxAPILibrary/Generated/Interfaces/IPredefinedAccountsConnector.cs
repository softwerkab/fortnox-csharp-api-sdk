using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface IPredefinedAccountsConnector : IConnector
	{
        [SearchParameter("filter")]
		Filter.PredefinedAccounts? FilterBy { get; set; }

		PredefinedAccount Update(PredefinedAccount predefinedAccounts);

        PredefinedAccount Get(string id);

		EntityCollection<PredefinedAccount> Find();

	}
}
