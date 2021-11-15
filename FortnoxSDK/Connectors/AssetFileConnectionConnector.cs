using System.Threading.Tasks;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Search;
using Fortnox.SDK.Utility;

namespace Fortnox.SDK.Connectors;

internal class AssetFileConnectionConnector : SearchableEntityConnector<AssetFileConnection, AssetFileConnection, AssetFileConnectionSearch>, IAssetFileConnectionConnector
{
    public AssetFileConnectionConnector()
    {
        Endpoint = Endpoints.AssetFileConnections;
    }

    public AssetFileConnection Get(string id)
    {
        return GetAsync(id).GetResult();
    }

    public AssetFileConnection Create(AssetFileConnection assetFileConnection)
    {
        return CreateAsync(assetFileConnection).GetResult();
    }

    public void Delete(string id)
    {
        DeleteAsync(id).GetResult();
    }

    public EntityCollection<AssetFileConnection> Find(AssetFileConnectionSearch searchSettings)
    {
        return FindAsync(searchSettings).GetResult();
    }

    public async Task<EntityCollection<AssetFileConnection>> FindAsync(AssetFileConnectionSearch searchSettings)
    {
        return await BaseFind(searchSettings).ConfigureAwait(false);
    }

    public async Task DeleteAsync(string id)
    {
        await BaseDelete(id).ConfigureAwait(false);
    }

    public async Task<AssetFileConnection> CreateAsync(AssetFileConnection assetFileConnection)
    {
        return await BaseCreate(assetFileConnection).ConfigureAwait(false);
    }

    public async Task<AssetFileConnection> GetAsync(string id)
    {
        return await BaseGet(id).ConfigureAwait(false);
    }
}