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

    public FinancialYear Get(long? id)
    {
        return GetAsync(id).GetResult();
    }

    public FinancialYear Create(FinancialYear financialYear)
    {
        return CreateAsync(financialYear).GetResult();
    }

    public EntityCollection<FinancialYearSubset> Find(FinancialYearSearch searchSettings)
    {
        return FindAsync(searchSettings).GetResult();
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