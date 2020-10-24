using System.Text.RegularExpressions;
using FortnoxAPILibrary.Entities;

using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class AssetConnector : EntityConnector<Asset, EntityCollection<AssetSubset>, Sort.By.Asset?>, IAssetConnector
	{
	    /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter("filter")]
		public Filter.Asset? FilterBy { get; set; }


		/// <remarks/>
		public AssetConnector()
		{
			Resource = "assets";
		}
		/// <summary>
		/// Find a asset based on id
		/// </summary>
		/// <param name="id">Identifier of the asset to find</param>
		/// <returns>The found asset</returns>
		public Asset Get(string id)
		{
            return GetAsync(id).Result;
        }

		/// <summary>
		/// Updates a asset
		/// </summary>
		/// <param name="asset">The asset to update</param>
		/// <returns>The updated asset</returns>
		public Asset Update(Asset asset)
        {
            return UpdateAsync(asset).Result;
        }

		/// <summary>
		/// Creates a new asset
		/// </summary>
		/// <param name="asset">The asset to create</param>
		/// <returns>The created asset</returns>
		public Asset Create(Asset asset)
        {
            return CreateAsync(asset).Result;
        }

		/// <summary>
		/// Deletes a asset
		/// </summary>
		/// <param name="id">Identifier of the asset to delete</param>
		public void Delete(string id)
		{
			DeleteAsync(id).Wait();
		}

		/// <summary>
		/// Gets a list of assets
		/// </summary>
		/// <returns>A list of assets</returns>
		public EntityCollection<AssetSubset> Find()
		{
			return FindAsync().Result;
		}

		public async Task<EntityCollection<AssetSubset>> FindAsync()
		{
			return await BaseFind().ConfigureAwait(false);
		}
		public async Task DeleteAsync(string id)
		{
			await BaseDelete(id).ConfigureAwait(false);
		}
		public async Task<Asset> CreateAsync(Asset asset)
        {
            Serializer.FixResponseContent = (json) => new Regex("Assets").Replace(json, "Asset", 1);

            var result = await BaseCreate(asset).ConfigureAwait(false);

            Serializer.FixResponseContent = null;
            return result;
        }
		public async Task<Asset> UpdateAsync(Asset asset)
        {
            var id = asset.Id;
            asset.Id = null;
            Serializer.FixResponseContent = (json) => new Regex("Assets").Replace(json, "Asset", 1);

            var result = await BaseUpdate(asset, id).ConfigureAwait(false);

            Serializer.FixResponseContent = null;
            asset.Id = id;
            return result;
		}

		public async Task<Asset> GetAsync(string id)
		{
            Serializer.FixResponseContent = (json) => new Regex("Assets").Replace(json, "Asset", 1);

            var result = await BaseGet(id).ConfigureAwait(false);

            Serializer.FixResponseContent = null;
            return result;
        }
    }
}
