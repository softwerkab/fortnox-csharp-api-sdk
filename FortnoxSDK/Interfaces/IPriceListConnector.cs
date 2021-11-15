using System;
using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces;

/// <remarks/>
public interface IPriceListConnector : IEntityConnector
{
    [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
    PriceList Update(PriceList priceList);
    [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
    PriceList Create(PriceList priceList);
    [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
    PriceList Get(string id);
    [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
    EntityCollection<PriceList> Find(PriceListSearch searchSettings);

    Task<PriceList> UpdateAsync(PriceList priceList);
    Task<PriceList> CreateAsync(PriceList priceList);
    Task<PriceList> GetAsync(string id);
    Task<EntityCollection<PriceList>> FindAsync(PriceListSearch searchSettings);
}