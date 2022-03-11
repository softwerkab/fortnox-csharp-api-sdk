using System.Net.Http;
using System.Threading.Tasks;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Entities.Tenants;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Requests;

namespace Fortnox.SDK.Connectors;

internal class TenantConnector : EntityConnector<Tenant>, ITenantConnector
{
    public TenantConnector()
    {
        Endpoint = Endpoints.Tenant;
    }

    public async Task<Tenant> GetAsync()
    {
        var request = new EntityRequest<Tenant>
        {
            Endpoint = Endpoint,
            Method = HttpMethod.Get,
            UseEntityWrapper = false
        };

        return await SendAsync(request).ConfigureAwait(false);
    }
}
