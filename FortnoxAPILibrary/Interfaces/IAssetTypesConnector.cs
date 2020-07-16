using FortnoxAPILibrary.Entities;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface IAssetTypesConnector : IEntityConnector
	{
		Sort.Order? SortOrder { get; set; }
		Sort.By.AssetTypes? SortBy { get; set; }
		Filter.AssetTypes? FilterBy { get; set; }

		AssetType Update(AssetType assetType);
		AssetType Create(AssetType assetType);
		AssetType Get(long? id);
		void Delete(long? id);
		EntityCollection<AssetTypesSubset> Find();

		Task<AssetType> UpdateAsync(AssetType assetType);
		Task<AssetType> CreateAsync(AssetType assetType);
		Task<AssetType> GetAsync(long? id);
		Task DeleteAsync(long? id);
		Task<EntityCollection<AssetTypesSubset>> FindAsync();
	}
}
