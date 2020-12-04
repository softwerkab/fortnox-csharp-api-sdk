using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces
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
