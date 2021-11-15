using System.Threading.Tasks;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Search;
using Fortnox.SDK.Utility;

namespace Fortnox.SDK.Connectors;

internal class UnitConnector : SearchableEntityConnector<Unit, Unit, UnitSearch>, IUnitConnector
{
    public UnitConnector()
    {
        Resource = Endpoints.Units;
    }

    public Unit Get(string id)
    {
        return GetAsync(id).GetResult();
    }

    public Unit Update(Unit unit)
    {
        return UpdateAsync(unit).GetResult();
    }

    public Unit Create(Unit unit)
    {
        return CreateAsync(unit).GetResult();
    }

    public void Delete(string id)
    {
        DeleteAsync(id).GetResult();
    }

    public EntityCollection<Unit> Find(UnitSearch searchSettings)
    {
        return FindAsync(searchSettings).GetResult();
    }

    public async Task<EntityCollection<Unit>> FindAsync(UnitSearch searchSettings)
    {
        return await BaseFind(searchSettings).ConfigureAwait(false);
    }

    public async Task DeleteAsync(string id)
    {
        await BaseDelete(id).ConfigureAwait(false);
    }

    public async Task<Unit> CreateAsync(Unit unit)
    {
        return await BaseCreate(unit).ConfigureAwait(false);
    }

    public async Task<Unit> UpdateAsync(Unit unit)
    {
        return await BaseUpdate(unit, unit.Code).ConfigureAwait(false);
    }

    public async Task<Unit> GetAsync(string id)
    {
        return await BaseGet(id).ConfigureAwait(false);
    }
}