using System.Threading.Tasks;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Search;

namespace Fortnox.SDK.Connectors;

internal class ModeOfPaymentConnector : SearchableEntityConnector<ModeOfPayment, ModeOfPayment, ModeOfPaymentSearch>, IModeOfPaymentConnector
{
    public ModeOfPaymentConnector()
    {
        Endpoint = Endpoints.ModesOfPayments;
    }

    public async Task<EntityCollection<ModeOfPayment>> FindAsync(ModeOfPaymentSearch searchSettings)
    {
        return await BaseFind(searchSettings).ConfigureAwait(false);
    }

    public async Task DeleteAsync(string id)
    {
        await BaseDelete(id).ConfigureAwait(false);
    }

    public async Task<ModeOfPayment> CreateAsync(ModeOfPayment modeOfPayment)
    {
        return await BaseCreate(modeOfPayment).ConfigureAwait(false);
    }

    public async Task<ModeOfPayment> UpdateAsync(ModeOfPayment modeOfPayment)
    {
        return await BaseUpdate(modeOfPayment, modeOfPayment.Code).ConfigureAwait(false);
    }

    public async Task<ModeOfPayment> GetAsync(string id)
    {
        return await BaseGet(id).ConfigureAwait(false);
    }
}