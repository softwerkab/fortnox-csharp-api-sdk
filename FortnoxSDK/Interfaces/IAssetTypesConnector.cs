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
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        AssetType Update(AssetType assetType);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        AssetType Create(AssetType assetType);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        AssetType Get(long? id);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        void Delete(long? id);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        EntityCollection<AssetTypesSubset> Find(AssetTypesSearch searchSettings);

        Task<AssetType> UpdateAsync(AssetType assetType);
        Task<AssetType> CreateAsync(AssetType assetType);
        Task<AssetType> GetAsync(long? id);
        Task DeleteAsync(long? id);
        Task<EntityCollection<AssetTypesSubset>> FindAsync(AssetTypesSearch searchSettings);
    }
}
