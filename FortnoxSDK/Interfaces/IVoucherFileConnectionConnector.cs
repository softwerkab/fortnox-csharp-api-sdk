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
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
		VoucherFileConnection Create(VoucherFileConnection voucherFileConnection, long? financialYearId = null);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
		VoucherFileConnection Get(string id);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
		void Delete(string id);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
		EntityCollection<VoucherFileConnection> Find(VoucherFileConnectionSearch searchSettings);

        Task<VoucherFileConnection> CreateAsync(VoucherFileConnection voucherFileConnection, long? financialYearId = null);
		Task<VoucherFileConnection> GetAsync(string id);
		Task DeleteAsync(string id);
		Task<EntityCollection<VoucherFileConnection>> FindAsync(VoucherFileConnectionSearch searchSettings);
	}
}
