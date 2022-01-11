using System;
using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces;

/// <remarks/>
public interface IVoucherConnector : IEntityConnector
{
    Task<Voucher> CreateAsync(Voucher voucher);
    Task<Voucher> GetAsync(long? id, string seriesId, long? financialYearId);
    Task<EntityCollection<VoucherSubset>> FindAsync(VoucherSearch searchSettings);
    Task DeleteAsync(long? id, string seriesId, long? financialYearId);
}