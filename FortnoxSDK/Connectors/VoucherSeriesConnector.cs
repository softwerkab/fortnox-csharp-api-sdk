using System.Net.Http;
using System.Threading.Tasks;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Requests;
using Fortnox.SDK.Search;
using Fortnox.SDK.Utility;

namespace Fortnox.SDK.Connectors;

internal class VoucherSeriesConnector : SearchableEntityConnector<VoucherSeries, VoucherSeriesSubset, VoucherSeriesSearch>, IVoucherSeriesConnector
{
    public VoucherSeriesConnector()
    {
        Resource = Endpoints.VoucherSeries;
    }

    public VoucherSeries Get(string id, long? financialYearId = null)
    {
        return GetAsync(id, financialYearId).GetResult();
    }

    public VoucherSeries Update(VoucherSeries voucherSeries, long? financialYearId = null)
    {
        return UpdateAsync(voucherSeries, financialYearId).GetResult();
    }

    public VoucherSeries Create(VoucherSeries voucherSeries, long? financialYearId = null)
    {
        return CreateAsync(voucherSeries, financialYearId).GetResult();
    }

    public EntityCollection<VoucherSeriesSubset> Find(VoucherSeriesSearch searchSettings)
    {
        return FindAsync(searchSettings).GetResult();
    }

    public async Task<EntityCollection<VoucherSeriesSubset>> FindAsync(VoucherSeriesSearch searchSettings)
    {
        return await BaseFind(searchSettings).ConfigureAwait(false);
    }

    public async Task<VoucherSeries> CreateAsync(VoucherSeries voucherSeries, long? financialYearId = null)
    {
        var request = new EntityRequest<VoucherSeries>()
        {
            Resource = Resource,
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
            Resource = Resource,
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
            Resource = Resource,
            Method = HttpMethod.Get,
        };

        request.Indices.Add(id);

        if (financialYearId != null)
            request.Parameters.Add("financialyear", financialYearId.ToString());

        return await SendAsync(request).ConfigureAwait(false);
    }
}