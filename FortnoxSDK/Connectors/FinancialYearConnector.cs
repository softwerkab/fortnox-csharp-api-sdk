using System.Threading.Tasks;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Search;
using Fortnox.SDK.Utility;

namespace Fortnox.SDK.Connectors;

internal class FinancialYearConnector : SearchableEntityConnector<FinancialYear, FinancialYearSubset, FinancialYearSearch>, IFinancialYearConnector
{
    public FinancialYearConnector()
    {
        Endpoint = Endpoints.FinancialYears;
    }

    public async Task<EntityCollection<FinancialYearSubset>> FindAsync(FinancialYearSearch searchSettings)
    {
        return await BaseFind(searchSettings).ConfigureAwait(false);
    }

    public async Task<FinancialYear> CreateAsync(FinancialYear financialYear)
    {
        return await BaseCreate(financialYear).ConfigureAwait(false);
    }

    public async Task<FinancialYear> GetAsync(long? id)
    {
        return await BaseGet(id.ToString()).ConfigureAwait(false);
    }
}