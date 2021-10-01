using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces
{
    /// <remarks/>
    public interface IVoucherFileConnectionConnector : IEntityConnector
	{

        VoucherFileConnection Create(VoucherFileConnection voucherFileConnection, long? financialYearId = null);
		VoucherFileConnection Get(string id);
		void Delete(string id);
		EntityCollection<VoucherFileConnection> Find(VoucherFileConnectionSearch searchSettings);

        Task<VoucherFileConnection> CreateAsync(VoucherFileConnection voucherFileConnection, long? financialYearId = null);
		Task<VoucherFileConnection> GetAsync(string id);
		Task DeleteAsync(string id);
		Task<EntityCollection<VoucherFileConnection>> FindAsync(VoucherFileConnectionSearch searchSettings);
	}
}
