using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces
{
    /// <remarks/>
    public interface ITaxReductionConnector : IEntityConnector
	{

		TaxReduction Update(TaxReduction taxReduction);
		TaxReduction Create(TaxReduction taxReduction);
		TaxReduction Get(string id);
		void Delete(string id);
		EntityCollection<TaxReductionSubset> Find(TaxReductionSearch searchSettings);

		Task<TaxReduction> UpdateAsync(TaxReduction taxReduction);
		Task<TaxReduction> CreateAsync(TaxReduction taxReduction);
		Task<TaxReduction> GetAsync(string id);
		Task DeleteAsync(string id);
		Task<EntityCollection<TaxReductionSubset>> FindAsync(TaxReductionSearch searchSettings);
	}
}
