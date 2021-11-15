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
        Resource = Endpoints.CostCenters;
    }

    public CostCenter Get(string id)
    {
        return GetAsync(id).GetResult();
    }

    public CostCenter Update(CostCenter costCenter)
    {
        return UpdateAsync(costCenter).GetResult();
    }

    public CostCenter Create(CostCenter costCenter)
    {
        return CreateAsync(costCenter).GetResult();
    }

    public void Delete(string id)
    {
        DeleteAsync(id).GetResult();
    }

    public EntityCollection<CostCenter> Find(CostCenterSearch searchSettings)
    {
        return FindAsync(searchSettings).GetResult();
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