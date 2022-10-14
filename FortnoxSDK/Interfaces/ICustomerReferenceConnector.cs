using System.Collections.Generic;
using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

namespace Fortnox.SDK.Interfaces;

/// <remarks>
/// See https://apps.fortnox.se/apidocs#tag/CustomerReferencesResource
/// </remarks>
public interface ICustomerReferenceConnector
{
    Task<IList<CustomerReferenceRow>> FindAsync(CustomerReferenceSearch searchSettings);
    Task<CustomerReferenceRow> GetAsync(long? id);
    Task<CustomerReferenceRow> CreateAsync(CustomerReferenceRow customerReferenceRow);
    Task<CustomerReferenceRow> UpdateAsync(CustomerReferenceRow customerReferenceRow);
    Task DeleteAsync(long? id);
}
