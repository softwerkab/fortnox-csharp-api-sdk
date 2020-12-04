using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces
{
    /// <remarks/>
    public interface ICustomerConnector : IEntityConnector
	{

		Customer Update(Customer customer);
		Customer Create(Customer customer);
		Customer Get(string id);
		void Delete(string id);
		EntityCollection<CustomerSubset> Find(CustomerSearch searchSettings);

		Task<Customer> UpdateAsync(Customer customer);
		Task<Customer> CreateAsync(Customer customer);
		Task<Customer> GetAsync(string id);
		Task DeleteAsync(string id);
		Task<EntityCollection<CustomerSubset>> FindAsync(CustomerSearch searchSettings);
	}
}
