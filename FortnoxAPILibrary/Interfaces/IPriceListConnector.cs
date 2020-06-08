using FortnoxAPILibrary.Entities;
using System.Threading.Tasks;

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

		Task<PriceList> UpdateAsync(PriceList priceList);
		Task<PriceList> CreateAsync(PriceList priceList);
		Task<PriceList> GetAsync(string id);
		Task<EntityCollection<PriceList>> FindAsync();
	}
}
