using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces
{
    /// <remarks/>
    public interface IPredefinedVoucherSeriesConnector : IEntityConnector
	{


		PredefinedVoucherSeries Update(PredefinedVoucherSeries predefinedVoucherSeries);
        PredefinedVoucherSeries Get(string id);
        EntityCollection<PredefinedVoucherSeries> Find(PredefinedVoucherSeriesSearch searchSettings);

		Task<PredefinedVoucherSeries> UpdateAsync(PredefinedVoucherSeries predefinedVoucherSeries);
        Task<PredefinedVoucherSeries> GetAsync(string id);
        Task<EntityCollection<PredefinedVoucherSeries>> FindAsync(PredefinedVoucherSeriesSearch searchSettings);
	}
}
