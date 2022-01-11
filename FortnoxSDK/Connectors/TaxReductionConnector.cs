using System.Threading.Tasks;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Search;
using Fortnox.SDK.Utility;

namespace Fortnox.SDK.Connectors;

internal class TaxReductionConnector : SearchableEntityConnector<TaxReduction, TaxReductionSubset, TaxReductionSearch>, ITaxReductionConnector
{
    public TaxReductionConnector()
    {
        Endpoint = Endpoints.TaxReductions;
    }

    public async Task<EntityCollection<TaxReductionSubset>> FindAsync(TaxReductionSearch searchSettings)
    {
        return await BaseFind(searchSettings).ConfigureAwait(false);
    }

    public async Task DeleteAsync(string id)
    {
        await BaseDelete(id).ConfigureAwait(false);
    }

    public async Task<TaxReduction> CreateAsync(TaxReduction taxReduction)
    {
        return await BaseCreate(taxReduction).ConfigureAwait(false);
    }

    public async Task<TaxReduction> UpdateAsync(TaxReduction taxReduction)
    {
        return await BaseUpdate(taxReduction, taxReduction.Id).ConfigureAwait(false);
    }

    public async Task<TaxReduction> GetAsync(string id)
    {
        return await BaseGet(id).ConfigureAwait(false);
    }
}