using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Search;
using Fortnox.SDK.Serialization;
using Fortnox.SDK.Utility;
using Newtonsoft.Json.Linq;

// ReSharper disable UnusedMember.Global

namespace Fortnox.SDK.Connectors
{
    /// <remarks/>
    internal class AssetTypesConnector : SearchableEntityConnector<AssetType, AssetTypesSubset, AssetTypesSearch>, IAssetTypesConnector
	{
        /// <remarks/>
		public AssetTypesConnector()
		{
			Resource = "assets/types";
            Serializer = new AssetTypeSerializer();
		}
		/// <summary>
		/// Find a assetType based on id
		/// </summary>
		/// <param name="id">Identifier of the assetType to find</param>
		/// <returns>The found assetType</returns>
		public AssetType Get(long? id)
		{
            return GetAsync(id).GetResult();
        }

		/// <summary>
		/// Updates a assetType
		/// </summary>
		/// <param name="assetTypes">The assetType to update</param>
		/// <returns>The updated assetType</returns>
		public AssetType Update(AssetType assetTypes)
		{
            return UpdateAsync(assetTypes).GetResult();
        }

		/// <summary>
		/// Creates a new assetType
		/// </summary>
		/// <param name="assetType">The assetType to create</param>
		/// <returns>The created assetType</returns>
		public AssetType Create(AssetType assetType)
		{
            return CreateAsync(assetType).GetResult();
        }

		/// <summary>
		/// Deletes a assetTypes
		/// </summary>
		/// <param name="id">Identifier of the assetTypes to delete</param>
		public void Delete(long? id)
		{
			DeleteAsync(id).GetResult();
		}

        /// <summary>
        /// Gets a list of assetTypess
        /// </summary>
        /// <returns>A list of assetTypess</returns>
        public EntityCollection<AssetTypesSubset> Find(AssetTypesSearch searchSettings)
        {
            return FindAsync(searchSettings).GetResult();
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
}
