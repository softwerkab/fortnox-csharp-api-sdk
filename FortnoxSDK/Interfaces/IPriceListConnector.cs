using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces
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
