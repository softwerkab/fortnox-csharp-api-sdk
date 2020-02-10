using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class AssetTypesConnector : EntityConnector<AssetTypes, EntityCollection<AssetTypesSubset>, Sort.By.AssetTypes?>
	{
	    /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter("filter")]
		public Filter.AssetTypes FilterBy { get; set; }


		/// <remarks/>
		public AssetTypesConnector()
		{
			Resource = "assettypes";
		}

		/// <summary>
		/// Find a assetTypes based on assetTypesnumber
		/// </summary>
		/// <param name="assetTypesNumber">The assetTypesnumber to find</param>
		/// <returns>The found assetTypes</returns>
		public AssetTypes Get(string assetTypesNumber)
		{
			return BaseGet(assetTypesNumber);
		}

		/// <summary>
		/// Updates a assetTypes
		/// </summary>
		/// <param name="assetTypes">The assetTypes to update</param>
		/// <returns>The updated assetTypes</returns>
		public AssetTypes Update(AssetTypes assetTypes)
		{
			return BaseUpdate(assetTypes, assetTypes.AssetTypesNumber);
		}

		/// <summary>
		/// Create a new assetTypes
		/// </summary>
		/// <param name="assetTypes">The assetTypes to create</param>
		/// <returns>The created assetTypes</returns>
		public AssetTypes Create(AssetTypes assetTypes)
		{
			return BaseCreate(assetTypes);
		}

		/// <summary>
		/// Deletes a assetTypes
		/// </summary>
		/// <param name="assetTypesNumber">The assetTypesnumber to delete</param>
		public void Delete(string assetTypesNumber)
		{
			BaseDelete(assetTypesNumber);
		}

		/// <summary>
		/// Gets a list of assetTypess
		/// </summary>
		/// <returns>A list of assetTypess</returns>
		public EntityCollection<AssetTypesSubset> Find()
		{
			return BaseFind();
		}
	}
}
