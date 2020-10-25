using FortnoxAPILibrary.Entities;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface IAssetFileConnectionConnector : IEntityConnector
	{
		AssetFileConnectionSearch Search { get; set; }

        AssetFileConnection Create(AssetFileConnection assetFileConnection);
		AssetFileConnection Get(string id);
		void Delete(string id);
		EntityCollection<AssetFileConnection> Find();

        Task<AssetFileConnection> CreateAsync(AssetFileConnection assetFileConnection);
		Task<AssetFileConnection> GetAsync(string id);
		Task DeleteAsync(string id);
		Task<EntityCollection<AssetFileConnection>> FindAsync();
	}
}
