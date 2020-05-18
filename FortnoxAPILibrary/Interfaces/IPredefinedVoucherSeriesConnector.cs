using FortnoxAPILibrary.Entities;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface IPredefinedVoucherSeriesConnector : IConnector
	{
		Sort.Order? SortOrder { get; set; }
		Sort.By.PredefinedVoucherSeries? SortBy { get; set; }
		Filter.PredefinedVoucherSeries? FilterBy { get; set; }


		PredefinedVoucherSeries Update(PredefinedVoucherSeries predefinedVoucherSeries);
        PredefinedVoucherSeries Get(string id);
        EntityCollection<PredefinedVoucherSeries> Find();

		Task<PredefinedVoucherSeries> UpdateAsync(PredefinedVoucherSeries predefinedVoucherSeries);
        Task<PredefinedVoucherSeries> GetAsync(string id);
        Task<EntityCollection<PredefinedVoucherSeries>> FindAsync();
	}
}
