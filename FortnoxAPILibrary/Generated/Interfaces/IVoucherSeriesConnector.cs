using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface IVoucherSeriesConnector : IConnector
	{
        [SearchParameter("filter")]
		Filter.VoucherSeries? FilterBy { get; set; }

		VoucherSeries Update(VoucherSeries voucherSeries);

		VoucherSeries Create(VoucherSeries voucherSeries);

		VoucherSeries Get(string id);

        EntityCollection<VoucherSeriesSubset> Find();

	}
}
