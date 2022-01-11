using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces;

/// <remarks>
/// See https://apps.fortnox.se/apidocs#tag/CustomersResource
/// </remarks>
public interface ICustomerConnector : IEntityConnector
{
    Task<Customer> UpdateAsync(Customer customer);
    Task<Customer> CreateAsync(Customer customer);
    Task<Customer> GetAsync(string id);
    Task DeleteAsync(string id);
    Task<EntityCollection<CustomerSubset>> FindAsync(CustomerSearch searchSettings);
}