using System.Threading.Tasks;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Search;

namespace Fortnox.SDK.Connectors;

internal class AccountChartConnector : SearchableEntityConnector<AccountChart, AccountChart, AccountChartSearch>, IAccountChartConnector
{
    public AccountChartConnector()
    {
        Endpoint = Endpoints.AccountCharts;
    }

    public async Task<EntityCollection<AccountChart>> FindAsync(AccountChartSearch searchSettings)
    {
        return await BaseFind(searchSettings).ConfigureAwait(false);
    }
}