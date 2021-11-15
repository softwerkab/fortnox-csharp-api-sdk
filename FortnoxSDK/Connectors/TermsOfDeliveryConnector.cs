using System.Threading.Tasks;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Search;
using Fortnox.SDK.Utility;

namespace Fortnox.SDK.Connectors;

internal class TermsOfDeliveryConnector : SearchableEntityConnector<TermsOfDelivery, TermsOfDelivery, TermsOfDeliverySearch>, ITermsOfDeliveryConnector
{
    public TermsOfDeliveryConnector()
    {
        Endpoint = Endpoints.TermsOfDelivery;
    }

    public TermsOfDelivery Get(string id)
    {
        return GetAsync(id).GetResult();
    }

    public TermsOfDelivery Update(TermsOfDelivery termsOfDelivery)
    {
        return UpdateAsync(termsOfDelivery).GetResult();
    }

    public TermsOfDelivery Create(TermsOfDelivery termsOfDelivery)
    {
        return CreateAsync(termsOfDelivery).GetResult();
    }

    public void Delete(string id)
    {
        DeleteAsync(id).GetResult();
    }

    public EntityCollection<TermsOfDelivery> Find(TermsOfDeliverySearch searchSettings)
    {
        return FindAsync(searchSettings).GetResult();
    }

    public async Task<EntityCollection<TermsOfDelivery>> FindAsync(TermsOfDeliverySearch searchSettings)
    {
        return await BaseFind(searchSettings).ConfigureAwait(false);
    }

    public async Task DeleteAsync(string id)
    {
        await BaseDelete(id).ConfigureAwait(false);
    }

    public async Task<TermsOfDelivery> CreateAsync(TermsOfDelivery termsOfDelivery)
    {
        return await BaseCreate(termsOfDelivery).ConfigureAwait(false);
    }

    public async Task<TermsOfDelivery> UpdateAsync(TermsOfDelivery termsOfDelivery)
    {
        return await BaseUpdate(termsOfDelivery, termsOfDelivery.Code).ConfigureAwait(false);
    }

    public async Task<TermsOfDelivery> GetAsync(string id)
    {
        return await BaseGet(id).ConfigureAwait(false);
    }
}