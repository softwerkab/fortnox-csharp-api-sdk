using System;
using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces;

/// <remarks/>
public interface IVoucherSeriesConnector : IEntityConnector
{
    Task<VoucherSeries> UpdateAsync(VoucherSeries voucherSeries, long? financialYearId = null);
    Task<VoucherSeries> CreateAsync(VoucherSeries voucherSeries, long? financialYearId = null);
    Task<VoucherSeries> GetAsync(string id, long? financialYearId = null);
    Task<EntityCollection<VoucherSeriesSubset>> FindAsync(VoucherSeriesSearch searchSettings);
}