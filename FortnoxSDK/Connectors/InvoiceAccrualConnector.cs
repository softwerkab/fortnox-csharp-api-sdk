using System.Threading.Tasks;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Search;

namespace Fortnox.SDK.Connectors;

internal class InvoiceAccrualConnector : SearchableEntityConnector<InvoiceAccrual, InvoiceAccrualSubset, InvoiceAccrualSearch>, IInvoiceAccrualConnector
{
    public InvoiceAccrualConnector()
    {
        Endpoint = Endpoints.InvoiceAccruals;
    }

    public async Task<EntityCollection<InvoiceAccrualSubset>> FindAsync(InvoiceAccrualSearch searchSettings)
    {
        return await BaseFind(searchSettings).ConfigureAwait(false);
    }

    public async Task DeleteAsync(long? id)
    {
        await BaseDelete(id.ToString()).ConfigureAwait(false);
    }

    public async Task<InvoiceAccrual> CreateAsync(InvoiceAccrual invoiceAccrual)
    {
        return await BaseCreate(invoiceAccrual).ConfigureAwait(false);
    }

    public async Task<InvoiceAccrual> UpdateAsync(InvoiceAccrual invoiceAccrual)
    {
        return await BaseUpdate(invoiceAccrual, invoiceAccrual.InvoiceNumber.ToString()).ConfigureAwait(false);
    }

    public async Task<InvoiceAccrual> GetAsync(long? id)
    {
        return await BaseGet(id.ToString()).ConfigureAwait(false);
    }
}