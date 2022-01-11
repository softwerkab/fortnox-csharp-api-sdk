using System.Threading.Tasks;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Search;

namespace Fortnox.SDK.Connectors;

internal class SupplierInvoiceFileConnectionConnector : SearchableEntityConnector<SupplierInvoiceFileConnection, SupplierInvoiceFileConnection, SupplierInvoiceFileConnectionSearch>, ISupplierInvoiceFileConnectionConnector
{
    public SupplierInvoiceFileConnectionConnector()
    {
        Endpoint = Endpoints.SupplierFileConnections;
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