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
		VoucherSeries Update(VoucherSeries voucherSeries);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
		VoucherSeries Create(VoucherSeries voucherSeries);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
		VoucherSeries Get(string id);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
		EntityCollection<VoucherSeriesSubset> Find(VoucherSeriesSearch searchSettings);

		Task<VoucherSeries> UpdateAsync(VoucherSeries voucherSeries);
		Task<VoucherSeries> CreateAsync(VoucherSeries voucherSeries);
		Task<VoucherSeries> GetAsync(string id);
        Task<EntityCollection<VoucherSeriesSubset>> FindAsync(VoucherSeriesSearch searchSettings);
	}
}
