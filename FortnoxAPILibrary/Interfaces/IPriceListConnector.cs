using FortnoxAPILibrary.Entities;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface IPriceListConnector : IEntityConnector
	{

		PriceList Update(PriceList priceList);
		PriceList Create(PriceList priceList);
		PriceList Get(string id);
		EntityCollection<PriceList> Find(PriceListSearch searchSettings);

		Task<PriceList> UpdateAsync(PriceList priceList);
		Task<PriceList> CreateAsync(PriceList priceList);
		Task<PriceList> GetAsync(string id);
		Task<EntityCollection<PriceList>> FindAsync(PriceListSearch searchSettings);
	}
}
