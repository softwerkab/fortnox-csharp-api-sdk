using System.Threading.Tasks;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Search;

namespace Fortnox.SDK.Connectors;

internal class UnitConnector : SearchableEntityConnector<Unit, Unit, UnitSearch>, IUnitConnector
{
    public UnitConnector()
    {
        Endpoint = Endpoints.Units;
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