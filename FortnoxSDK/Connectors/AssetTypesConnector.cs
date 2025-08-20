using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Search;
using Fortnox.SDK.Serialization;
using Newtonsoft.Json.Linq;

namespace Fortnox.SDK.Connectors;

internal class AssetTypesConnector : SearchableEntityConnector<AssetType, AssetTypesSubset, AssetTypesSearch>, IAssetTypesConnector
{
    protected override ISerializer Serializer => new AssetTypeSerializer();

    public AssetTypesConnector()
    {
        Endpoint = Endpoints.AssetTypes;
    }

    public async Task<EntityCollection<AssetTypesSubset>> FindAsync(AssetTypesSearch searchSettings)
    {
        return await BaseFind(searchSettings).ConfigureAwait(false);
    }

    public async Task DeleteAsync(long? id)
    {
        await BaseDelete(id.ToString()).ConfigureAwait(false);
    }

    public async Task<AssetType> CreateAsync(AssetType assetType)
    {
        return await BaseCreate(assetType).ConfigureAwait(false);
    }

    public async Task<AssetType> UpdateAsync(AssetType assetTypes)
    {
        return await BaseUpdate(assetTypes, assetTypes.Id.ToString()).ConfigureAwait(false);
    }

    public async Task<AssetType> GetAsync(long? id)
    {
        return await BaseGet(id.ToString()).ConfigureAwait(false);
    }
}

internal class AssetTypeSerializer : ISerializer
{
    private readonly ISerializer serializer = new JsonEntitySerializer();

    public string Serialize<T>(T entity)
    {
        return serializer.Serialize(entity);
    }

    public T Deserialize<T>(string content)
    {
        //in case of single entity response, fix json root from "Type" to "AssetType"
        content = new Regex("\"Type\":{").Replace(content, "\"AssetType\":{", 1);

        return serializer.Deserialize<T>(content);
    }
}