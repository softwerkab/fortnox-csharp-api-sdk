using System.Threading.Tasks;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Search;

namespace Fortnox.SDK.Connectors;

internal class SupplierConnector : SearchableEntityConnector<Supplier, SupplierSubset, SupplierSearch>, ISupplierConnector
{
    public SupplierConnector()
    {
        Endpoint = Endpoints.Suppliers;
    }

    public async Task<EntityCollection<SupplierSubset>> FindAsync(SupplierSearch searchSettings)
    {
        return await BaseFind(searchSettings).ConfigureAwait(false);
    }

    public async Task DeleteAsync(string id)
    {
        await BaseDelete(id).ConfigureAwait(false);
    }

    public async Task<Supplier> CreateAsync(Supplier supplier)
    {
        return await BaseCreate(supplier).ConfigureAwait(false);
    }

    public async Task<Supplier> UpdateAsync(Supplier supplier)
    {
        return await BaseUpdate(supplier, supplier.SupplierNumber).ConfigureAwait(false);
    }

    public async Task<Supplier> GetAsync(string id)
    {
        return await BaseGet(id).ConfigureAwait(false);
    }
}