using System;
using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces;

/// <remarks/>
public interface ITrustedEmailDomainsConnector : IEntityConnector
{
    [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
    TrustedEmailDomain Create(TrustedEmailDomain trustedEmailDomain);
    [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
    TrustedEmailDomain Get(long? id);
    [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
    void Delete(long? id);
    [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
    EntityCollection<TrustedEmailDomain> Find(TrustedEmailDomainsSearch searchSettings);

    Task<TrustedEmailDomain> CreateAsync(TrustedEmailDomain trustedEmailDomain);
    Task<TrustedEmailDomain> GetAsync(long? id);
    Task DeleteAsync(long? id);
    Task<EntityCollection<TrustedEmailDomain>> FindAsync(TrustedEmailDomainsSearch searchSettings);
}