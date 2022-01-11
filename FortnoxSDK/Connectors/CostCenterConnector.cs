using System.Threading.Tasks;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Search;
using Fortnox.SDK.Utility;

namespace Fortnox.SDK.Connectors;

internal class CostCenterConnector : SearchableEntityConnector<CostCenter, CostCenter, CostCenterSearch>, ICostCenterConnector
{
    public CostCenterConnector()
    {
        Endpoint = Endpoints.CostCenters;
    }

    public async Task<EntityCollection<CostCenter>> FindAsync(CostCenterSearch searchSettings)
    {
        return await BaseFind(searchSettings).ConfigureAwait(false);
    }

    public async Task DeleteAsync(string id)
    {
        await BaseDelete(id).ConfigureAwait(false);
    }

    public async Task<CostCenter> CreateAsync(CostCenter costCenter)
    {
        return await BaseCreate(costCenter).ConfigureAwait(false);
    }

    public async Task<CostCenter> UpdateAsync(CostCenter costCenter)
    {
        return await BaseUpdate(costCenter, costCenter.Code).ConfigureAwait(false);
    }

    public async Task<CostCenter> GetAsync(string id)
    {
        return await BaseGet(id).ConfigureAwait(false);
    }
}