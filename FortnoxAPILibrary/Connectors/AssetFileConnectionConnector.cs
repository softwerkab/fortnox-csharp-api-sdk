using FortnoxAPILibrary.Entities;

using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class AssetFileConnectionConnector : SearchableEntityConnector<AssetFileConnection, AssetFileConnection, AssetFileConnectionSearch>, IAssetFileConnectionConnector
	{


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
			return GetAsync(id).GetResult();
		}

        /// <summary>
		/// Creates a new assetFileConnection
		/// </summary>
		/// <param name="assetFileConnection">The assetFileConnection to create</param>
		/// <returns>The created assetFileConnection</returns>
		public AssetFileConnection Create(AssetFileConnection assetFileConnection)
		{
			return CreateAsync(assetFileConnection).GetResult();
		}

		/// <summary>
		/// Deletes a assetFileConnection
		/// </summary>
		/// <param name="id">Identifier of the assetFileConnection to delete</param>
		public void Delete(string id)
		{
			DeleteAsync(id).GetResult();
		}

		/// <summary>
		/// Gets a list of assetFileConnections
		/// </summary>
		/// <returns>A list of assetFileConnections</returns>
		public EntityCollection<AssetFileConnection> Find()
		{
			return FindAsync().GetResult();
		}

		public async Task<EntityCollection<AssetFileConnection>> FindAsync()
		{
			return await BaseFind().ConfigureAwait(false);
		}
		public async Task DeleteAsync(string id)
		{
			await BaseDelete(id).ConfigureAwait(false);
		}
		public async Task<AssetFileConnection> CreateAsync(AssetFileConnection assetFileConnection)
		{
			return await BaseCreate(assetFileConnection).ConfigureAwait(false);
		}
		public async Task<AssetFileConnection> GetAsync(string id)
		{
			return await BaseGet(id).ConfigureAwait(false);
		}
	}
}
