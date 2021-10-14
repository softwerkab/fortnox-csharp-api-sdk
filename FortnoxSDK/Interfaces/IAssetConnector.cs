using System;
using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces
{
    /// <remarks/>
    public interface IAssetConnector : IEntityConnector
	{
        [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
		Asset Update(Asset asset);
        [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
		Asset Create(Asset asset);
        [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
		Asset Get(string id);
        [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
		void Delete(string id);
        [Obsolete(ApiConstants.ObsoleteSyncMethodWarning)]
		EntityCollection<AssetSubset> Find(AssetSearch searchSettings);

		Task<Asset> UpdateAsync(Asset asset);
		Task<Asset> CreateAsync(Asset asset);
		Task<Asset> GetAsync(string id);
		Task DeleteAsync(string id);
		Task<EntityCollection<AssetSubset>> FindAsync(AssetSearch searchSettings);
	}
}
