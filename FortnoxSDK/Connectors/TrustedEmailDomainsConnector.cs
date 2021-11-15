using System.Threading.Tasks;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Search;
using Fortnox.SDK.Utility;

namespace Fortnox.SDK.Connectors;

internal class TrustedEmailDomainsConnector : SearchableEntityConnector<TrustedEmailDomain, TrustedEmailDomain, TrustedEmailDomainsSearch>, ITrustedEmailDomainsConnector
{
    public TrustedEmailDomainsConnector()
    {
        Resource = Endpoints.TrustedEmailDomains;
    }

    public TrustedEmailDomain Get(long? id)
    {
        return GetAsync(id).GetResult();
    }

    public TrustedEmailDomain Create(TrustedEmailDomain trustedEmailDomains)
    {
        return CreateAsync(trustedEmailDomains).GetResult();
    }

    public void Delete(long? id)
    {
        DeleteAsync(id).GetResult();
    }

    public EntityCollection<TrustedEmailDomain> Find(TrustedEmailDomainsSearch searchSettings)
    {
        return FindAsync(searchSettings).GetResult();
    }

    public async Task<EntityCollection<TrustedEmailDomain>> FindAsync(TrustedEmailDomainsSearch searchSettings)
    {
        return await BaseFind(searchSettings).ConfigureAwait(false);
    }

    public async Task DeleteAsync(long? id)
    {
        await BaseDelete(id.ToString()).ConfigureAwait(false);
    }

    public async Task<TrustedEmailDomain> CreateAsync(TrustedEmailDomain trustedEmailDomains)
    {
        return await BaseCreate(trustedEmailDomains).ConfigureAwait(false);
    }

    public async Task<TrustedEmailDomain> GetAsync(long? id)
    {
        return await BaseGet(id.ToString()).ConfigureAwait(false);
    }
}