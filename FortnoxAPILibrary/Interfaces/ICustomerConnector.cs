using FortnoxAPILibrary.Entities;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface ICustomerConnector : IConnector
	{
		Sort.Order? SortOrder { get; set; }
		Sort.By.Customer? SortBy { get; set; }
		Filter.Customer? FilterBy { get; set; }

		string City { get; set; }
		string CustomerNumber { get; set; }
		string Email { get; set; }
		string GLN { get; set; }
		string GLNDelivery { get; set; }
		string Name { get; set; }
		string OrganisationNumber { get; set; }
		string Phone1 { get; set; }
		string ZipCode { get; set; }

		Customer Update(Customer customer);
		Customer Create(Customer customer);
		Customer Get(string id);
		void Delete(string id);
		EntityCollection<CustomerSubset> Find();

		Task<Customer> UpdateAsync(Customer customer);
		Task<Customer> CreateAsync(Customer customer);
		Task<Customer> GetAsync(string id);
		Task DeleteAsync(string id);
		Task<EntityCollection<CustomerSubset>> FindAsync();
	}
}
