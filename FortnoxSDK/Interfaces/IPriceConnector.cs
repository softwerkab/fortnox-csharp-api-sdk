using System;
using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces;

/// <remarks/>
public interface IPriceConnector : IEntityConnector
{
    [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
    Price Update(Price price);
    [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
    Price Create(Price price);
    [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
    Price Get(string priceListCode, string articleNumber, decimal? fromQuantity = null);
    [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
    void Delete(string priceListCode, string articleNumber, decimal? fromQuantity = null);
    [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
    EntityCollection<PriceSubset> Find(string priceListId, string articleId, PriceSearch searchSettings);
    [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
    EntityCollection<PriceSubset> Find(PriceSearch searchSettings);

    Task<Price> UpdateAsync(Price price);
    Task<Price> CreateAsync(Price price);
    Task<Price> GetAsync(string priceListCode, string articleNumber, decimal? fromQuantity = null);
    Task DeleteAsync(string priceListCode, string articleNumber, decimal? fromQuantity = null);
    Task<EntityCollection<PriceSubset>> FindAsync(string priceListId, string articleId, PriceSearch searchSettings);
    Task<EntityCollection<PriceSubset>> FindAsync(PriceSearch searchSettings);
}