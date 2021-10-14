using System;
using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces
{
    /// <remarks/>
    public interface ITrustedEmailDomainsConnector : IEntityConnector
    {
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        TrustedEmailDomain Create(TrustedEmailDomain trustedEmailDomain);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        TrustedEmailDomain Get(long? id);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        void Delete(long? id);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        EntityCollection<TrustedEmailDomain> Find(TrustedEmailDomainsSearch searchSettings);

        Task<TrustedEmailDomain> CreateAsync(TrustedEmailDomain trustedEmailDomain);
        Task<TrustedEmailDomain> GetAsync(long? id);
        Task DeleteAsync(long? id);
        Task<EntityCollection<TrustedEmailDomain>> FindAsync(TrustedEmailDomainsSearch searchSettings);
    }
}
