using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces;

/// <remarks/>
public interface IPredefinedVoucherSeriesConnector : IEntityConnector
{
    Task<PredefinedVoucherSeries> UpdateAsync(PredefinedVoucherSeries predefinedVoucherSeries);
    Task<PredefinedVoucherSeries> GetAsync(string id);
    Task<EntityCollection<PredefinedVoucherSeries>> FindAsync(PredefinedVoucherSeriesSearch searchSettings);
}