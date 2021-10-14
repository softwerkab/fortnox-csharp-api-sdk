using System;
using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces
{
    /// <remarks/>
    public interface IVoucherSeriesConnector : IEntityConnector
    {
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        VoucherSeries Update(VoucherSeries voucherSeries, long? financialYearId = null);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        VoucherSeries Create(VoucherSeries voucherSeries, long? financialYearId = null);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        VoucherSeries Get(string id, long? financialYearId = null);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        EntityCollection<VoucherSeriesSubset> Find(VoucherSeriesSearch searchSettings);

        Task<VoucherSeries> UpdateAsync(VoucherSeries voucherSeries, long? financialYearId = null);
        Task<VoucherSeries> CreateAsync(VoucherSeries voucherSeries, long? financialYearId = null);
        Task<VoucherSeries> GetAsync(string id, long? financialYearId = null);
        Task<EntityCollection<VoucherSeriesSubset>> FindAsync(VoucherSeriesSearch searchSettings);
    }
}
