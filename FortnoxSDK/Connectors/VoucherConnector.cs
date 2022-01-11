using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Requests;
using Fortnox.SDK.Search;

namespace Fortnox.SDK.Connectors;

internal class VoucherConnector : SearchableEntityConnector<Voucher, VoucherSubset, VoucherSearch>, IVoucherConnector
{
    public VoucherConnector()
    {
        Endpoint = Endpoints.Vouchers;
    }

    public async Task<EntityCollection<VoucherSubset>> FindAsync(VoucherSearch searchSettings)
    {
        return await BaseFind(searchSettings).ConfigureAwait(false);
    }

    public async Task DeleteAsync(long? id, string seriesId, long? financialYearId)
    {
        var request = new BaseRequest()
        {
            Endpoint = Endpoint,
            Indices = new List<string> { seriesId, id.ToString() },
            Method = HttpMethod.Delete
        };

        if (financialYearId != null)
            request.Parameters.Add("financialyear", financialYearId.ToString());

        await SendAsync(request).ConfigureAwait(false);
    }

    public async Task<Voucher> CreateAsync(Voucher voucher)
    {
        return await BaseCreate(voucher).ConfigureAwait(false);
    }

    public async Task<Voucher> GetAsync(long? id, string seriesId, long? financialYearId)
    {
        var request = new EntityRequest<Voucher>()
        {
            Endpoint = Endpoint,
            Indices = new List<string> { seriesId, id.ToString() },
            Method = HttpMethod.Get
        };

        if (financialYearId != null)
            request.Parameters.Add("financialyear", financialYearId.ToString());

        return await SendAsync(request).ConfigureAwait(false);
    }
}