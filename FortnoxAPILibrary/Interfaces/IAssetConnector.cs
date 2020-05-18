using FortnoxAPILibrary.Entities;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface IAssetConnector : IConnector
	{
		Sort.Order? SortOrder { get; set; }
		Sort.By.Asset? SortBy { get; set; }
		Filter.Asset? FilterBy { get; set; }

		string Description { get; set; }
		string Type { get; set; }

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
