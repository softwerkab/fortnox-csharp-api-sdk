using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Search;
using Fortnox.SDK.Serialization;
using Fortnox.SDK.Utility;

// ReSharper disable UnusedMember.Global

namespace Fortnox.SDK.Connectors
{
    /// <remarks/>
    internal class AssetConnector : SearchableEntityConnector<Asset, AssetSubset, AssetSearch>, IAssetConnector
	{
        /// <remarks/>
		public AssetConnector()
		{
			Resource = "assets";
            Serializer = new AssetSerializer();
        }

		/// <summary>
		/// Find a asset based on id
		/// </summary>
		/// <param name="id">Identifier of the asset to find</param>
		/// <returns>The found asset</returns>
		public Asset Get(string id)
		{
            return GetAsync(id).GetResult();
        }

		/// <summary>
		/// Updates a asset
		/// </summary>
		/// <param name="asset">The asset to update</param>
		/// <returns>The updated asset</returns>
		public Asset Update(Asset asset)
        {
            return UpdateAsync(asset).GetResult();
        }

		/// <summary>
		/// Creates a new asset
		/// </summary>
		/// <param name="asset">The asset to create</param>
		/// <returns>The created asset</returns>
		public Asset Create(Asset asset)
        {
            return CreateAsync(asset).GetResult();
        }

		/// <summary>
		/// Deletes a asset
		/// </summary>
		/// <param name="id">Identifier of the asset to delete</param>
		public void Delete(string id)
		{
			DeleteAsync(id).GetResult();
		}

		/// <summary>
		/// Gets a list of assets
		/// </summary>
		/// <returns>A list of assets</returns>
		public EntityCollection<AssetSubset> Find(AssetSearch searchSettings)
		{
			return FindAsync(searchSettings).GetResult();
		}

		public async Task<EntityCollection<AssetSubset>> FindAsync(AssetSearch searchSettings)
		{
			return await BaseFind(searchSettings).ConfigureAwait(false);
		}
		public async Task DeleteAsync(string id)
		{
			await BaseDelete(id).ConfigureAwait(false);
		}
		public async Task<Asset> CreateAsync(Asset asset)
        {
            return await BaseCreate(asset).ConfigureAwait(false);
        }
		public async Task<Asset> UpdateAsync(Asset asset)
        {
            return await BaseUpdate(asset, asset.Id).ConfigureAwait(false);
        }

		public async Task<Asset> GetAsync(string id)
		{
            return await BaseGet(id).ConfigureAwait(false);
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
}
