using System.Threading.Tasks;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Search;
using Fortnox.SDK.Utility;

namespace Fortnox.SDK.Connectors;

internal class SupplierInvoiceConnector : SearchableEntityConnector<SupplierInvoice, SupplierInvoiceSubset, SupplierInvoiceSearch>, ISupplierInvoiceConnector
{
    public SupplierInvoiceConnector()
    {
        Resource = Endpoints.SupplierInvoices;
    }

    public SupplierInvoice Get(long? id)
    {
        return GetAsync(id).GetResult();
    }

    public SupplierInvoice Update(SupplierInvoice supplierInvoice)
    {
        return UpdateAsync(supplierInvoice).GetResult();
    }

    public SupplierInvoice Create(SupplierInvoice supplierInvoice)
    {
        return CreateAsync(supplierInvoice).GetResult();
    }

    public EntityCollection<SupplierInvoiceSubset> Find(SupplierInvoiceSearch searchSettings)
    {
        return FindAsync(searchSettings).GetResult();
    }

    public SupplierInvoice Bookkeep(long? id)
    {
        return BookkeepAsync(id).GetResult();
    }

    public SupplierInvoice Cancel(long? id)
    {
        return CancelAsync(id).GetResult();
    }

    public SupplierInvoice Credit(long? id)
    {
        return CreditAsync(id).GetResult();
    }

    public SupplierInvoice ApprovalPayment(long? id)
    {
        return ApprovalPaymentAsync(id).GetResult();
    }

    public SupplierInvoice ApprovalBookkeep(long? id)
    {
        return ApprovalBookkeepAsync(id).GetResult();
    }

    public async Task<EntityCollection<SupplierInvoiceSubset>> FindAsync(SupplierInvoiceSearch searchSettings)
    {
        return await BaseFind(searchSettings).ConfigureAwait(false);
    }

    public async Task<SupplierInvoice> CreateAsync(SupplierInvoice supplierInvoice)
    {
        return await BaseCreate(supplierInvoice).ConfigureAwait(false);
    }

    public async Task<SupplierInvoice> UpdateAsync(SupplierInvoice supplierInvoice)
    {
        return await BaseUpdate(supplierInvoice, supplierInvoice.GivenNumber.ToString()).ConfigureAwait(false);
    }

    public async Task<SupplierInvoice> GetAsync(long? id)
    {
        return await BaseGet(id.ToString()).ConfigureAwait(false);
    }

    public async Task<SupplierInvoice> BookkeepAsync(long? id)
    {
        return await DoActionAsync(id.ToString(), Action.Bookkeep).ConfigureAwait(false);
    }

    public async Task<SupplierInvoice> CancelAsync(long? id)
    {
        return await DoActionAsync(id.ToString(), Action.Cancel).ConfigureAwait(false);
    }

    public async Task<SupplierInvoice> CreditAsync(long? id)
    {
        return await DoActionAsync(id.ToString(), Action.Credit).ConfigureAwait(false);
    }

    public async Task<SupplierInvoice> ApprovalPaymentAsync(long? id)
    {
        return await DoActionAsync(id.ToString(), Action.ApprovalPayment).ConfigureAwait(false);
    }

    public async Task<SupplierInvoice> ApprovalBookkeepAsync(long? id)
    {
        return await DoActionAsync(id.ToString(), Action.ApprovalBookkeep).ConfigureAwait(false);
    }
}