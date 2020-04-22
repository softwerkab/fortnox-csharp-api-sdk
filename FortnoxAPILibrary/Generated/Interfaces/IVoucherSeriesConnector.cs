using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface IVoucherSeriesConnector : IConnector
	{
		Sort.Order? SortOrder { get; set; }
		Sort.By.VoucherSeries? SortBy { get; set; }

        [SearchParameter("filter")]
		Filter.VoucherSeries? FilterBy { get; set; }

		VoucherSeries Update(VoucherSeries voucherSeries);

		VoucherSeries Create(VoucherSeries voucherSeries);

		VoucherSeries Get(string id);

        EntityCollection<VoucherSeriesSubset> Find();

	}
}
