using System.Threading.Tasks;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Search;

namespace Fortnox.SDK.Connectors;

internal class CustomerConnector : SearchableEntityConnector<Customer, CustomerSubset, CustomerSearch>, ICustomerConnector
{
    public CustomerConnector()
    {
        Endpoint = Endpoints.Customers;
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