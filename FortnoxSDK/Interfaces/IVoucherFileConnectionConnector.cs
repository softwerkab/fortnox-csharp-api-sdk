using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces;

/// <remarks/>
public interface IVoucherFileConnectionConnector : IEntityConnector
{
    Task<VoucherFileConnection> CreateAsync(VoucherFileConnection voucherFileConnection, long? financialYearId = null);
    Task<VoucherFileConnection> GetAsync(string id);
    Task DeleteAsync(string id);
    Task<EntityCollection<VoucherFileConnection>> FindAsync(VoucherFileConnectionSearch searchSettings);
}