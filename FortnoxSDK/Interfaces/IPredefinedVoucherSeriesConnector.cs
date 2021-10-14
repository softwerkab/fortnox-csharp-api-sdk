using System;
using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces
{
    /// <remarks/>
    public interface IPredefinedVoucherSeriesConnector : IEntityConnector
	{
        [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
        PredefinedVoucherSeries Update(PredefinedVoucherSeries predefinedVoucherSeries);
        [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
        PredefinedVoucherSeries Get(string id);
        [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
        EntityCollection<PredefinedVoucherSeries> Find(PredefinedVoucherSeriesSearch searchSettings);

		Task<PredefinedVoucherSeries> UpdateAsync(PredefinedVoucherSeries predefinedVoucherSeries);
        Task<PredefinedVoucherSeries> GetAsync(string id);
        Task<EntityCollection<PredefinedVoucherSeries>> FindAsync(PredefinedVoucherSeriesSearch searchSettings);
	}
}
