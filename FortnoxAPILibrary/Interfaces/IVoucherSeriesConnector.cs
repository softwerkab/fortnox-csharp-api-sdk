using FortnoxAPILibrary.Entities;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface IVoucherSeriesConnector : IConnector
	{
		Sort.Order? SortOrder { get; set; }
		Sort.By.VoucherSeries? SortBy { get; set; }
		Filter.VoucherSeries? FilterBy { get; set; }


		VoucherSeries Update(VoucherSeries voucherSeries);
		VoucherSeries Create(VoucherSeries voucherSeries);
		VoucherSeries Get(string id);
        EntityCollection<VoucherSeriesSubset> Find();

		Task<VoucherSeries> UpdateAsync(VoucherSeries voucherSeries);
		Task<VoucherSeries> CreateAsync(VoucherSeries voucherSeries);
		Task<VoucherSeries> GetAsync(string id);
        Task<EntityCollection<VoucherSeriesSubset>> FindAsync();
	}
}
