using FortnoxAPILibrary.Entities;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
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
