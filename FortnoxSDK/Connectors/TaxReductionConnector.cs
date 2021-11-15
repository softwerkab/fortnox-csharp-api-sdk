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
        Resource = Endpoints.TaxReductions;
    }

    public TaxReduction Get(string id)
    {
        return GetAsync(id).GetResult();
    }

    public TaxReduction Update(TaxReduction taxReduction)
    {
        return UpdateAsync(taxReduction).GetResult();
    }

    public TaxReduction Create(TaxReduction taxReduction)
    {
        return CreateAsync(taxReduction).GetResult();
    }

    public void Delete(string id)
    {
        DeleteAsync(id).GetResult();
    }

    public EntityCollection<TaxReductionSubset> Find(TaxReductionSearch searchSettings)
    {
        return FindAsync(searchSettings).GetResult();
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