using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces;

/// <remarks/>
public interface IAssetFileConnectionConnector : IEntityConnector
{
    Task<AssetFileConnection> CreateAsync(AssetFileConnection assetFileConnection);
    Task<AssetFileConnection> GetAsync(string id);
    Task DeleteAsync(string id);
    Task<EntityCollection<AssetFileConnection>> FindAsync(AssetFileConnectionSearch searchSettings);
}