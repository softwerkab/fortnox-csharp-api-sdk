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
		public Filter.AssetFileConnection? FilterBy { get; set; }


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
		/// Find a assetFileConnection based on id
		/// </summary>
		/// <param name="id">Identifier of the assetFileConnection to find</param>
		/// <returns>The found assetFileConnection</returns>
		public AssetFileConnection Get(string id)
		{
			return BaseGet(id.ToString());
		}

        /// <summary>
		/// Creates a new assetFileConnection
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
		/// <param name="id">Identifier of the assetFileConnection to delete</param>
		public void Delete(string id)
		{
			BaseDelete(id.ToString());
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
