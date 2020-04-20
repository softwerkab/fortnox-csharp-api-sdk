using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface IPriceListConnector : IConnector
	{
        [SearchParameter("filter")]
		Filter.PriceList? FilterBy { get; set; }

        [SearchParameter]
		string Code { get; set; }

        [SearchParameter]
		string Comments { get; set; }

		PriceList Update(PriceList priceList);

		PriceList Create(PriceList priceList);

		PriceList Get(string id);
		
		EntityCollection<PriceList> Find();

	}
}
