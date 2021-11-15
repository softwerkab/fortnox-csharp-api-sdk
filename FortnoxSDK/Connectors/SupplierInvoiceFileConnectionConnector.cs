using System.Threading.Tasks;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Search;
using Fortnox.SDK.Utility;

namespace Fortnox.SDK.Connectors;

internal class SupplierInvoiceFileConnectionConnector : SearchableEntityConnector<SupplierInvoiceFileConnection, SupplierInvoiceFileConnection, SupplierInvoiceFileConnectionSearch>, ISupplierInvoiceFileConnectionConnector
{
    public SupplierInvoiceFileConnectionConnector()
    {
        Resource = Endpoints.SupplierFileConnections;
    }

    public SupplierInvoiceFileConnection Get(string id)
    {
        return GetAsync(id).GetResult();
    }

    public SupplierInvoiceFileConnection Create(SupplierInvoiceFileConnection supplierInvoiceFileConnection)
    {
        return CreateAsync(supplierInvoiceFileConnection).GetResult();
    }

    public void Delete(string id)
    {
        DeleteAsync(id).GetResult();
    }

    public EntityCollection<SupplierInvoiceFileConnection> Find(SupplierInvoiceFileConnectionSearch searchSettings)
    {
        return FindAsync(searchSettings).GetResult();
    }

    public async Task<EntityCollection<SupplierInvoiceFileConnection>> FindAsync(SupplierInvoiceFileConnectionSearch searchSettings)
    {
        return await BaseFind(searchSettings).ConfigureAwait(false);
    }

    public async Task DeleteAsync(string id)
    {
        await BaseDelete(id).ConfigureAwait(false);
    }

    public async Task<SupplierInvoiceFileConnection> CreateAsync(SupplierInvoiceFileConnection supplierInvoiceFileConnection)
    {
        return await BaseCreate(supplierInvoiceFileConnection).ConfigureAwait(false);
    }

    public async Task<SupplierInvoiceFileConnection> GetAsync(string id)
    {
        return await BaseGet(id).ConfigureAwait(false);
    }
}