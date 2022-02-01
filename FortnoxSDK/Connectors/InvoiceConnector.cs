using System.Threading.Tasks;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Search;

namespace Fortnox.SDK.Connectors;

internal class InvoiceConnector : SearchableEntityConnector<Invoice, InvoiceSubset, InvoiceSearch>, IInvoiceConnector
{
    public InvoiceConnector()
    {
        Endpoint = Endpoints.Invoices;
    }

    public async Task<EntityCollection<InvoiceSubset>> FindAsync(InvoiceSearch searchSettings)
    {
        return await BaseFind(searchSettings).ConfigureAwait(false);
    }

    public async Task<Invoice> CreateAsync(Invoice invoice)
    {
        return await BaseCreate(invoice).ConfigureAwait(false);
    }

    public async Task<Invoice> UpdateAsync(Invoice invoice)
    {
        return await BaseUpdate(invoice, invoice.DocumentNumber.ToString()).ConfigureAwait(false);
    }

    public async Task<Invoice> GetAsync(long? id)
    {
        return await BaseGet(id.ToString()).ConfigureAwait(false);
    }

    public async Task<Invoice> BookkeepAsync(long? id)
    {
        return await DoActionAsync(id.ToString(), Action.Bookkeep).ConfigureAwait(false);
    }

    public async Task<Invoice> CancelAsync(long? id)
    {
        return await DoActionAsync(id.ToString(), Action.Cancel).ConfigureAwait(false);
    }

    public async Task<Invoice> CreditInvoiceAsync(long? id)
    {
        return await DoActionAsync(id.ToString(), Action.Credit).ConfigureAwait(false);
    }

    public async Task<Invoice> EmailAsync(long? id)
    {
        return await DoActionAsync(id.ToString(), Action.Email).ConfigureAwait(false);
    }

    public async Task<Invoice> EInvoiceAsync(long? id)
    {
        return await DoActionAsync(id.ToString(), Action.EInvoice).ConfigureAwait(false);
    }

    public async Task<byte[]> PrintAsync(long? id)
    {
        return await DoDownloadActionAsync(id.ToString(), Action.Print).ConfigureAwait(false);
    }

    public async Task<byte[]> PrintReminderAsync(long? id)
    {
        return await DoDownloadActionAsync(id.ToString(), Action.PrintReminder).ConfigureAwait(false);
    }

    public async Task<Invoice> ExternalPrintAsync(long? id)
    {
        return await DoActionAsync(id.ToString(), Action.ExternalPrint).ConfigureAwait(false);
    }

    public async Task<byte[]> PreviewAsync(long? id)
    {
        return await DoDownloadActionAsync(id.ToString(), Action.Preview).ConfigureAwait(false);
    }

    public async Task<Invoice> WarehouseReady(long? id)
    {
        return await DoActionAsync(id.ToString(), Action.WarehouseReady).ConfigureAwait(false);
    }
}