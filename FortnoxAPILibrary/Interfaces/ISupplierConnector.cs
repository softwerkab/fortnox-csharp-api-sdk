using FortnoxAPILibrary.Entities;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface ISupplierConnector : IEntityConnector
	{
		SupplierSearch Search { get; set; }

		Supplier Update(Supplier supplier);
		Supplier Create(Supplier supplier);
		Supplier Get(string id);
		void Delete(string id);
		EntityCollection<SupplierSubset> Find();

		Task<Supplier> UpdateAsync(Supplier supplier);
		Task<Supplier> CreateAsync(Supplier supplier);
		Task<Supplier> GetAsync(string id);
		Task DeleteAsync(string id);
		Task<EntityCollection<SupplierSubset>> FindAsync();
	}
}
