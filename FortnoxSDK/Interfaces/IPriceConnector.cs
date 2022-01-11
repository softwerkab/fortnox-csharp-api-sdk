using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces;

/// <remarks/>
public interface IPriceConnector : IEntityConnector
{
    Task<Price> UpdateAsync(Price price);
    Task<Price> CreateAsync(Price price);
    Task<Price> GetAsync(string priceListCode, string articleNumber, decimal? fromQuantity = null);
    Task DeleteAsync(string priceListCode, string articleNumber, decimal? fromQuantity = null);
    Task<EntityCollection<PriceSubset>> FindAsync(string priceListId, string articleId, PriceSearch searchSettings);
    Task<EntityCollection<PriceSubset>> FindAsync(PriceSearch searchSettings);
}