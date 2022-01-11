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
        Endpoint = Endpoints.SupplierInvoiceExternalUrlConnections;
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