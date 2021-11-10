using System;
using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces;

/// <remarks/>
public interface ICustomerConnector : IEntityConnector
{
    [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
    Customer Update(Customer customer);
    [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
    Customer Create(Customer customer);
    [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
    Customer Get(string id);
    [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
    void Delete(string id);
    [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
    EntityCollection<CustomerSubset> Find(CustomerSearch searchSettings);

    Task<Customer> UpdateAsync(Customer customer);
    Task<Customer> CreateAsync(Customer customer);
    Task<Customer> GetAsync(string id);
    Task DeleteAsync(string id);
    Task<EntityCollection<CustomerSubset>> FindAsync(CustomerSearch searchSettings);
}