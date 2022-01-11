using System.Threading.Tasks;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Search;

namespace Fortnox.SDK.Connectors;

internal class TermsOfPaymentConnector : SearchableEntityConnector<TermsOfPayment, TermsOfPayment, TermsOfPaymentSearch>, ITermsOfPaymentConnector
{
    public TermsOfPaymentConnector()
    {
        Endpoint = Endpoints.TermsOfPayments;
    }

    public async Task<EntityCollection<TermsOfPayment>> FindAsync(TermsOfPaymentSearch searchSettings)
    {
        return await BaseFind(searchSettings).ConfigureAwait(false);
    }

    public async Task DeleteAsync(string id)
    {
        await BaseDelete(id).ConfigureAwait(false);
    }

    public async Task<TermsOfPayment> CreateAsync(TermsOfPayment termsOfPayment)
    {
        return await BaseCreate(termsOfPayment).ConfigureAwait(false);
    }

    public async Task<TermsOfPayment> UpdateAsync(TermsOfPayment termsOfPayment)
    {
        return await BaseUpdate(termsOfPayment, termsOfPayment.Code).ConfigureAwait(false);
    }

    public async Task<TermsOfPayment> GetAsync(string id)
    {
        return await BaseGet(id).ConfigureAwait(false);
    }
}