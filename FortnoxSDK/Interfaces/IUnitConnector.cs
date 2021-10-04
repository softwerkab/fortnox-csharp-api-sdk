using System;
using System.Threading.Tasks;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Search;

// ReSharper disable UnusedMember.Global
namespace Fortnox.SDK.Interfaces
{
    /// <remarks/>
    public interface IUnitConnector : IEntityConnector
	{
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
		Unit Update(Unit unit);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
		Unit Create(Unit unit);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
		Unit Get(string id);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
		void Delete(string id);
        [Obsolete(APIConstants.ObsoleteSyncMethodWarning)]
		EntityCollection<Unit> Find(UnitSearch searchSettings);

		Task<Unit> UpdateAsync(Unit unit);
		Task<Unit> CreateAsync(Unit unit);
		Task<Unit> GetAsync(string id);
		Task DeleteAsync(string id);
		Task<EntityCollection<Unit>> FindAsync(UnitSearch searchSettings);
	}
}
