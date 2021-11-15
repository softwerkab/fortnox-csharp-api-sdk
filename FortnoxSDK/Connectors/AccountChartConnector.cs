using System;
using System.Threading.Tasks;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Search;
using Fortnox.SDK.Utility;

namespace Fortnox.SDK.Connectors;

internal class AccountChartConnector : SearchableEntityConnector<AccountChart, AccountChart, AccountChartSearch>, IAccountChartConnector
{
    public AccountChartConnector()
    {
        Endpoint = Endpoints.AccountCharts;
    }

    public EntityCollection<AccountChart> Find(AccountChartSearch searchSettings)
    {
        return FindAsync(searchSettings).GetResult();
    }

    public async Task<EntityCollection<AccountChart>> FindAsync(AccountChartSearch searchSettings)
    {
        return await BaseFind(searchSettings).ConfigureAwait(false);
    }
}