using System;
using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces;

/// <remarks/>
public interface IAssetFileConnectionConnector : IEntityConnector
{
    [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
    AssetFileConnection Create(AssetFileConnection assetFileConnection);
    [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
    AssetFileConnection Get(string id);
    [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
    void Delete(string id);
    [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
    EntityCollection<AssetFileConnection> Find(AssetFileConnectionSearch searchSettings);

    Task<AssetFileConnection> CreateAsync(AssetFileConnection assetFileConnection);
    Task<AssetFileConnection> GetAsync(string id);
    Task DeleteAsync(string id);
    Task<EntityCollection<AssetFileConnection>> FindAsync(AssetFileConnectionSearch searchSettings);
}