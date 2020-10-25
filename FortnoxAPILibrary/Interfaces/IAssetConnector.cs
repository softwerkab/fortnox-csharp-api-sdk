using FortnoxAPILibrary.Entities;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface IAssetConnector : IEntityConnector
	{
		AssetSearch Search { get; set; }

		Asset Update(Asset asset);
		Asset Create(Asset asset);
		Asset Get(string id);
		void Delete(string id);
		EntityCollection<AssetSubset> Find();

		Task<Asset> UpdateAsync(Asset asset);
		Task<Asset> CreateAsync(Asset asset);
		Task<Asset> GetAsync(string id);
		Task DeleteAsync(string id);
		Task<EntityCollection<AssetSubset>> FindAsync();
	}
}
