using FortnoxAPILibrary.Entities;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface ISupplierConnector : IConnector
	{
		Sort.Order? SortOrder { get; set; }
		Sort.By.Supplier? SortBy { get; set; }
		Filter.Supplier? FilterBy { get; set; }

		string City { get; set; }
		string Email { get; set; }
		string Name { get; set; }
		string OrganisationNumber { get; set; }
		string Phone1 { get; set; }
		string Phone2 { get; set; }
		string SupplierNumber { get; set; }
		string ZipCode { get; set; }

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
