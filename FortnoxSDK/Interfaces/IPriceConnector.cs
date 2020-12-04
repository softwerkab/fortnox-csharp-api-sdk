using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces
{
    /// <remarks/>
    public interface IPriceConnector : IEntityConnector
	{

		Price Update(Price price);
		Price Create(Price price);
		Price Get(string priceListCode, string articleNumber, decimal? fromQuantity = null);
		void Delete(string priceListCode, string articleNumber, decimal? fromQuantity = null);
		EntityCollection<PriceSubset> Find(string priceListId, string articleId, PriceSearch searchSettings);

		Task<Price> UpdateAsync(Price price);
		Task<Price> CreateAsync(Price price);
		Task<Price> GetAsync(string priceListCode, string articleNumber, decimal? fromQuantity = null);
		Task DeleteAsync(string priceListCode, string articleNumber, decimal? fromQuantity = null);
		Task<EntityCollection<PriceSubset>> FindAsync(string priceListId, string articleId, PriceSearch searchSettings);
	}
}
