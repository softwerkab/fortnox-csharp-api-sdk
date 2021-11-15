using System.Threading.Tasks;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Search;
using Fortnox.SDK.Utility;

namespace Fortnox.SDK.Connectors;

internal class InvoicePaymentConnector : SearchableEntityConnector<InvoicePayment, InvoicePaymentSubset, InvoicePaymentSearch>, IInvoicePaymentConnector
{
    public InvoicePaymentConnector()
    {
        Endpoint = Endpoints.InvoicePayments;
    }

    public InvoicePayment Get(long? id)
    {
        return GetAsync(id).GetResult();
    }

    public InvoicePayment Update(InvoicePayment invoicePayment)
    {
        return UpdateAsync(invoicePayment).GetResult();
    }

    public InvoicePayment Create(InvoicePayment invoicePayment)
    {
        return CreateAsync(invoicePayment).GetResult();
    }

    public void Delete(long? id)
    {
        DeleteAsync(id).GetResult();
    }

    public EntityCollection<InvoicePaymentSubset> Find(InvoicePaymentSearch searchSettings)
    {
        return FindAsync(searchSettings).GetResult();
    }

    public void Bookkeep(long? id)
    {
        BookkeepAsync(id).GetResult();
    }

    public async Task<EntityCollection<InvoicePaymentSubset>> FindAsync(InvoicePaymentSearch searchSettings)
    {
        return await BaseFind(searchSettings).ConfigureAwait(false);
    }

    public async Task DeleteAsync(long? id)
    {
        await BaseDelete(id.ToString()).ConfigureAwait(false);
    }

    public async Task<InvoicePayment> CreateAsync(InvoicePayment invoicePayment)
    {
        return await BaseCreate(invoicePayment).ConfigureAwait(false);
    }

    public async Task<InvoicePayment> UpdateAsync(InvoicePayment invoicePayment)
    {
        return await BaseUpdate(invoicePayment, invoicePayment.Number.ToString()).ConfigureAwait(false);
    }

    public async Task<InvoicePayment> GetAsync(long? id)
    {
        return await BaseGet(id.ToString()).ConfigureAwait(false);
    }

    public async Task BookkeepAsync(long? id)
    {
        await DoActionAsync(id.ToString(), Action.Bookkeep).ConfigureAwait(false);
    }
}