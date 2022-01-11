using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Search;
using Fortnox.SDK.Serialization;

namespace Fortnox.SDK.Connectors;

internal class AssetConnector : SearchableEntityConnector<Asset, AssetSubset, AssetSearch>, IAssetConnector
{
    public AssetConnector()
    {
        Endpoint = Endpoints.Assets;
        Serializer = new AssetSerializer();
    }

    public async Task<EntityCollection<AssetSubset>> FindAsync(AssetSearch searchSettings)
    {
        return await BaseFind(searchSettings).ConfigureAwait(false);
    }

    public async Task DeleteAsync(long? id)
    {
        await BaseDelete(id.ToString()).ConfigureAwait(false);
    }

    public async Task<Asset> CreateAsync(Asset asset)
    {
        return await BaseCreate(asset).ConfigureAwait(false);
    }

    public async Task<Asset> UpdateAsync(Asset asset)
    {
        return await BaseUpdate(asset, asset.Id.ToString()).ConfigureAwait(false);
    }

    public async Task<Asset> GetAsync(long? id)
    {
        return await BaseGet(id.ToString()).ConfigureAwait(false);
    }
}

internal class AssetSerializer : ISerializer
{
    private readonly ISerializer serializer = new JsonEntitySerializer();

    public string Serialize<T>(T entity)
    {
        return serializer.Serialize(entity);
    }

    public T Deserialize<T>(string content)
    {
        //in case of single single entity response, fix json root from "Assets" to "Asset"
        content = new Regex("\"Assets\":{").Replace(content, "\"Asset\":{", 1);

        return serializer.Deserialize<T>(content);
    }
}