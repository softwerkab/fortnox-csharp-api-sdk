using System.Threading.Tasks;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Search;
using Fortnox.SDK.Utility;

namespace Fortnox.SDK.Connectors;

internal class WayOfDeliveryConnector : SearchableEntityConnector<WayOfDelivery, WayOfDelivery, WayOfDeliverySearch>, IWayOfDeliveryConnector
{
    public WayOfDeliveryConnector()
    {
        Resource = Endpoints.WayOfDelivery;
    }

    public WayOfDelivery Get(string id)
    {
        return GetAsync(id).GetResult();
    }

    public WayOfDelivery Update(WayOfDelivery wayOfDelivery)
    {
        return UpdateAsync(wayOfDelivery).GetResult();
    }

    public WayOfDelivery Create(WayOfDelivery wayOfDelivery)
    {
        return CreateAsync(wayOfDelivery).GetResult();
    }

    public void Delete(string id)
    {
        DeleteAsync(id).GetResult();
    }

    public EntityCollection<WayOfDelivery> Find(WayOfDeliverySearch searchSettings)
    {
        return FindAsync(searchSettings).GetResult();
    }

    public async Task<EntityCollection<WayOfDelivery>> FindAsync(WayOfDeliverySearch searchSettings)
    {
        return await BaseFind(searchSettings).ConfigureAwait(false);
    }

    public async Task DeleteAsync(string id)
    {
        await BaseDelete(id).ConfigureAwait(false);
    }

    public async Task<WayOfDelivery> CreateAsync(WayOfDelivery wayOfDelivery)
    {
        return await BaseCreate(wayOfDelivery).ConfigureAwait(false);
    }

    public async Task<WayOfDelivery> UpdateAsync(WayOfDelivery wayOfDelivery)
    {
        return await BaseUpdate(wayOfDelivery, wayOfDelivery.Code).ConfigureAwait(false);
    }

    public async Task<WayOfDelivery> GetAsync(string id)
    {
        return await BaseGet(id).ConfigureAwait(false);
    }
}