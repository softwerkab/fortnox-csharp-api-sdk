using System.Threading.Tasks;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Search;

namespace Fortnox.SDK.Connectors;

internal class WayOfDeliveryConnector : SearchableEntityConnector<WayOfDelivery, WayOfDelivery, WayOfDeliverySearch>, IWayOfDeliveryConnector
{
    public WayOfDeliveryConnector()
    {
        Endpoint = Endpoints.WayOfDelivery;
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