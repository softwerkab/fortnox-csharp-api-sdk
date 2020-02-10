using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class AssetFileConnectionConnector : EntityConnector<AssetFileConnection, EntityCollection<AssetFileConnectionSubset>, Sort.By.AssetFileConnection?>
	{
	    /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter("filter")]
		public Filter.AssetFileConnection FilterBy { get; set; }


        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string AssetId { get; set; }

		/// <remarks/>
		public AssetFileConnectionConnector()
		{
			Resource = "assetfileconnections";
		}

		/// <summary>
		/// Find a assetFileConnection based on assetFileConnectionnumber
		/// </summary>
		/// <param name="assetFileConnectionNumber">The assetFileConnectionnumber to find</param>
		/// <returns>The found assetFileConnection</returns>
		public AssetFileConnection Get(string assetFileConnectionNumber)
		{
			return BaseGet(assetFileConnectionNumber);
		}

		/// <summary>
		/// Updates a assetFileConnection
		/// </summary>
		/// <param name="assetFileConnection">The assetFileConnection to update</param>
		/// <returns>The updated assetFileConnection</returns>
		public AssetFileConnection Update(AssetFileConnection assetFileConnection)
		{
			return BaseUpdate(assetFileConnection, assetFileConnection.AssetFileConnectionNumber);
		}

		/// <summary>
		/// Create a new assetFileConnection
		/// </summary>
		/// <param name="assetFileConnection">The assetFileConnection to create</param>
		/// <returns>The created assetFileConnection</returns>
		public AssetFileConnection Create(AssetFileConnection assetFileConnection)
		{
			return BaseCreate(assetFileConnection);
		}

		/// <summary>
		/// Deletes a assetFileConnection
		/// </summary>
		/// <param name="assetFileConnectionNumber">The assetFileConnectionnumber to delete</param>
		public void Delete(string assetFileConnectionNumber)
		{
			BaseDelete(assetFileConnectionNumber);
		}

		/// <summary>
		/// Gets a list of assetFileConnections
		/// </summary>
		/// <returns>A list of assetFileConnections</returns>
		public EntityCollection<AssetFileConnectionSubset> Find()
		{
			return BaseFind();
		}
	}
}
