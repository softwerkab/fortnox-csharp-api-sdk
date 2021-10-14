using System;
using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces
{
    /// <remarks/>
    public interface IVoucherConnector : IEntityConnector
	{
        [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
        Voucher Create(Voucher voucher);
        [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
        Voucher Get(long? id, string seriesId, long? financialYearId);
        [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
        EntityCollection<VoucherSubset> Find(VoucherSearch searchSettings);
        [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
        void Delete(long? id, string seriesId, long? financialYearId);

        Task<Voucher> CreateAsync(Voucher voucher);
		Task<Voucher> GetAsync(long? id, string seriesId, long? financialYearId);
        Task<EntityCollection<VoucherSubset>> FindAsync(VoucherSearch searchSettings);
        Task DeleteAsync(long? id, string seriesId, long? financialYearId);
    }
}
