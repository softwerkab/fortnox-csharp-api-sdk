using System.Threading.Tasks;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Search;
using Fortnox.SDK.Utility;

namespace Fortnox.SDK.Connectors;

internal class SupplierInvoiceAccrualConnector : SearchableEntityConnector<SupplierInvoiceAccrual, SupplierInvoiceAccrualSubset, SupplierInvoiceAccrualSearch>, ISupplierInvoiceAccrualConnector
{
    public SupplierInvoiceAccrualConnector()
    {
        Endpoint = Endpoints.SupplierInvoiceAcrruals;
    }

    public SupplierInvoiceAccrual Get(long? id)
    {
        return GetAsync(id).GetResult();
    }

    public SupplierInvoiceAccrual Update(SupplierInvoiceAccrual supplierInvoiceAccrual)
    {
        return UpdateAsync(supplierInvoiceAccrual).GetResult();
    }

    public SupplierInvoiceAccrual Create(SupplierInvoiceAccrual supplierInvoiceAccrual)
    {
        return CreateAsync(supplierInvoiceAccrual).GetResult();
    }

    public void Delete(long? id)
    {
        DeleteAsync(id).GetResult();
    }

    public EntityCollection<SupplierInvoiceAccrualSubset> Find(SupplierInvoiceAccrualSearch searchSettings)
    {
        return FindAsync(searchSettings).GetResult();
    }

    public async Task<EntityCollection<SupplierInvoiceAccrualSubset>> FindAsync(SupplierInvoiceAccrualSearch searchSettings)
    {
        return await BaseFind(searchSettings).ConfigureAwait(false);
    }

    public async Task DeleteAsync(long? id)
    {
        await BaseDelete(id.ToString()).ConfigureAwait(false);
    }

    public async Task<SupplierInvoiceAccrual> CreateAsync(SupplierInvoiceAccrual supplierInvoiceAccrual)
    {
        return await BaseCreate(supplierInvoiceAccrual).ConfigureAwait(false);
    }

    public async Task<SupplierInvoiceAccrual> UpdateAsync(SupplierInvoiceAccrual supplierInvoiceAccrual)
    {
        return await BaseUpdate(supplierInvoiceAccrual, supplierInvoiceAccrual.SupplierInvoiceNumber.ToString()).ConfigureAwait(false);
    }

    public async Task<SupplierInvoiceAccrual> GetAsync(long? id)
    {
        return await BaseGet(id.ToString()).ConfigureAwait(false);
    }
}