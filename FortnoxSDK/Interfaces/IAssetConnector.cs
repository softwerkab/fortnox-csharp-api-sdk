using System;
using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces;

/// <remarks/>
public interface IAssetConnector : IEntityConnector
{
    Task<Asset> UpdateAsync(Asset asset);
    Task<Asset> CreateAsync(Asset asset);
    Task<Asset> GetAsync(long? id);
    Task DeleteAsync(long? id);
    Task<EntityCollection<AssetSubset>> FindAsync(AssetSearch searchSettings);
}