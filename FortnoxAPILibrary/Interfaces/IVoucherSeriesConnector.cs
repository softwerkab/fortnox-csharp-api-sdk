using FortnoxAPILibrary.Entities;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface IVoucherSeriesConnector : IEntityConnector
	{


		VoucherSeries Update(VoucherSeries voucherSeries);
		VoucherSeries Create(VoucherSeries voucherSeries);
		VoucherSeries Get(string id);
        EntityCollection<VoucherSeriesSubset> Find(VoucherSeriesSearch searchSettings);

		Task<VoucherSeries> UpdateAsync(VoucherSeries voucherSeries);
		Task<VoucherSeries> CreateAsync(VoucherSeries voucherSeries);
		Task<VoucherSeries> GetAsync(string id);
        Task<EntityCollection<VoucherSeriesSubset>> FindAsync(VoucherSeriesSearch searchSettings);
	}
}
