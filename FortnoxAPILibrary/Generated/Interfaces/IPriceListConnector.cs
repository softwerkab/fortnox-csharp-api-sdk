using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;
// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface IPriceListConnector : IConnector
	{
		Sort.Order? SortOrder { get; set; }
		Sort.By.PriceList? SortBy { get; set; }
		Filter.PriceList? FilterBy { get; set; }

		string Code { get; set; }
		string Comments { get; set; }

		PriceList Update(PriceList priceList);
		PriceList Create(PriceList priceList);
		PriceList Get(string id);
		EntityCollection<PriceList> Find();
	}
}
