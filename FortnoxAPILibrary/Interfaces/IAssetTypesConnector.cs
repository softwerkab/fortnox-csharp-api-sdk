using FortnoxAPILibrary.Entities;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface IAssetTypesConnector : IEntityConnector
	{

		AssetType Update(AssetType assetType);
		AssetType Create(AssetType assetType);
		AssetType Get(long? id);
		void Delete(long? id);
		EntityCollection<AssetTypesSubset> Find(AssetTypesSearch searchSettings);

		Task<AssetType> UpdateAsync(AssetType assetType);
		Task<AssetType> CreateAsync(AssetType assetType);
		Task<AssetType> GetAsync(long? id);
		Task DeleteAsync(long? id);
		Task<EntityCollection<AssetTypesSubset>> FindAsync(AssetTypesSearch searchSettings);
	}
}
