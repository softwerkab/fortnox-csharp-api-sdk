using System.Threading.Tasks;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Search;
using Fortnox.SDK.Utility;

namespace Fortnox.SDK.Connectors;

internal class CustomerConnector : SearchableEntityConnector<Customer, CustomerSubset, CustomerSearch>, ICustomerConnector
{
    public CustomerConnector()
    {
        Resource = Endpoints.Customers;
    }

    public Customer Get(string id)
    {
        return GetAsync(id).GetResult();
    }

    public Customer Update(Customer customer)
    {
        return UpdateAsync(customer).GetResult();
    }

    public Customer Create(Customer customer)
    {
        return CreateAsync(customer).GetResult();
    }

    public void Delete(string id)
    {
        DeleteAsync(id).GetResult();
    }

    public EntityCollection<CustomerSubset> Find(CustomerSearch searchSettings)
    {
        return FindAsync(searchSettings).GetResult();
    }

    public async Task<EntityCollection<CustomerSubset>> FindAsync(CustomerSearch searchSettings)
    {
        return await BaseFind(searchSettings).ConfigureAwait(false);
    }

    public async Task DeleteAsync(string id)
    {
        await BaseDelete(id).ConfigureAwait(false);
    }

    public async Task<Customer> CreateAsync(Customer customer)
    {
        return await BaseCreate(customer).ConfigureAwait(false);
    }

    public async Task<Customer> UpdateAsync(Customer customer)
    {
        return await BaseUpdate(customer, customer.CustomerNumber).ConfigureAwait(false);
    }

    public async Task<Customer> GetAsync(string id)
    {
        return await BaseGet(id).ConfigureAwait(false);
    }
}