using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces;

/// <remarks/>
public interface ITrustedEmailDomainsConnector : IEntityConnector
{
    Task<TrustedEmailDomain> CreateAsync(TrustedEmailDomain trustedEmailDomain);
    Task<TrustedEmailDomain> GetAsync(long? id);
    Task DeleteAsync(long? id);
    Task<EntityCollection<TrustedEmailDomain>> FindAsync(TrustedEmailDomainsSearch searchSettings);
}