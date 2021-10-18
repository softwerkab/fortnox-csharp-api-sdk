using System;
using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces
{
    /// <remarks/>
    public interface IAssetTypesConnector : IEntityConnector
    {
        [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
        AssetType Update(AssetType assetType);
        [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
        AssetType Create(AssetType assetType);
        [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
        AssetType Get(long? id);
        [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
        void Delete(long? id);
        [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
        EntityCollection<AssetTypesSubset> Find(AssetTypesSearch searchSettings);

        Task<AssetType> UpdateAsync(AssetType assetType);
        Task<AssetType> CreateAsync(AssetType assetType);
        Task<AssetType> GetAsync(long? id);
        Task DeleteAsync(long? id);
        Task<EntityCollection<AssetTypesSubset>> FindAsync(AssetTypesSearch searchSettings);
    }
}
