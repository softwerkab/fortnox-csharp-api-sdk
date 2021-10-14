using System;
using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces
{
    /// <remarks/>
    public interface IAssetFileConnectionConnector : IEntityConnector
    {
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        AssetFileConnection Create(AssetFileConnection assetFileConnection);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        AssetFileConnection Get(string id);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        void Delete(string id);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
        EntityCollection<AssetFileConnection> Find(AssetFileConnectionSearch searchSettings);

        Task<AssetFileConnection> CreateAsync(AssetFileConnection assetFileConnection);
        Task<AssetFileConnection> GetAsync(string id);
        Task DeleteAsync(string id);
        Task<EntityCollection<AssetFileConnection>> FindAsync(AssetFileConnectionSearch searchSettings);
    }
}
