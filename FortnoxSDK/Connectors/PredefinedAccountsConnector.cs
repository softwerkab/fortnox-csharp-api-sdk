using System.Threading.Tasks;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Search;
using Fortnox.SDK.Utility;

namespace Fortnox.SDK.Connectors;

internal class PredefinedAccountsConnector : SearchableEntityConnector<PredefinedAccount, PredefinedAccount, PredefinedAccountsSearch>, IPredefinedAccountsConnector
{
    public PredefinedAccountsConnector()
    {
        Endpoint = Endpoints.PredefinedAccounts;
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