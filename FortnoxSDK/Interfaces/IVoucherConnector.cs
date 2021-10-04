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
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        Voucher Create(Voucher voucher);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        Voucher Get(long? id, string seriesId, long? financialYearId);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        EntityCollection<VoucherSubset> Find(VoucherSearch searchSettings);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        void Delete(long? id, string seriesId, long? financialYearId);

        Task<Voucher> CreateAsync(Voucher voucher);
		Task<Voucher> GetAsync(long? id, string seriesId, long? financialYearId);
        Task<EntityCollection<VoucherSubset>> FindAsync(VoucherSearch searchSettings);
        Task DeleteAsync(long? id, string seriesId, long? financialYearId);
    }
}
