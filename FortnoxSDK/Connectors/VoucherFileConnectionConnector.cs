using System.Net.Http;
using System.Threading.Tasks;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Requests;
using Fortnox.SDK.Search;
using Fortnox.SDK.Utility;

namespace Fortnox.SDK.Connectors;

internal class VoucherFileConnectionConnector : SearchableEntityConnector<VoucherFileConnection, VoucherFileConnection, VoucherFileConnectionSearch>, IVoucherFileConnectionConnector
{
    public VoucherFileConnectionConnector()
    {
        Endpoint = Endpoints.VoucherFileConnections;
    }

    public async Task<EntityCollection<VoucherFileConnection>> FindAsync(VoucherFileConnectionSearch searchSettings)
    {
        return await BaseFind(searchSettings).ConfigureAwait(false);
    }

    public async Task DeleteAsync(string id)
    {
        await BaseDelete(id).ConfigureAwait(false);
    }

    public async Task<VoucherFileConnection> CreateAsync(VoucherFileConnection voucherFileConnection, long? financialYearId = null)
    {
        var request = new EntityRequest<VoucherFileConnection>()
        {
            Endpoint = Endpoint,
            Method = HttpMethod.Post,
            Entity = voucherFileConnection
        };

        if (financialYearId != null)
            request.Parameters.Add("financialyear", financialYearId.ToString());

        return await SendAsync(request).ConfigureAwait(false);
    }

    public async Task<VoucherFileConnection> GetAsync(string id)
    {
        return await BaseGet(id).ConfigureAwait(false);
    }
}