using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Search;
using Fortnox.SDK.Serialization;
using Fortnox.SDK.Utility;
using Newtonsoft.Json.Linq;

namespace Fortnox.SDK.Connectors;

internal class AssetTypesConnector : SearchableEntityConnector<AssetType, AssetTypesSubset, AssetTypesSearch>, IAssetTypesConnector
{
    public AssetTypesConnector()
    {
        Endpoint = Endpoints.AssetTypes;
        Serializer = new AssetTypeSerializer();
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

        //in case of entity list response, change "Types" to "AssetTypes" and move meta information out of list
        var structure = JObject.Parse(content);
        if (structure["Types"] != null)
        {
            structure["MetaInformation"] = structure["Types"][0]["MetaInformation"]; //copy meta-info node to root
            structure["Types"][0].Remove(); //remove the array element with meta-info node
            content = structure.ToString();
        }

        return serializer.Deserialize<T>(content);
    }
}