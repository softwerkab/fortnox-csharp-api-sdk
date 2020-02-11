using System;
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
		public Filter.AssetTypes? FilterBy { get; set; }


		/// <remarks/>
		public AssetTypesConnector()
		{
			Resource = "assets/types";
		}
		/// <summary>
		/// Find a assetTypes based on id
		/// </summary>
		/// <param name="id">Identifier of the assetTypes to find</param>
		/// <returns>The found assetTypes</returns>
		public AssetTypes Get(int? id)
		{
			return BaseGet(id.ToString());
		}

		/// <summary>
		/// Updates a assetTypes
		/// </summary>
		/// <param name="assetTypes">The assetTypes to update</param>
		/// <returns>The updated assetTypes</returns>
		public AssetTypes Update(AssetTypes assetTypes)
		{
			return BaseUpdate(assetTypes, assetTypes.Id.ToString());
        }

		/// <summary>
		/// Creates a new assetTypes
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
		/// <param name="id">Identifier of the assetTypes to delete</param>
		public void Delete(int? id)
		{
			BaseDelete(id.ToString());
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
