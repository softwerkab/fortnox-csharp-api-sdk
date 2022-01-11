using System.Threading.Tasks;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Search;
using Fortnox.SDK.Utility;

namespace Fortnox.SDK.Connectors;

internal class PriceListConnector : SearchableEntityConnector<PriceList, PriceList, PriceListSearch>, IPriceListConnector
{
    public PriceListConnector()
    {
        Endpoint = Endpoints.PriceLists;
    }
    
    public async Task<EntityCollection<PriceList>> FindAsync(PriceListSearch searchSettings)
    {
        return await BaseFind(searchSettings).ConfigureAwait(false);
    }

    public async Task<PriceList> CreateAsync(PriceList priceList)
    {
        return await BaseCreate(priceList).ConfigureAwait(false);
    }

    public async Task<PriceList> UpdateAsync(PriceList priceList)
    {
        return await BaseUpdate(priceList, priceList.Code).ConfigureAwait(false);
    }

    public async Task<PriceList> GetAsync(string id)
    {
        return await BaseGet(id).ConfigureAwait(false);
    }
}