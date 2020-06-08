using FortnoxAPILibrary.Entities;

using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class AssetFileConnectionConnector : EntityConnector<AssetFileConnection, EntityCollection<AssetFileConnection>, Sort.By.AssetFileConnection?>, IAssetFileConnectionConnector
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
			return GetAsync(id).Result;
		}

        /// <summary>
		/// Creates a new assetFileConnection
		/// </summary>
		/// <param name="assetFileConnection">The assetFileConnection to create</param>
		/// <returns>The created assetFileConnection</returns>
		public AssetFileConnection Create(AssetFileConnection assetFileConnection)
		{
			return CreateAsync(assetFileConnection).Result;
		}

		/// <summary>
		/// Deletes a assetFileConnection
		/// </summary>
		/// <param name="id">Identifier of the assetFileConnection to delete</param>
		public void Delete(string id)
		{
			DeleteAsync(id).Wait();
		}

		/// <summary>
		/// Gets a list of assetFileConnections
		/// </summary>
		/// <returns>A list of assetFileConnections</returns>
		public EntityCollection<AssetFileConnection> Find()
		{
			return FindAsync().Result;
		}

		public async Task<EntityCollection<AssetFileConnection>> FindAsync()
		{
			return await BaseFind();
		}
		public async Task DeleteAsync(string id)
		{
			await BaseDelete(id);
		}
		public async Task<AssetFileConnection> CreateAsync(AssetFileConnection assetFileConnection)
		{
			return await BaseCreate(assetFileConnection);
		}
		public async Task<AssetFileConnection> GetAsync(string id)
		{
			return await BaseGet(id);
		}
	}
}
