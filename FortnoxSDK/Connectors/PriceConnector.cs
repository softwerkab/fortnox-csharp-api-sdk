using System.Collections.Generic;
using System.Threading.Tasks;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Requests;
using Fortnox.SDK.Search;

namespace Fortnox.SDK.Connectors;

internal class PriceConnector : SearchableEntityConnector<Price, PriceSubset, PriceSearch>, IPriceConnector
{
    public PriceConnector()
    {
        Endpoint = Endpoints.Prices;
    }

    public async Task<EntityCollection<PriceSubset>> FindAsync(string priceListId, string articleId, PriceSearch searchSettings)
    {
        var request = new SearchRequest<PriceSubset>()
        {
            Endpoint = $"{Endpoint}/sublist",
            Indices = new List<string>() { priceListId, articleId },
            SearchSettings = searchSettings
        };

        return await SendAsync(request).ConfigureAwait(false);
    }

    public Task<EntityCollection<PriceSubset>> FindAsync(PriceSearch searchSettings)
    {
        return BaseFind(searchSettings);
    }

    public async Task DeleteAsync(string priceListCode, string articleNumber, decimal? fromQuantity = null)
    {
        await BaseDelete(priceListCode, articleNumber, fromQuantity?.ToString()).ConfigureAwait(false);
    }

    public async Task<Price> CreateAsync(Price price)
    {
        return await BaseCreate(price).ConfigureAwait(false);
    }

    public async Task<Price> UpdateAsync(Price price)
    {
        return await BaseUpdate(price, price.PriceList, price.ArticleNumber, price.FromQuantity?.ToString()).ConfigureAwait(false);
    }

    public async Task<Price> GetAsync(string priceListCode, string articleNumber, decimal? fromQuantity = null)
    {
        return await BaseGet(priceListCode, articleNumber, fromQuantity?.ToString()).ConfigureAwait(false);
    }
}