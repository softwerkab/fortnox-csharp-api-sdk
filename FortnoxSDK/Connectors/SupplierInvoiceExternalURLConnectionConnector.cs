using System.Threading.Tasks;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Search;
using Fortnox.SDK.Utility;

namespace Fortnox.SDK.Connectors;

internal class SupplierInvoiceExternalURLConnectionConnector : SearchableEntityConnector<SupplierInvoiceExternalURLConnection, SupplierInvoiceExternalURLConnection, SupplierInvoiceExternalURLConnectionSearch>, ISupplierInvoiceExternalURLConnectionConnector
{
    public SupplierInvoiceExternalURLConnectionConnector()
    {
        Resource = Endpoints.SupplierInvoiceExternalUrlConnections;
    }

    public SupplierInvoiceExternalURLConnection Get(long? id)
    {
        return GetAsync(id).GetResult();
    }

    public SupplierInvoiceExternalURLConnection Update(SupplierInvoiceExternalURLConnection supplierInvoiceExternalURLConnection)
    {
        return UpdateAsync(supplierInvoiceExternalURLConnection).GetResult();
    }

    public SupplierInvoiceExternalURLConnection Create(SupplierInvoiceExternalURLConnection supplierInvoiceExternalURLConnection)
    {
        return CreateAsync(supplierInvoiceExternalURLConnection).GetResult();
    }

    public void Delete(long? id)
    {
        DeleteAsync(id).GetResult();
    }

    public EntityCollection<SupplierInvoiceExternalURLConnection> Find(SupplierInvoiceExternalURLConnectionSearch searchSettings)
    {
        return FindAsync(searchSettings).GetResult();
    }

    public async Task<EntityCollection<SupplierInvoiceExternalURLConnection>> FindAsync(SupplierInvoiceExternalURLConnectionSearch searchSettings)
    {
        return await BaseFind(searchSettings).ConfigureAwait(false);
    }

    public async Task DeleteAsync(long? id)
    {
        await BaseDelete(id.ToString()).ConfigureAwait(false);
    }

    public async Task<SupplierInvoiceExternalURLConnection> CreateAsync(SupplierInvoiceExternalURLConnection supplierInvoiceExternalURLConnection)
    {
        return await BaseCreate(supplierInvoiceExternalURLConnection).ConfigureAwait(false);
    }

    public async Task<SupplierInvoiceExternalURLConnection> UpdateAsync(SupplierInvoiceExternalURLConnection supplierInvoiceExternalURLConnection)
    {
        return await BaseUpdate(supplierInvoiceExternalURLConnection, supplierInvoiceExternalURLConnection.Id.ToString()).ConfigureAwait(false);
    }

    public async Task<SupplierInvoiceExternalURLConnection> GetAsync(long? id)
    {
        return await BaseGet(id.ToString()).ConfigureAwait(false);
    }
}