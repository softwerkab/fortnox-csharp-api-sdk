using System;
using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces
{
    /// <remarks/>
    public interface IAssetConnector : IEntityConnector
    {
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        Asset Update(Asset asset);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        Asset Create(Asset asset);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        Asset Get(string id);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        void Delete(string id);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        EntityCollection<AssetSubset> Find(AssetSearch searchSettings);

        Task<Asset> UpdateAsync(Asset asset);
        Task<Asset> CreateAsync(Asset asset);
        Task<Asset> GetAsync(string id);
        Task DeleteAsync(string id);
        Task<EntityCollection<AssetSubset>> FindAsync(AssetSearch searchSettings);
    }
}
