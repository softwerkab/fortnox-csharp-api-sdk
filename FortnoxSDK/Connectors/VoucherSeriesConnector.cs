using System.Net.Http;
using System.Threading.Tasks;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Requests;
using Fortnox.SDK.Search;

namespace Fortnox.SDK.Connectors;

internal class VoucherSeriesConnector : SearchableEntityConnector<VoucherSeries, VoucherSeriesSubset, VoucherSeriesSearch>, IVoucherSeriesConnector
{
    public VoucherSeriesConnector()
    {
        Endpoint = Endpoints.VoucherSeries;
    }

    public async Task<EntityCollection<VoucherSeriesSubset>> FindAsync(VoucherSeriesSearch searchSettings)
    {
        return await BaseFind(searchSettings).ConfigureAwait(false);
    }

    public async Task<VoucherSeries> CreateAsync(VoucherSeries voucherSeries, long? financialYearId = null)
    {
        var request = new EntityRequest<VoucherSeries>()
        {
            Endpoint = Endpoint,
            Method = HttpMethod.Post,
            Entity = voucherSeries,
        };

        if (financialYearId != null)
            request.Parameters.Add("financialyear", financialYearId.ToString());

        return await SendAsync(request).ConfigureAwait(false);
    }

    public async Task<VoucherSeries> UpdateAsync(VoucherSeries voucherSeries, long? financialYearId = null)
    {
        var request = new EntityRequest<VoucherSeries>()
        {
            Endpoint = Endpoint,
            Method = HttpMethod.Put,
            Entity = voucherSeries
        };

        request.Indices.Add(voucherSeries.Code);

        if (financialYearId != null)
            request.Parameters.Add("financialyear", financialYearId.ToString());

        return await SendAsync(request).ConfigureAwait(false);
    }

    public async Task<VoucherSeries> GetAsync(string id, long? financialYearId = null)
    {
        var request = new EntityRequest<VoucherSeries>()
        {
            Endpoint = Endpoint,
            Method = HttpMethod.Get,
        };

        request.Indices.Add(id);

        if (financialYearId != null)
            request.Parameters.Add("financialyear", financialYearId.ToString());

        return await SendAsync(request).ConfigureAwait(false);
    }
}