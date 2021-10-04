using System;
using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces
{
    /// <remarks/>
    public interface ICustomerConnector : IEntityConnector
	{
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
		Customer Update(Customer customer);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
		Customer Create(Customer customer);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
		Customer Get(string id);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
		void Delete(string id);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
		EntityCollection<CustomerSubset> Find(CustomerSearch searchSettings);

		Task<Customer> UpdateAsync(Customer customer);
		Task<Customer> CreateAsync(Customer customer);
		Task<Customer> GetAsync(string id);
		Task DeleteAsync(string id);
		Task<EntityCollection<CustomerSubset>> FindAsync(CustomerSearch searchSettings);
	}
}
