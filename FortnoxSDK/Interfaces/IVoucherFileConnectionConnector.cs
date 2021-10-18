using System;
using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces
{
    /// <remarks/>
    public interface IVoucherFileConnectionConnector : IEntityConnector
    {
        [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
        VoucherFileConnection Create(VoucherFileConnection voucherFileConnection, long? financialYearId = null);
        [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
        VoucherFileConnection Get(string id);
        [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
        void Delete(string id);
        [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
        EntityCollection<VoucherFileConnection> Find(VoucherFileConnectionSearch searchSettings);

        Task<VoucherFileConnection> CreateAsync(VoucherFileConnection voucherFileConnection, long? financialYearId = null);
        Task<VoucherFileConnection> GetAsync(string id);
        Task DeleteAsync(string id);
        Task<EntityCollection<VoucherFileConnection>> FindAsync(VoucherFileConnectionSearch searchSettings);
    }
}
