using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces
{
    /// <remarks/>
    public interface ISupplierConnector : IEntityConnector
	{

		Supplier Update(Supplier supplier);
		Supplier Create(Supplier supplier);
		Supplier Get(string id);
		void Delete(string id);
		EntityCollection<SupplierSubset> Find(SupplierSearch searchSettings);

		Task<Supplier> UpdateAsync(Supplier supplier);
		Task<Supplier> CreateAsync(Supplier supplier);
		Task<Supplier> GetAsync(string id);
		Task DeleteAsync(string id);
		Task<EntityCollection<SupplierSubset>> FindAsync(SupplierSearch searchSettings);
	}
}
