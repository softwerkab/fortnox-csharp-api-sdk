using FortnoxAPILibrary.Entities;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface IAssetConnector : IEntityConnector
	{

		Asset Update(Asset asset);
		Asset Create(Asset asset);
		Asset Get(string id);
		void Delete(string id);
		EntityCollection<AssetSubset> Find(AssetSearch searchSettings);

		Task<Asset> UpdateAsync(Asset asset);
		Task<Asset> CreateAsync(Asset asset);
		Task<Asset> GetAsync(string id);
		Task DeleteAsync(string id);
		Task<EntityCollection<AssetSubset>> FindAsync(AssetSearch searchSettings);
	}
}
