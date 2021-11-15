using System.Threading.Tasks;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Search;
using Fortnox.SDK.Utility;

namespace Fortnox.SDK.Connectors;

internal class ModeOfPaymentConnector : SearchableEntityConnector<ModeOfPayment, ModeOfPayment, ModeOfPaymentSearch>, IModeOfPaymentConnector
{
    public ModeOfPaymentConnector()
    {
        Endpoint = Endpoints.ModesOfPayments;
    }

    public ModeOfPayment Get(string id)
    {
        return GetAsync(id).GetResult();
    }

    public ModeOfPayment Update(ModeOfPayment modeOfPayment)
    {
        return UpdateAsync(modeOfPayment).GetResult();
    }

    public ModeOfPayment Create(ModeOfPayment modeOfPayment)
    {
        return CreateAsync(modeOfPayment).GetResult();
    }

    public void Delete(string id)
    {
        DeleteAsync(id).GetResult();
    }

    public EntityCollection<ModeOfPayment> Find(ModeOfPaymentSearch searchSettings)
    {
        return FindAsync(searchSettings).GetResult();
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