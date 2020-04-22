using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface IPredefinedVoucherSeriesConnector : IConnector
	{
		Sort.Order? SortOrder { get; set; }
		Sort.By.PredefinedVoucherSeries? SortBy { get; set; }

        [SearchParameter("filter")]
		Filter.PredefinedVoucherSeries? FilterBy { get; set; }

		PredefinedVoucherSeries Update(PredefinedVoucherSeries predefinedVoucherSeries);

        PredefinedVoucherSeries Get(string id);

        EntityCollection<PredefinedVoucherSeries> Find();

	}
}
