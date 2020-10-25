using FortnoxAPILibrary.Entities;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface ITaxReductionConnector : IEntityConnector
	{
		TaxReductionSearch Search { get; set; }

		TaxReduction Update(TaxReduction taxReduction);
		TaxReduction Create(TaxReduction taxReduction);
		TaxReduction Get(string id);
		void Delete(string id);
		EntityCollection<TaxReductionSubset> Find();

		Task<TaxReduction> UpdateAsync(TaxReduction taxReduction);
		Task<TaxReduction> CreateAsync(TaxReduction taxReduction);
		Task<TaxReduction> GetAsync(string id);
		Task DeleteAsync(string id);
		Task<EntityCollection<TaxReductionSubset>> FindAsync();
	}
}
