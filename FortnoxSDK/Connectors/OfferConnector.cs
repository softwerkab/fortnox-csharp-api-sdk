using System.Threading.Tasks;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Search;
using Fortnox.SDK.Utility;

namespace Fortnox.SDK.Connectors;

internal class OfferConnector : SearchableEntityConnector<Offer, OfferSubset, OfferSearch>, IOfferConnector
{
    public OfferConnector()
    {
        Endpoint = Endpoints.Offers;
    }

    public async Task<EntityCollection<OfferSubset>> FindAsync(OfferSearch searchSettings)
    {
        return await BaseFind(searchSettings).ConfigureAwait(false);
    }

    public async Task<Offer> CreateAsync(Offer offer)
    {
        return await BaseCreate(offer).ConfigureAwait(false);
    }

    public async Task<Offer> UpdateAsync(Offer offer)
    {
        return await BaseUpdate(offer, offer.DocumentNumber.ToString()).ConfigureAwait(false);
    }

    public async Task<Offer> GetAsync(long? id)
    {
        return await BaseGet(id.ToString()).ConfigureAwait(false);
    }

    public async Task<Offer> CreateOrderAsync(long? id)
    {
        return await DoActionAsync(id.ToString(), Action.CreateOrder).ConfigureAwait(false);
    }

    public async Task<Offer> CancelAsync(long? id)
    {
        return await DoActionAsync(id.ToString(), Action.Cancel).ConfigureAwait(false);
    }

    public async Task<Offer> EmailAsync(long? id)
    {
        return await DoActionAsync(id.ToString(), Action.Email).ConfigureAwait(false);
    }

    public async Task<byte[]> PrintAsync(long? id)
    {
        return await DoDownloadActionAsync(id.ToString(), Action.Print).ConfigureAwait(false);
    }

    public async Task<Offer> ExternalPrintAsync(long? id)
    {
        return await DoActionAsync(id.ToString(), Action.ExternalPrint).ConfigureAwait(false);
    }

    public async Task<byte[]> PreviewAsync(long? id)
    {
        return await DoDownloadActionAsync(id.ToString(), Action.Preview).ConfigureAwait(false);
    }
}