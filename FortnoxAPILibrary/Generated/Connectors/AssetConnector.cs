using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class AssetConnector : EntityConnector<Asset, EntityCollection<AssetSubset>, Sort.By.Asset?>
	{
	    /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter("filter")]
		public Filter.Asset FilterBy { get; set; }


        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string Description { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string Type { get; set; }

		/// <remarks/>
		public AssetConnector()
		{
			Resource = "assets";
		}

		/// <summary>
		/// Find a asset based on assetnumber
		/// </summary>
		/// <param name="assetNumber">The assetnumber to find</param>
		/// <returns>The found asset</returns>
		public Asset Get(string assetNumber)
		{
			return BaseGet(assetNumber);
		}

		/// <summary>
		/// Updates a asset
		/// </summary>
		/// <param name="asset">The asset to update</param>
		/// <returns>The updated asset</returns>
		public Asset Update(Asset asset)
		{
			return BaseUpdate(asset, asset.AssetNumber);
		}

		/// <summary>
		/// Create a new asset
		/// </summary>
		/// <param name="asset">The asset to create</param>
		/// <returns>The created asset</returns>
		public Asset Create(Asset asset)
		{
			return BaseCreate(asset);
		}

		/// <summary>
		/// Deletes a asset
		/// </summary>
		/// <param name="assetNumber">The assetnumber to delete</param>
		public void Delete(string assetNumber)
		{
			BaseDelete(assetNumber);
		}

		/// <summary>
		/// Gets a list of assets
		/// </summary>
		/// <returns>A list of assets</returns>
		public EntityCollection<AssetSubset> Find()
		{
			return BaseFind();
		}
	}
}
